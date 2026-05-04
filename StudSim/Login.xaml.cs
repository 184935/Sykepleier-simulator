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
using Rest_API.Controllers;
using SharedLibrary.Models;

namespace StudSim
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private async Task Button_Click(object sender, RoutedEventArgs e)
        {
            LoginDTO loginDTO = new LoginDTO(email.Text, password.Password);


            

        }
    }
}
