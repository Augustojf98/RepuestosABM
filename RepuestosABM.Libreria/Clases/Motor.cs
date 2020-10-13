using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class Motor : Categoria
    {
        public Motor()
        {
            this._codigo = 4;
            this._nombre = "Motor";
        }

        public override string GetDetalleCategoria()
        {
            return string.Format("({0} - {1})", this._codigo, this._nombre);
        }
    }
}
