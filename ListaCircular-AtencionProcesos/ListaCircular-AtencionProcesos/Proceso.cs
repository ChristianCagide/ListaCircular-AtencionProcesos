using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircular_AtencionProcesos
{
    class Proceso
    {
        public int ciclos { get; set; }

        /// <summary>
        /// Siguiente elemento de la lista
        /// </summary>
        public Proceso siguiente { get; set; }

        public Proceso(int rand)
        {
            ciclos = rand;
            siguiente = null;
        }

        public override string ToString()
        {
            return ciclos.ToString();
        }
    }
}
