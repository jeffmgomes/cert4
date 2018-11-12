using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Assessment2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// Author: Jefferson Gomes
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Student newStudent;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                // Set the Username that came from the Login page
                tbxUser.Text = App.gUser ;

                // Test if the student object is empty, if so Disable the Detail button
                if (newStudent == null)
                {
                    btnStudentDetails.IsEnabled = false;
                }
            };
        }

        private void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            // Navigates to the new student page
            Frame.Navigate(typeof(StudentInfo));
        }

        private void btnStudentDetails_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Student Details page
            Frame.Navigate(typeof(StudentDetails), newStudent);
        }

        // Overriding
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newStudent = (Student)e.Parameter;          
        }
    }
}
