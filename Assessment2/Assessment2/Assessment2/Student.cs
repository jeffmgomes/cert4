using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    // Author: Jefferson Gomes
    class Student : INotifyPropertyChanged
    {
        // Properties
        private String id;
        private String name;
        private String email;
        private String telNumber;
        public String StudentID { get { return id; } set { id = value; OnPropertyChanged("StudentID"); } } 
        public String Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public String Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public String TelNumber { get { return telNumber; } set { telNumber = value; OnPropertyChanged("TelNumber"); } }

        // Constructor
        public Student(string id, string name, string email, string telnumber)
        {
            StudentID = id;
            Name = name;
            Email = email;
            TelNumber = telnumber;
        }

        public override string ToString()
        {
            return "Student ID: " + StudentID + "\nName: " + Name + "\nEmail: " + Email + "\nTelNumber: " + TelNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
