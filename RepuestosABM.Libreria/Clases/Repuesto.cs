using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Clases
{
    public class Repuesto
    {
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;

        public Repuesto(int codigo, string nombre, double precio, int stock, string categoria)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
            this._stock = stock;

            switch (categoria.ToUpper())
            {
                case "N":
                    this._categoria = new Neumatico();
                break;
                case "M":
                    this._categoria = new Motor();
                break;
                case "V":
                    this._categoria = new Vidrio();
                break;
                case "C":
                    this._categoria = new Chapa();
                break;
                default:
                    throw new Exception("No existe la categoría ingresada");
            }
        }

        public int Codigo
        {
            get
            {
                return this._codigo;
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

        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }

        public int Stock
        {
            get
            {
                return this._stock;
            }
            set
            {
                this._stock = value;
            }
        }

        public Categoria Categoria
        {
            get
            {
                return this._categoria;
            }
        }

        public void RestarStock(int cantidadRestada)
        {
            if (this._stock > 0)
            {
                if (this._stock >= cantidadRestada)
                {
                    this._stock = this._stock - cantidadRestada;
                }
                else
                {
                    throw new Excepciones.SinStockException(this._codigo, this._stock);
                }
            }
            else
            {
                throw new Excepciones.SinStockException(this._codigo);
            }
        }

        public override bool Equals(object obj)
        {
            Repuesto repuestoExterno = (Repuesto)obj;

            return this._nombre == repuestoExterno._nombre && this._categoria.Codigo == repuestoExterno._categoria.Codigo;
        }

        public override string ToString()
        {
            return string.Format("({0}) {1} - ${2} c/u - {3} unidades", this._codigo, this._nombre, this._precio, this._stock);
        }

    }
}
