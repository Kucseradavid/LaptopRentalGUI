using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalGUI.Classes
{
    internal class Rental
    {
        public string PersonalID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Postalcode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string InvNumber { get; set; }
        public string Model { get; set; }
        public string County { get; set; }
        public int RAM { get; set; }
        public string Color { get; set; }
        public int DailyFee { get; set; }
        public int Deposit { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool UseDeposit { get; set; }
        public double Uptime { get; set; }


        public Rental() { }

        
        public List<Rental> Begyujt(string fajlhely)
        {
            StreamReader olvaso = new StreamReader(fajlhely);
            var header = olvaso.ReadLine();
            List<Rental> adatok = new List<Rental>();
            
            while (!olvaso.EndOfStream)
            {
                string sor = olvaso.ReadLine();
                string[] soradatok = sor.Split(";");
                Rental egyadat = new Rental();

                egyadat.PersonalID = soradatok[0];
                egyadat.Name = soradatok[1];
                egyadat.DateOfBirth = Convert.ToDateTime(soradatok[2]);
                egyadat.Postalcode = Convert.ToInt32(soradatok[3]);
                egyadat.City = soradatok[4];
                egyadat.Address = soradatok[5];
                
                egyadat.InvNumber = soradatok[6];
                egyadat.Model = soradatok[7];
                egyadat.County = soradatok[8];
                egyadat.RAM = Convert.ToInt32(soradatok[9]);
                egyadat.Color = soradatok[10];
                egyadat.DailyFee = Convert.ToInt32(soradatok[11]);
                egyadat.Deposit = Convert.ToInt32(soradatok[12]);
                
                egyadat.StartDate = Convert.ToDateTime(soradatok[13]);
                egyadat.EndDate = Convert.ToDateTime(soradatok[14]);
                //egyadat.UseDeposit = Convert.To(soradatok[15]);
                egyadat.Uptime = Convert.ToDouble(soradatok[16]);

                adatok.Add(egyadat);
            }

            return adatok;
        }
    }
}
