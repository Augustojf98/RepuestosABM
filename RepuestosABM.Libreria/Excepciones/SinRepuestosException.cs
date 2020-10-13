using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Excepciones
{
    public class SinRepuestosException : Exception
    {
        public SinRepuestosException():base("No hay repuestos cargados en el sistema aún.")
        {

        }
    }
    public class SinStockException : Exception
    {
        public SinStockException(int codigo) : base(string.Format("No hay stock para el repuesto de código {0}.", codigo))
        {

        }

        public SinStockException(int codigo, int cantidadRestante) : base(string.Format("No hay suficiente stock para el repuesto de código {0}. El stock restante es de {1} unidad(es).", codigo, cantidadRestante))
        {

        }
    }
}
