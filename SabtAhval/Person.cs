using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabtAhval
{
    class Person
    {
        public Person(string _NationalNumber, string _FirstName, string _LastName, DateTime _BirthDate)
        {
            NationalNumber = _NationalNumber;
            FirstName = _FirstName;
            LastName = _LastName;
            BirthDate = _BirthDate;
        }

        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public Person Spouse { get; set; }
        public List<Person> children { get; set; }
    }
}
