using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class Vidrio : Categoria
    {
        public Vidrio()
        {
            this._codigo = 1;
            this._nombre = "Vidrio";
        }

        public override string GetDetalleCategoria()
        {
            return string.Format("({0} - {1})", this._codigo, this._nombre);
        }
    }
}
