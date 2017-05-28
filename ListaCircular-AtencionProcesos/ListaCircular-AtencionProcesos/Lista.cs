using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircular_AtencionProcesos
{
    class Lista
    {
        public Proceso inicio { get; set; }

        public Lista()
        {
            inicio = null;
        }


        /// <summary>
        /// Agrega a la lista el elemento especificado
        /// </summary>
        /// <param name="nuevo">Objeto de la clase Proceso</param>
        public void agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.siguiente = inicio;
            }
            else
                agregar(inicio, nuevo);
        }

        private void agregar(Proceso ultimo, Proceso nuevo)
        {
            if (ultimo.siguiente == inicio)
            {
                nuevo.siguiente = inicio;
                ultimo.siguiente = nuevo;
            }
            else
                agregar(ultimo.siguiente, nuevo);
        }

        /// <summary>
        /// Elimina de la lista el elemento especificado
        /// </summary>
        /// <param name="proceso">Objeto de la clase Proceso</param>
        public void eliminar(Proceso proceso)
        {
            if (proceso == inicio)
            {
                if (inicio.siguiente == inicio)
                    inicio = null;
                else
                    inicio = inicio.siguiente;
            }
            else
            {
                Proceso temp = inicio;
                while (proceso != temp.siguiente)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = temp.siguiente.siguiente;
            }
        }

        /// <summary>
        /// Regresa el primer elemento de la lista
        /// </summary>
        /// <returns></returns>
        public Proceso peek()
        {
            return inicio;
        }

        public override string ToString()
        {
            return inicio.ToString();
        }
    }
}
