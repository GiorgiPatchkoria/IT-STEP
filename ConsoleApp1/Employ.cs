using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Employ
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
        public Contacts Contacts { get; set; }

        public Employ(string name, string surname, DateTime dateOfBirth, Country country, Gender gender, Contacts contacts)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Country = country;
            Gender = gender;
            Contacts = contacts;
        }

        public int GetAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - DateOfBirth.Year;
            bool birthdayHappened = today.Month > DateOfBirth.Month || (today.Month == DateOfBirth.Month && today.Day >= DateOfBirth.Day);
            if (!birthdayHappened) {
                age--;
            }

            return age;
        }
    }
}
