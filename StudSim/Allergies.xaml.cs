using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SharedLibrary.Models;

namespace StudSim
{
    /// <summary>
    /// Interaction logic for Allergies.xaml
    /// </summary>
    public partial class Allergies : Window
    {
        public Allergies(List<Allergy> allergies)
        {
            InitializeComponent();
            Allergylist.DataContext = allergies;
        }
    }
}
