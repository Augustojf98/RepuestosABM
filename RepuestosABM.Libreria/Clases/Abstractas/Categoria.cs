using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public abstract class Categoria
    {
        protected int _codigo;
        protected string _nombre;

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public abstract string GetDetalleCategoria();

        public override string ToString()
        {
            return this.GetDetalleCategoria();
        }
    }
}
