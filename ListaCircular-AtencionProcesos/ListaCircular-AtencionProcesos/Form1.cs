using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaCircular_AtencionProcesos
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Proceso proceso;
        Lista miLista;
        int ciclosVacio = 0;
        int procesosPendientes = 0;
        int ciclosPendientes = 0;
        int procesosAtendidos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            miLista = new Lista();
            simular();
            pendientes();
            txtMostrar.Text = ciclosVacio.ToString() + " Ciclos vacio, " + procesosPendientes.ToString() + " Procesos pendientes, " + ciclosPendientes.ToString() + " Ciclos pendientes, " + procesosAtendidos.ToString() + " Procesos atendidos";
        }

        public void simular()
        {
            Proceso temp = null;
            bool flag = false;
            for (int i = 0; i < 200; i++)
            {
                if (rand.Next(4) == 3)
                {
                    if (miLista.peek() == null)
                        flag = true;
                    else
                        flag = false;
                    proceso = new Proceso(rand.Next(4, 13));
                    miLista.agregar(proceso);
                    if (flag)
                        temp = miLista.peek();
                }
                if (miLista.peek() != null)
                {
                    temp.ciclos--;
                    if (temp.ciclos == 0)
                    {
                        miLista.eliminar(temp);
                        procesosAtendidos++;
                    }
                    if (miLista.peek() != null)
                        temp = temp.siguiente;
                }
                else
                    ciclosVacio++;
            }
        }

        public void pendientes()
        {
            Proceso temp = miLista.peek();
            while (temp.siguiente!=miLista.peek())
            {
                procesosPendientes++;
                ciclosPendientes += temp.ciclos;
                temp = temp.siguiente;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            miLista = new Lista();
        }
    }
}
