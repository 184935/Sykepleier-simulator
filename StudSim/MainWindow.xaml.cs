using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SharedLibrary.Models;
using StudSim;

namespace StudSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Case? ActiveCase {  get; set; }
        public Vitals? tempVitals { get; set; }
        public int DebId {  get; set; }
        public long ElapsedSec { get; set; }
        public bool AllergiesChecked { get; set; }
        public ObservableCollection<Event> EventLogg = new();
        public List<Goal> Goals {  get; set; }
        public DispatcherTimer timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Logg.DataContext = EventLogg;
        }



        private async void start_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            if (log.ShowDialog() == true)
            {
                ActiveCase = log.ActiveCase;
                // Legger in pasientinfo
                navn.Content = "Navn: " + ActiveCase.Patient.Name;
                age.Content = "Alder: " + ActiveCase.Patient.Age;
                gender.Content = "Kjonn: " + ActiveCase.Patient.Gender;
                weight.Content = "Vekt: " + ActiveCase.Patient.Weight;
                // Legger inn vitale verdier
                bloodpressure.Content = "Blodtrykk: " + ActiveCase.Vitals.BlodPressure();
                puls.Content = "Puls: " + ActiveCase.Vitals.Pulse;
                respfreq.Content = "Respiratorfrekvens: " + ActiveCase.Vitals.RespiratoryRate;
                o2.Content = "O2-metning: " + ActiveCase.Vitals.OxygenSaturation;
                temp.Content = "Temperatur: " + ActiveCase.Vitals.Temperature + " C";
                // Legger inn labbverdier
                bloodsugar.Content = "Blodsukker: " + ActiveCase.LabValues.BloodSugar;
                creatinine.Content = "Kreatinin: " + ActiveCase.LabValues.Creatinine;
                potassium.Content = "Kalium: " + ActiveCase.LabValues.Potassium;
                sodium.Content = "Natrium: " + ActiveCase.LabValues.Sodium;
                // Makes the start event and starts the debrief
                Event startSim = new Event("Simulering startet",DateTime.Now);
                EventLogg.Add(startSim);
                StartsimDTO? startsimDTO = await App.service.StartSim(ActiveCase.Id, startSim);
                if (startsimDTO != null)
                {
                    tempVitals = ActiveCase.Vitals;
                    tempVitals.Id = startsimDTO.VitalsId;
                    DebId = startsimDTO.DebriefId;
                }

                // Legger Medisiner inn i listen
                medList.DataContext = ActiveCase.Medications;

                // Sjekker maal for casen
                Goals = SimServices.CheckGoals(ActiveCase.Goals, ActiveCase.Vitals);

                // Setter i gang timer for simuleringen
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();

                

            }
        }

        private async void givemeds_Click(object sender, RoutedEventArgs e)
        {
            Event meds = new Event("Given medication", DateTime.Now);
            EventLogg.Add(meds);
            SimServices.GiveMedication(tempVitals);
            await App.service.AddEvent(meds, DebId);
            await App.service.ChangeVitals(tempVitals);
            Goals = SimServices.CheckGoals(Goals, tempVitals);
            bloodpressure.Content = "Blodtrykk: " + tempVitals.BlodPressure();

            if (!AllergiesChecked)
            {
                Event fail = new Event("FAILED - Did not check allergies", DateTime.Now);
                EventLogg.Add(fail);
                await App.service.AddEvent(fail, DebId);
            }
        }
        private async void giveiv_Click(object sender, RoutedEventArgs e)
        {
            Event IV = new Event("Given IV", DateTime.Now);
            EventLogg.Add(IV);
            SimServices.GiveIV(tempVitals);
            await App.service.AddEvent(IV, DebId);
            await App.service.ChangeVitals(tempVitals);
            bloodpressure.Content = "Blodtrykk: " + tempVitals.BlodPressure();
            Goals = SimServices.CheckGoals(Goals, tempVitals);
        }
        private async void giveblanket_Click(object sender, RoutedEventArgs e)
        {
            Event heated = new Event("Warmed up", DateTime.Now);
            EventLogg.Add(heated);
            SimServices.GiveBlanket(tempVitals);
            await App.service.AddEvent(heated, DebId);
            await App.service.ChangeVitals(tempVitals);
            temp.Content = "Temperatur: " + tempVitals.Temperature + " C";
            Goals = SimServices.CheckGoals(Goals, tempVitals);
        }
        private async void cooldown_Click(object sender, RoutedEventArgs e)
        {
            Event cooled = new Event("Cooled down", DateTime.Now);
            EventLogg.Add(cooled);
            SimServices.CoolDown(tempVitals);
            await App.service.AddEvent(cooled, DebId);
            await App.service.ChangeVitals(tempVitals);
            temp.Content = "Temperatur: " + tempVitals.Temperature + " C";
            Goals = SimServices.CheckGoals(Goals, tempVitals);
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            ElapsedSec++;

            if (Goals.Count == 0)
            {
                timer.Stop();
                Event done = new Event("Simulation finished", DateTime.Now);
                EventLogg.Add(done);
                await App.service.StopSim(tempVitals.Id, DebId, done);
                MessageBox.Show("Simulering ferdig");
                
            }
            else
            {

                foreach (Goal g in Goals)
                {
                    if (!g.Completed && g.Time < ElapsedSec)
                    {
                        Event failed = new Event("FAILED - Goal not achieved in time", DateTime.Now);
                        EventLogg.Add(failed);
                        await App.service.AddEvent(failed, DebId);
                    }
                }
            }
        }

        private async void allergies_Click(object sender, RoutedEventArgs e)
        {
            List<Allergy> allergies = ActiveCase.Allergies;
            Allergies alg = new Allergies(allergies);
            alg.Show();

        }

        private void diagnosis_Click(object sender, RoutedEventArgs e)
        {
            List<SharedLibrary.Models.Diagnosis> diagnoes = ActiveCase.Diagnoses;
            Diagnosis dia = new Diagnosis(diagnoes);
            dia.Show();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            History his = new History(ActiveCase.MedicalHistory);
            his.Show();

        }
    }
}