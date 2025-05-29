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
            List<Rent> adatok = new List<Rent>();
            List<Laptop> laptopok = new List<Laptop>();

            while (!olvaso.EndOfStream)
            {
                string sor = olvaso.ReadLine();
                Rent egyadat = new Rent(sor);
                adatok.Add(egyadat);
                Laptop egylaptop = new Laptop(sor);
                laptopok.Add(egylaptop);
            }

            olvaso.Close();

            LaptopListView.ItemsSource = adatok;
        }
    }
}