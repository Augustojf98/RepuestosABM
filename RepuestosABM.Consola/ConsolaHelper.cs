using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Consola
{
    public static class ConsolaHelper
    {
        public static string PedirString(string mensaje)
        {
            Console.WriteLine("Ingrese " + mensaje);
            string s = Console.ReadLine();

            return s;
        }

        public static int PedirInt(string mensaje)
        {
            Console.WriteLine("Ingrese " + mensaje);
            int s = int.Parse(Console.ReadLine());

            return s;
        }

        public static double PedirDouble(string mensaje)
        {
            Console.WriteLine("Ingrese " + mensaje);
            double s = double.Parse(Console.ReadLine());

            return s;
        }

        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            try
            {
                if(!opcionesValidas.ToUpper().Contains(input.ToUpper()) || input.Length > 1 || string.IsNullOrEmpty(input))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
