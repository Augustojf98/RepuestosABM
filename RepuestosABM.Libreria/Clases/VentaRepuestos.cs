using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class VentaRepuestos
    {
        private List<Repuesto> _listaProductos;
        private string _nombreComercio;
        private string _direccion;

        public string Nombre
        {
            get
            {
                return this._nombreComercio;
            }
        }

        public string Direccion
        {
            get
            {
                return this._direccion;
            }
        }

        public List<Repuesto> ListaProductos
        {
            get
            {
                return this._listaProductos;
            }
        }

        public VentaRepuestos(string nombre, string direccion)
        {
            this._nombreComercio = nombre;
            this._direccion = direccion;
            this._listaProductos = new List<Repuesto>();
        }

        public bool TieneRepuestos
        {
            get
            {
                return this._listaProductos.Count > 0;
            }
        }

        public void AgregarRepuesto(string nombre, double precio, int stock, string categoria)
        {
            Repuesto repuesto = new Repuesto(NuevoCodigo, nombre, precio, stock, categoria);

            foreach(Repuesto r in _listaProductos)
            {
                if (r.Equals(repuesto))
                {
                    throw new Excepciones.RepuestoExistenteException(r.Codigo);
                }
            }

            this._listaProductos.Add(repuesto);

        }

        public void EditarRepuesto(int codigo, string nombre, double precio, int stock, string categoria)
        {
            Repuesto repuesto = BuscarPorCodigo(codigo);

            if(repuesto != null)
            {
                this._listaProductos.Remove(repuesto);
                this._listaProductos.Add(new Repuesto(codigo, nombre, precio, stock, categoria));
            }
            else
            {
                throw new Excepciones.RepuestoInexistenteException(codigo);
            }

        }

        public void QuitarRepuesto(int codigo)
        {
            Repuesto repuesto = this.BuscarPorCodigo(codigo);
            if(repuesto != null)
            {
                if(repuesto.Stock == 0)
                {
                    this._listaProductos.Remove(repuesto);
                }
                else
                {
                    throw new Exception("El repuesto aún tiene stock.");
                }
            }
            else
            {
                throw new Excepciones.RepuestoInexistenteException(codigo);
            }
        }

        public void AgregarStock(int codigo, int stockAgregado)
        {
            Repuesto repuesto = BuscarPorCodigo(codigo);
            if(repuesto != null)
            {
                repuesto.Stock = repuesto.Stock + stockAgregado;
            }
            else
            {
                throw new Excepciones.RepuestoInexistenteException(codigo);
            }
        }

        public void QuitarStock(int codigo, int stockRestado)
        {
            Repuesto repuesto = BuscarPorCodigo(codigo);
            if (repuesto != null)
            {
                repuesto.RestarStock(stockRestado);
            }
            else
            {
                throw new Excepciones.RepuestoInexistenteException(codigo);
            }
        }

        public Repuesto BuscarPorCodigo(int codigo)
        {
            if (TieneRepuestos)
            {
                foreach(Repuesto repuesto in _listaProductos)
                {
                    if(repuesto.Codigo == codigo)
                    {
                        return repuesto;
                    }
                    return null;
                }
                return null;
            }
            else
            {
                throw new Excepciones.SinRepuestosException();
            }
        }

        public int NuevoCodigo
        {
            get
            {
                if (TieneRepuestos)
                {
                    return UltimoCodigo + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int UltimoCodigo
        {
            get
            {
                return this._listaProductos.Count;
            }
        }
    }
}
