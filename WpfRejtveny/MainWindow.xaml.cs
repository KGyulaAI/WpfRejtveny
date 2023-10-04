using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRejtveny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tabla feladvany;
        Button[,] teruletMezoi;
        public MainWindow()
        {
            InitializeComponent();
            RejtvenyBeolvasas();
        }

        private void RejtvenyBeolvasas()
        {
            OpenFileDialog fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                var fajlSorai = File.ReadAllLines(fajl.FileName);
                byte[,] beMatrix = new byte[fajlSorai.Length, fajlSorai[0].Split().Count()];
                int x = 0;
                foreach (var sor in File.ReadAllLines(fajl.FileName))
                {
                    int y = 0;
                    foreach (var mezo in sor.Split())
                    {
                        beMatrix[x, y++] = byte.Parse(mezo);
                    }
                    x++;
                }
                feladvany = new Tabla(beMatrix);
            }
            else
            {
                MessageBox.Show("Nem választott fájlt!");
            }
            TeruletKirajzolasa(feladvany);
        }

        private void TeruletKirajzolasa(Tabla feladvany)
        {
            teruletMezoi = new Button[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    teruletMezoi[i, j] = new Button();
                    teruletMezoi[i, j].Content = feladvany.Terulet[i, j];
                }
            }
        }
    }
}
