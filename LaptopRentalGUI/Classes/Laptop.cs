﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalGUI.Classes
{
    internal class Laptop
    {
        public string InvNumber { get; set; }
        public string Model { get; set; }
        public string County { get; set; }
        public int RAM { get; set; }
        public string Color { get; set; }
        public int DailyFee { get; set; }
        public int Deposit { get; set; }
        public int NumberOfRents { get; set; }

        public Laptop(string invnumber, string model, string country, int ram, string color, int dailyfee, int deposit, int numberofrents)
        {
            this.InvNumber = invnumber;
            this.Model = model;
            this.County = country;
            this.RAM = ram;
            this.Color = color;
            this.DailyFee = dailyfee;
            this.Deposit = deposit;
            this.NumberOfRents = numberofrents;
        }

        public Laptop(string sor, List<Rent> adatok)
        {
            string[] soradatok = sor.Split(";");

            this.InvNumber = soradatok[6];
            this.Model = soradatok[7];
            this.County = soradatok[8];
            this.RAM = Convert.ToInt32(soradatok[9]);
            this.Color = soradatok[10];
            this.DailyFee = Convert.ToInt32(soradatok[11]);
            this.Deposit = Convert.ToInt32(soradatok[12]);
            int nor = 0;
            foreach (Rent adat in adatok)
            {
                if (adat.Laptop.InvNumber == this.InvNumber)
                {
                    nor++;
                }
            }
            this.NumberOfRents = nor;
        }
    }
}
