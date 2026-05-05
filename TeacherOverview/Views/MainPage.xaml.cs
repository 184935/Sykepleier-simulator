namespace TeacherOverview.Views;

using SharedLibrary.Models;
using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    private readonly Apiservice Appservice;
    public Case? ActiveCase { get; set; }
    public int DebriefId { get; set; }
    public Vitals? Tempvitals { get; set; }
    public IDispatcherTimer? timer { get;  set; }
    public DateTime Timestamp {  get; set; }
    public MainPage(Apiservice apiservice)
    {
        InitializeComponent();
        Appservice = apiservice;
    }

    private async void SimButton_Clicked(object sender, EventArgs e)
    {
        var response = await Appservice.Checksim();
        if (response != null)
        {
            //ActiveCase = response.MedCase;
            DebriefId = response.DebriefId;
            ActiveCase = response.Case;
            Tempvitals = response.Vitals;
            timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        

    }

    private async void Timer_Tick(object? sender, EventArgs e)
    {
        Tempvitals = await Appservice.Vitals(Tempvitals.Id);
        List<Event> events = await Appservice.GetEvents(DebriefId);
        Eventlogg.ItemsSource = new ObservableCollection<Event>(
            events.OrderByDescending(e => e.Timestamp));
    }

    private async void DebriefButton_Clicked(object sender, EventArgs e)
    {
        Debrief debrief = await Appservice.GetDebrief();
        DebriefsPage debriefsPage = new DebriefsPage(debrief);
        await Navigation.PushAsync(debriefsPage);
    }
    private async void CommentButton_Clicked(object sender, EventArgs e)
    {
        Timestamp = DateTime.Now;
        kommentarfelt.IsVisible = true;
        kommentarfelt.Focus();
    }
    private async void CommentEntry_Completed(object sender, EventArgs e)
    {
        Comment comment = new Comment(kommentarfelt.Text, Timestamp);
        await Appservice.AddComment(comment, DebriefId);
        kommentarfelt.IsVisible = false;
    }
}
