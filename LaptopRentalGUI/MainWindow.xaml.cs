using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaptopRentalGUI.Classes;

namespace LaptopRentalGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StreamReader olvaso = new StreamReader("../../../laptoprentals2022.csv");
            olvaso.ReadLine(); //fejléc
            List<string> sorok = new List<string>(); //sorok a laptop lista feltöltéséhez
            List<Rent> adatok = new List<Rent>(); //az alap adatokat tartalmazó lista, a laptopok nem tartalmaznak 'bérlés mennyisége' adatot
            List<Laptop> laptopok = new List<Laptop>(); //a laptopok adatait tartalmazó lista, tartalmazzák a 'bérlés mennyisége' adatot

            while (!olvaso.EndOfStream)
            {
                string sor = olvaso.ReadLine();
                Rent egyadat = new Rent(sor);
                adatok.Add(egyadat);
                sorok.Add(sor);
            }
            
            olvaso.Close();

            foreach (string sor in sorok)
            {
                string[] soradatok = sor.Split(";");
                bool vanmar = false;

                foreach (Laptop laptop in laptopok)
                {
                    if (laptop.InvNumber == soradatok[6])
                    {
                        vanmar = true;
                    }
                }

                if (!vanmar)
                {
                    Laptop egylaptop = new Laptop(sor, adatok);
                    laptopok.Add(egylaptop);
                }
            }

            LaptopListView.ItemsSource = laptopok;

            Inv.Text = "LTP000000";
            Mdl.Text = "Modell";
            RAM.Text = "0";
            Clr.Text = "Szín";
            Dlf.Text = "0 Ft";
            Dep.Text = "0 Ft";
            RtN.Text = "0";
        }

        private void AdatMegjelenit(object sender, SelectionChangedEventArgs e)
        {
            var aKivalasztott = LaptopListView.SelectedItem as Laptop;
            if (aKivalasztott != null)
            {
                Inv.Text = aKivalasztott.InvNumber;
                Mdl.Text = aKivalasztott.Model;
                RAM.Text = $"{aKivalasztott.RAM} GB";
                Clr.Text = aKivalasztott.Color;
                Dlf.Text = $"{aKivalasztott.DailyFee} Ft";
                Dep.Text = $"{aKivalasztott.Deposit} Ft";
                RtN.Text = Convert.ToString(aKivalasztott.NumberOfRents);
            }
            else
            {
                Inv.Text = "LTP000000";
                Mdl.Text = "Modell";
                RAM.Text = "0";
                Clr.Text = "Szín";
                Dlf.Text = "0 Ft";
                Dep.Text = "0 Ft";
                RtN.Text = "0";
            }
        }
    }
}