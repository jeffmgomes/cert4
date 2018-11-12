using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Assessment1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {

        // Static list of Subjects to Study
        List<string> studies = new List<string> { "Networking", "Software Development", "Web", "Digital Media" };
        // Camera
        CameraCaptureUI ccui = new CameraCaptureUI();
        // User Image
        byte[] user_image;

        public Page1()
        {
            this.InitializeComponent();
        }
        
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Create a student Object
            Student newStudent = new Student(txtName.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtState.Text, int.Parse(txtPostCode.Text), int.Parse(txtPhone.Text), txtEmail.Text, dtpDBO.Date.Date, calDtAppointment.Date.Value.Date, cbxStudyInterest.SelectedValue.ToString(), int.Parse(sldLevelOfKnowledge.Value.ToString()));
            // Add an image to the student
            if (user_image != null)
            {
                newStudent.AddStudentImg(user_image);
            }

            // Diplay the Student
            MessageDialog msg = new MessageDialog(newStudent.ToString());
            await msg.ShowAsync();
        }

        private async void btnTakePhoto_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            control_Image.Source = image;

            ccui.PhotoSettings.AllowCropping = true;
            ccui.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            var photo = await ccui.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                await image.SetSourceAsync(stream);

                stream.Seek(0);
                BinaryReader reader = new BinaryReader(stream.AsStreamForRead());
                user_image = new byte[stream.Size];
                reader.Read(user_image, 0, user_image.Length);
            }
            else
            {
                MessageDialog msg = new MessageDialog("We had a problem capturing your photo. Please try again.");
                await msg.ShowAsync();
            }
        }
    }
}
