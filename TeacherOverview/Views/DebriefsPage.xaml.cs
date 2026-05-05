namespace TeacherOverview.Views;
using SharedLibrary.Models;

public partial class DebriefsPage : ContentPage
{
	Debrief Debrief { get; set; }
	public DebriefsPage(Debrief debrief)
	{
		InitializeComponent();
		Debrief = debrief;
		eventlist.ItemsSource = Debrief.Events;
		commentlist.ItemsSource = Debrief.Comments;
	}
}