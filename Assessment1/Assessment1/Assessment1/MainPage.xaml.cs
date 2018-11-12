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

namespace Assessment1
{
    /// <summary>
    /// Main page
    /// Author: Jefferson Gomes
    /// Version: 0
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Static list of Subjects to Study
        List<string> studies = new List<string> { "Networking", "Software Development", "Web", "Digital Media" };
        // Camera
        CameraCaptureUI ccui = new CameraCaptureUI();
        // User Image
        byte[] user_image;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Create a student Object
            Student newStudent = new Student(txtName.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtState.Text, int.Parse(txtPostCode.Text), int.Parse(txtPhone.Text), txtEmail.Text, dtpDBO.Date.Date, calDtAppointment.Date.Value.Date, cbxStudyInterest.SelectedValue.ToString(), int.Parse(sldLevelOfKnowledge.Value.ToString()));
            
            // Add an image to the student if was able to take
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
            // Setup the Camera object
            ccui.PhotoSettings.AllowCropping = true;
            ccui.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            
            // Call the camera app
            var photo = await ccui.CaptureFileAsync(CameraCaptureUIMode.Photo);

            // Check if a photo was taken
            if (photo != null)
            {
                // Create a new Bitmap image
                BitmapImage image = new BitmapImage();
                
                // Create a stream 
                var stream = await photo.OpenReadAsync();
                // Set the stream as a source for the Bitmap image
                await image.SetSourceAsync(stream);

                // Set the image as source of the image control in the page
                control_Image.Source = image;

                // Read the stream to save as a byte and save in the user_image property of the Student Class
                stream.Seek(0);
                BinaryReader reader = new BinaryReader(stream.AsStreamForRead());
                user_image = new byte[stream.Size];
                reader.Read(user_image, 0, user_image.Length);
            }
            else
            {
                // In case of a problem on taking the photo
                MessageDialog msg = new MessageDialog("We had a problem capturing your photo. Please try again.");
                await msg.ShowAsync();
            }
        }
    }
}
