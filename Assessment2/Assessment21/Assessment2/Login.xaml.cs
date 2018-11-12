using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Assessment2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private MessageDialog msg;

        public Login()
        {
            this.InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Save the username and password 
            string user = txtUser.Text;
            string pass = txtPassword.Password;

            // Test for equality
            if (user.Equals(App.gUser) && pass.Equals(App.gPass))
            {
                Frame.Navigate(typeof(MainPage), user);
            }
            else
            {
                msg = new MessageDialog("Username or password incorret!");
                await msg.ShowAsync();
            }
        }
    }
}
