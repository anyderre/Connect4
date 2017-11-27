using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class Program
    {
        public static Jugador jugador1= new Jugador("Dany");
        public static Jugador jugador2= new Jugador("Ridore");
        public static Juego juego = new Juego(); 
        public static void Main(string[] args)
        {
            //Creando el tablero                    
            Program.juego.Tablero = new Tablero();
            Char[,] tabla = new Char[8, 9];
            for (int i = 1; i<=6; i++)
            {
                for (int j = 1; j <= 7; j++) {
                    tabla[i, j] = '-';
                }
            }
            Program.juego.Tablero.EstructuraTablero = tabla;//Creando la estructura del tablero
            Program.juego.Tablero.Jugadas = new List<Jugada>();// Creando una nueva lista de jugadas para el juego
            //Creando los dos tipos de monedas del juego
            Moneda tipomoneda1 = new Moneda('O');
            Moneda tipomoneda2 = new Moneda('C');
            //Creando la lista de monedas de los jugadores del juego
            List<Moneda> monedasJugador1 = new List<Moneda>();
            List<Moneda> monedasJugador2 = new List<Moneda>();
            for (int i = 0; i < 21; i++) {
               monedasJugador1.Add(tipomoneda1);
               monedasJugador2.Add(tipomoneda2);
            }
            //Anadiendo las monedas a sus jugadores especificos
            jugador1.Monedas = monedasJugador1;
            jugador2.Monedas= monedasJugador2;
            
            bool turno =true; // Turno de los dos jugadores
            bool gameOver=false; // Especifica si el juego ha terminado
                  
            int contadorJugador1 = 0;
            int contadorJugador2 = 0;
            while (!gameOver){
               
                if (turno)
                {
                    Console.WriteLine("Turno jugador 1");                 
                    char key = Console.ReadKey().KeyChar;
                    Console.Write("\b \b"); //limpiar el caracter justamente entrado
                    while (!char.IsDigit(key) || (char)Char.GetNumericValue(key) <1 ||   (char)Char.GetNumericValue(key)>7)
                    {
                        Console.WriteLine("\nDebes entrar un numero entre 1 y 7");
                        key=Console.ReadKey().KeyChar;
                        Console.Write("\b \b"); //limpiar el caracter justamente entrado
                    }
                    int integerKeyPressed = (char)Char.GetNumericValue(key);

                    Jugada nuevaJugada = new Jugada();//Creando una nueva jugada                  
                    nuevaJugada.JUGADOR = jugador1;
                    nuevaJugada.Moneda = tipomoneda1;
                    jugador1.Monedas.RemoveAt(jugador1.Monedas.Count - 1);
                    turno = false;                   
                    crearTabla(nuevaJugada, integerKeyPressed);
                    contadorJugador1++;
                    bool resultadoJugador1 = false;
                    if (contadorJugador1 >= 4) {
                  
                         resultadoJugador1= chequearJuego(nuevaJugada);
                         Console.WriteLine(resultadoJugador1);
                    }
                    if (resultadoJugador1)
                    {
                        Console.WriteLine("jugador 1 gana");
                        gameOver = true;
                    }
                }
                else{
                    Console.WriteLine("Turno jugador 2");
                    char key = Console.ReadKey().KeyChar;
                    Console.Write("\b \b"); //limpiar el caracter justamente entrado
                    while ((!char.IsDigit(key) || (char)Char.GetNumericValue(key) <1 || (char)Char.GetNumericValue(key)>7))
                    {
                        Console.WriteLine("\nDebes entrar un numero entre 1 y 7");
                        key = Console.ReadKey().KeyChar;
                        Console.Write("\b \b"); //limpiar el caracter justamente entrado
                    }
                    int integerKeyPressed = (char)Char.GetNumericValue(key);

                    Jugada nuevaJugada = new Jugada();//Creando una nueva jugada                  
                    nuevaJugada.JUGADOR = jugador2;
                    nuevaJugada.Moneda = tipomoneda2;
                    jugador2.Monedas.RemoveAt(jugador2.Monedas.Count - 1);
                    turno = true;
                    crearTabla(nuevaJugada, integerKeyPressed);
                    contadorJugador2++;
                     bool resultadoJugador2=false;
                    if (contadorJugador2 >= 4)
                    {
                        resultadoJugador2= chequearJuego(nuevaJugada);
                        Console.WriteLine(resultadoJugador2);
                    }
                    if (resultadoJugador2) {
                        Console.WriteLine("jugador 2 gana");
                        gameOver = true;
                    }
                }                
            }
            Console.ReadKey();
        }
        private static bool chequearJuego(Jugada jugada)
        {
            Char[,] tabla = Program.juego.Tablero.EstructuraTablero;            
            int fila = 6, columna = 7;
            for (int i = fila; i >= 1; i--) {
                for (int j = 1; j <= columna; j++) {
                    if (tabla[i, j] != '-') {
                       
                        if (tabla[i, j] == jugada.Moneda.Letra) {
                            
                            for (int k = 1; k < 8; k++) {
                                switch (k)
                                {
                                    
                                    //horizontal derecha
                                    case 1:
                                      
                                        if(columna-j>=3){
                                           
                                            if(tabla[i,j]==tabla[i,j+1]&&tabla[i,j]==tabla[i,j+2]&&tabla[i,j]==tabla[i,j+3]){
                                                return true;
                                            }
                                        }
                                        
                                        break;
                                        //horizontal izquierda
                                         case 2:
                                             if(j-1>=3){
                                                 
                                            if(tabla[i,j]==tabla[i,j-1]&&tabla[i,j]==tabla[i,j-2]&&tabla[i,j]==tabla[i,j-3]){
                                                return true;
                                            }
                                        }
                                        break;
                                        // Vertical Abajo
                                         case 3:
                                            if(fila-i>=3){
                                                
                                                 if(tabla[i,j]==tabla[i+1,j] && tabla[i,j]==tabla[i+2,j] && tabla[i,j]==tabla[i+3,j]){
                                                    return true;
                                                }
                                            }
                                        break;
                                        //Vertical Arriba
                                         case 4:
                                             if(i-1>=3){
                                                 
                                                 if(tabla[i,j]==tabla[i-1,j] && tabla[i,j]==tabla[i-2,j] && tabla[i,j]==tabla[i-3,j]){
                                                    return true;
                                                }
                                            }
                                        break;
                                        //diagonal derecha arriba
                                         case 5:
                                             if(i-1>=3&&columna-j>=3){
                                               
                                                 if(tabla[i,j]==tabla[i-1,j+1] && tabla[i,j]==tabla[i-2,j+2]&&tabla[i,j]==tabla[i-3,j+3]){
                                                    return true;
                                                }
                                            }
                                        break;
                                         //diagonal izquierda arriba
                                          case 6:
                                             if(i-1>=3&&j-1>=3){
                                                
                                                 if(tabla[i,j]==tabla[i-1,j-1] && tabla[i,j]==tabla[i-2,j-2]&&tabla[i,j]==tabla[i-3,j-3]){
                                                    return true;
                                                }
                                            }
                                        break;
                                        //diagonal derecha abajo 
                                         case 7:
                                           
                                             if(fila-i>=3&&columna-j>=3){                                               
                                                 if(tabla[i,j]==tabla[i+1,j+1] && tabla[i,j]==tabla[i+2,j+2]&&tabla[i,j]==tabla[i+3,j+3]){
                                                    return true;
                                                }
                                            }
                                        break;
                                        //diagonal izquierda abajo
                                         case 8:  
                                             if(fila-i>=3&&j-1>=3){                                                 
                                                 if(tabla[i,j]==tabla[i+1,j-1] && tabla[i,j]==tabla[i+2,j-2]&&tabla[i,j]==tabla[i+3,j-3]){
                                                    return true;
                                                }
                                            }
                                        break;
                                    default:
                                        return false;
                                        

                                }
                            }
                        }
                    }
                }
            }
                return false;
        }
        private static void crearTabla( Jugada jugada, int key) {          
            Char[,] tabla = juego.Tablero.EstructuraTablero;
            int fila = 6, columna = 7;
            Console.Write(" ");
            Console.Write(" ");

            Console.Write("  1 2 3 4 5 6 7");
            Console.WriteLine();
            int posicionjugada=0;
            //bucle para verificar si hay algun valor en la columna
            for (int i= 1; i <= fila;i++ )
            {                
                if (tabla[i, key] != '-')
                {
                    //Console.WriteLine();
                    posicionjugada = i-1;
                    break;
                }
                else {
                    posicionjugada = fila;
                }               
            }
            
            //bucle para saber cuantas veces se va a bajar
            for (int i = 1; i <= posicionjugada; i++) {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Jugador 1: " + Program.jugador1.Nombre);
                Console.WriteLine("Jugador 2: " + Program.jugador2.Nombre);           
                Console.Write( "  1 2 3 4 5 6 7");
                Console.WriteLine();
              
                for (int x = 1; x <= fila; x++)
                {                  
                    Console.Write(x);
                    for (int j = 1; j <= columna; j++)
                    {
                                                                     
                            Console.Write("|");
                            if (key == j)
                            {                               
                                tabla[i, key] = jugada.Moneda.Letra;
                            }
                           
                                Console.Write(tabla[x, j]);
                                tabla[i - 1, key] = '-';
                            
                        }               
                    Console.Write("| \n");
                   
                }
               
                   
            }
                
             Program.juego.Tablero.Jugadas.Add(jugada);//agregando la nueva juagada al juego
             Program.juego.Tablero.EstructuraTablero = tabla;// agregando la tabla actualizada al juego   
        }
    
  }

    public class Jugador {
        private String nombre;
        private List<Moneda> monedas;
        public Jugador(String nombre) {
            this.nombre = nombre;
        }
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
        private Char[,] estructuraTablero;
        private List<Jugada> jugadas;

        public List<Jugada> Jugadas
        {
            get { return jugadas; }
            set { jugadas = value; }
        }
        

        public Char[,] EstructuraTablero
        {
            get { return estructuraTablero; }
            set {  estructuraTablero= value; }
        }
    }
    public class Moneda {
        private char letra;
        public Moneda(char letra) {
            this.letra = letra;
        }

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
        private Tablero tablero;

        public Tablero Tablero
        {
            get { return tablero; }
            set { tablero = value; }
        }
   
    }
}
