using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Libreria.Excepciones
{
    public class RepuestoInexistenteException : Exception
    {
        public RepuestoInexistenteException(int codigo):base(string.Format("El repuesto de código {0} no existe.", codigo))
        {

        }
    }

    public class RepuestoExistenteException : Exception
    {
        public RepuestoExistenteException(int codigo) : base(string.Format("El repuesto de código {0} ya existe.", codigo))
        {

        }
    }
}
