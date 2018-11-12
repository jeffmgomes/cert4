using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Student
    {
        // Properties
        public string StudentID;
        public string Name;
        public string Email;
        public string TelNumber;

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
    }
}
