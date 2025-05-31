using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicas.Practica_4
{
    public partial class HilosConc : Form
    {
        int sumaTotal = 0;
        object lockObject = new object();

        public HilosConc()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLimite.Text, out int N) || N < 2)
            {
                MessageBox.Show("Ingrese un numero entero mayor o igual a 2.");
                return;
            }

            int M = 4;
            int rango = N / M;
            sumaTotal = 0;

            //Concurrencia
            Thread[] hilos = new Thread[M];
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < M; i++)
            {
                int inicio = i * rango + 1;
                int fin = (i == M - 1) ? N : inicio + rango - 1;
                hilos[i] = new Thread(CalcularPrimos);
                hilos[i].Start((inicio, fin));
            }
            foreach (var hilo in hilos)
            {
                hilo.Join();
            }
            stopwatch.Stop();

            lblResultadoConcurrente.Text = $"{sumaTotal}";
            lblTiempoConcurrente.Text = $"{stopwatch.ElapsedMilliseconds} ms";

            // Secuencial
            sumaTotal = 0;
            Stopwatch stopwatchSecuencial = Stopwatch.StartNew();
            CalcularPrimosSecuencial(1, N);
            stopwatchSecuencial.Stop();

            lblTiempoSecuencial.Text = $"{stopwatchSecuencial.ElapsedMilliseconds} ms";
        }

        void CalcularPrimos(object rango)
        {
            (int inicio, int fin) = ((int, int))rango;
            int suma = 0;
            for (int i = inicio; i <= fin; i++)
            {
                if (EsPrimo(i))
                {
                    suma += i;
                }
            }
            lock (lockObject)
            {
                sumaTotal += suma;
            }
        }

        bool EsPrimo(int numero)
        {
            if (numero < 2) return false;
            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        void CalcularPrimosSecuencial(int inicio, int fin)
        {
            int suma = 0;
            for (int i = inicio; i <= fin; i++)
            {
                if (EsPrimo(i))
                {
                    suma += i;
                }
            }
            sumaTotal += suma;
        }
    }
}
