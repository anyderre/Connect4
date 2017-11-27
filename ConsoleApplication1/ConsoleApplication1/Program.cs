using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    { private int [] arr;
        static void Main(string[] args)
        {

            Char[,] tabla = new Char[9, 10];
            crearTabla(tabla);
            Console.ReadKey();
        }
        private static void crearTabla(char[,] tabla) {
            int fila = 6, columna = 7;
            for (int i = 1; i <= fila; i++) {
               // Console.Write("|");
                for (int j = 1; j <= columna; j++) {
                    if (tabla[i, j] != 'Q' && tabla[i, j] != 'V')
                    {
                        tabla[i, j] = '-';
                        Console.Write("|");
                    }
                       
                    Console.Write(tabla[i,j]);
                }
                Console.Write("| \n"); 
            }
        }
       
    }

    public class Jugador {
        private String nombre;
        private List<Moneda> monedas;
       
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Moneda> Monedas
        {
            get { return monedas; }
            set { monedas= value; }
        }

    }

    public class Tablero {
        private List<Moneda> monedas;
        private int fila;
        private int columna;

        public int Fila
        {
            get { return columna; }
            set { columna = value; }
        }


        public int MyProperty
        {
            get { return fila; }
            set { fila = value; }
        }


        public List<Moneda> Monedas
        {
            get { return monedas; }
            set { monedas = value; }
        }


    }
    public class Moneda {
        private char letra;
    

        public char Letra
        {
            get { return letra; }
            set { letra = value; }
        }

    }
    public class Jugada {
        private Jugador judador;
        private Moneda moneda;

        public Moneda Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }


        public Jugador JUGADOR
        {
            get { return judador; }
            set { judador = value; }
        }

    }

    public class Juego {
        private List<Jugada> jugadas;

        public List<Jugada> Jugadas
        {
            get { return jugadas; }
            set { jugadas = value; }
        }

    }
}
