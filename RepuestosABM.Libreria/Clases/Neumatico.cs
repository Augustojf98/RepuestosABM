using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class Neumatico : Categoria
    {
        public Neumatico()
        {
            this._codigo = 3;
            this._nombre = "Neumático";
        }

        public override string GetDetalleCategoria()
        {
            return string.Format("({0} - {1})", this._codigo, this._nombre);
        }
    }
}
