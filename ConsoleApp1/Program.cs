namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employ[] employs = new Employ[8];

            employs[0] = new Employ("Giorgi", "Patchkoria", new DateTime(2003, 12, 26), Country.Georgia, Gender.Male, Contacts.Phone);
            employs[1] = new Employ("Xvicha", "Kvaratskhelia", new DateTime(2001, 2, 12), Country.Georgia, Gender.Male, Contacts.Email);
            employs[2] = new Employ("Thomas", "Müller", new DateTime(1989, 9, 12), Country.Germany, Gender.Male, Contacts.Fax);
            employs[3] = new Employ("Manuel", "Neuer", new DateTime(1986, 3, 27), Country.Germany, Gender.Male, Contacts.Email);
            employs[4] = new Employ("Donald", "Trump", new DateTime(1946, 6, 14), Country.USA, Gender.Male, Contacts.Phone);
            employs[5] = new Employ("Bill", "Gates", new DateTime(1955, 10, 28), Country.USA, Gender.Male, Contacts.Email);
            employs[6] = new Employ("Junior", "Neymar", new DateTime(1992, 2, 5), Country.Brasil, Gender.Male, Contacts.Phone);
            employs[7] = new Employ("Nazario", "Ronaldo", new DateTime(1976, 9, 18), Country.Brasil, Gender.Male, Contacts.Fax);


            for (int i = 0; i < employs.Length; i++) {
                Console.WriteLine($"{employs[i].Name} {employs[i].Surname} is {employs[i].GetAge()} years old");
            }

            PrintByCountry(employs, Country.Georgia);
        }

        static void PrintByCountry(Employ[] employs, Country country)
        {
            bool found = false;
            for (int i = 0; i < employs.Length; i++)
            {
                if (employs[i].Country == country)
                {
                    Console.WriteLine($"{employs[i].Name} {employs[i].Surname} is from {country}");
                    found = true;
                }
            }

            if (!found) { 
                Console.WriteLine("Not Found");
            }
        }
    }
}