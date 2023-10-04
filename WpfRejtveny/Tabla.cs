using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfRejtveny
{
    internal class Tabla
    {
        byte[,] terulet;

        public Tabla(byte[,] matrix)
        {
            terulet = matrix;
        }

        public byte[,] Terulet { get => terulet; }
    }
}
