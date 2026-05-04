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

        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task start_Click(object sender, RoutedEventArgs e)
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
                StartsimDTO? startsimDTO = await App.service.StartSim(ActiveCase.Id, startSim);
                if (startsimDTO != null)
                {
                    tempVitals = ActiveCase.Vitals;
                    tempVitals.Id = startsimDTO.VitalsId;
                    DebId = startsimDTO.DebriefId;
                }
                // Sjekker maal for casen
                SimServices.CheckGoals(ActiveCase);

                // Setter i gang timer for simuleringen
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();

            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            ElapsedSec++;

            if (ActiveCase.Goals.Count == 0)
            {
                Event done = new Event("Simulation finished", DateTime.Now);
                App.service.StopSim(tempVitals.Id, DebId, done);
            }
            else
            {

                foreach (Goal g in ActiveCase.Goals)
                {
                    if (!g.Completed && g.Time < ElapsedSec)
                    {
                        Event failed = new Event("Goal not achieved in time", DateTime.Now);
                        App.service.AddEvent(failed, DebId);
                    }
                }
            }
        }
    }
}