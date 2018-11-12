using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    /// <summary>
    /// Address Class
    /// Author: Jefferson Gomes
    /// Version: 0
    /// </summary>
    class Address
    {

        // Properties
        public string Street;
        public string Suburb;
        public string City;
        public string State;
        public int PostCode;

        // Constructor
        public Address(string street, string suburb, string city, string state, int postcode) {
            Street = street;
            Suburb = suburb;
            City = city;
            State = state;
            PostCode = postcode;
        }

        // Override ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Address: ");
            sb.Append(Street);
            sb.Append(", ").Append(Suburb);
            sb.Append(", ").Append(City);
            sb.Append(", ").Append(State);
            sb.Append(", ").Append(PostCode);
            return sb.ToString();
        }
    }
}
