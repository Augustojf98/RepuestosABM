using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class Chapa : Categoria
    {
        public Chapa()
        {
            this._codigo = 2;
            this._nombre = "Chapa";
        }

        public override string GetDetalleCategoria()
        {
            return string.Format("({0} - {1})", this._codigo, this._nombre);
        }
    }
}
