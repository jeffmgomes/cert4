using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    /// <summary>
    /// Student Class
    /// Author: Jefferson Gomes
    /// Version: 0
    /// </summary>
    class Student
    {
        //Properties
        public string Name;
        public Address Address;
        public int TelNum;
        public string Email;
        public DateTime DBO;
        public DateTime DtAppointment;
        public string Study;
        public int Level;
        public byte[] StudentImg;


        // Constructor
        public Student(string name, string street, string suburb, string city, string state, int postcode, int phone, string email, DateTime dbo, DateTime dtAppointment, string study, int level) {
            Name = name;
            Address = new Address(street, suburb, city, state, postcode);
            TelNum = phone;
            Email = email;
            DBO = dbo;
            DtAppointment = dtAppointment;
            Study = study;
            Level = level;
        }

        /// <summary>
        /// Add an Image to Student
        /// </summary>
        /// <param name="imageStream">The stream of the image in bytes</param>
        public void AddStudentImg(byte[] imageStream)
        {
            StudentImg = imageStream;
        }

        // Override ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Student: ").AppendLine(Name);
            sb.AppendLine(Address.ToString());
            sb.Append("Phone: ").AppendLine(TelNum.ToString());
            sb.Append("Email: ").AppendLine(Email);
            sb.Append("DBO: ").AppendLine(DBO.ToString("dd/MM/yy"));
            sb.Append("Date of Appointment: ").AppendLine(DtAppointment.ToString("dd/MM/yy"));
            sb.Append("Study: ").AppendLine(Study);
            sb.Append("Level of Knowledge: ").AppendLine(Level.ToString());

            return sb.ToString();
        }
    }
}
