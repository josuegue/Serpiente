using culebrita.ClassSnake;
using culebrita.EstructuraDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using culebrita.SnakeModificada;

namespace culebrita
{
    class Program
    {

        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando

        //modificar el uso de queue y reemplazarlo con la estructura de cola vista en clase
        //colalinal arreglo
        //cola arraylist
        //cola lista enlazada

        // explicar qué pasa al alterar cada una de las lineas marcadas con las preguntas
        // se aprecia si pueden cambiar las reglas del juego o si le agrega cosas extra

        internal enum Direction {Abajo, Izquierda, Derecha, Arriba}


        static void Main()
        {
            //StartGame();
            StartGameColaCircular();
            //StartGameColaLineal();
            //StartGameListaEnlazada();
        }

        private static void StartGame()
        {
            var soundPlyaer = new SoundPlayer(@"C:\Users\click\Downloads\coinMarioBross (mp3cut.net).wav");
            int punteo = 0; // Variable para mi punteo 
            int velocidad = 112; //Variable la velociadd
            var posicionComida = Point.Empty; // pocicion de la comida
            var pantalla = new Size(60, 20); //tamano de la patalla
            var snake = new Queue<Point>(); //My snake
            var longitudSnake = 10; // largo de la snake al inicio
            var posicionInicio = new Point(0, 13); // Inicio de la snake en pantalla
            var direccion = Direction.Derecha; // Direccion que toma el snake al inicio
            

            var objSnake = new GameSnake(pantalla, snake, posicionInicio);
            var objPantalla = new WindowSnake(pantalla, punteo);

            objPantalla.dibujaPantalla();
            objPantalla.mostrarPunteo(punteo);

            while (objSnake.MoverLaCulebrita(posicionInicio,longitudSnake))
            {
                Thread.Sleep(velocidad);
                 direccion = (Direction)objSnake.ObtieneDireccion((GameSnake.Direction)direccion);
                posicionInicio = objSnake.ObtieneSiguienteDireccion((GameSnake.Direction)direccion, posicionInicio);

                if (posicionInicio.Equals(posicionComida))
                {
                    soundPlyaer.Play();
                    posicionComida = Point.Empty;
                    longitudSnake++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                    //Este if me sirve para incrementar la velocidad de la snake 
                    if(punteo >= 10 && velocidad >=1)
                    {
                        velocidad -= 3;
                    }
                    objPantalla.mostrarPunteo(punteo);

                }
                if(posicionComida == Point.Empty)
                {
                    posicionComida = objSnake.MostrarComida();
                }
            }
            int uno = 1;
            Console.ResetColor();
            Console.SetCursorPosition(pantalla.Width / 2 - 4, pantalla.Height / 2);
            Console.Write("Fin del Juego.");
            Thread.Sleep(2000);
            Console.ReadKey();

        }
        private static void StartGameColaCircular()
        {
            var soundPlyaer = new SoundPlayer(@"C:\Users\click\Downloads\coinMarioBross (mp3cut.net).wav");
            int punteo = 0; // Variable para mi punteo 
            int velocidad = 112; //Variable la velociadd
            var posicionComida = Point.Empty; // pocicion de la comida
            var pantalla = new Size(60, 20); //tamano de la patalla
            var snake = new ColaCircular<Point>();//My snake
            var longitudSnake = 3; // largo de la snake al inicio
            var posicionInicio = new Point(0, 13); // Inicio de la snake en pantalla
            var direccion = Direction.Derecha; // Direccion que toma el snake al inicio


            var objSnake = new SnakeColaCircular(pantalla, snake,posicionInicio);
            var objPantalla = new WindowSnake(pantalla, punteo);

            objPantalla.dibujaPantalla();
            objPantalla.mostrarPunteo(punteo);

            while (objSnake.MoverLaCulebrita(posicionInicio, longitudSnake))
            {
                Thread.Sleep(velocidad);
                direccion = (Direction)objSnake.ObtieneDireccion((SnakeColaCircular.Direction)direccion);
                posicionInicio = objSnake.ObtieneSiguienteDireccion((SnakeColaCircular.Direction)direccion, posicionInicio);

                if (posicionInicio.Equals(posicionComida))
                {
                    soundPlyaer.Play();
                    posicionComida = Point.Empty;
                    longitudSnake++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                    //Este if me sirve para incrementar la velocidad de la snake 
                    if (punteo >= 10 && velocidad >= 1)
                    {
                        velocidad -= 3;
                    }
                    objPantalla.mostrarPunteo(punteo);

                }
                if (posicionComida == Point.Empty)
                {
                    posicionComida = objSnake.MostrarComida();
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(pantalla.Width / 2 - 4, pantalla.Height / 2);
            Console.Write("Fin del Juego.");
            Thread.Sleep(2000);
            Console.ReadKey();

        }
        private static void StartGameColaLineal()
        {
            var soundPlyaer = new SoundPlayer(@"C:\Users\click\Downloads\coinMarioBross (mp3cut.net).wav");
            int punteo = 0; // Variable para mi punteo 
            int velocidad = 112; //Variable la velociadd
            var posicionComida = Point.Empty; // pocicion de la comida
            var pantalla = new Size(60, 20); //tamano de la patalla
            var snake = new ColaLineal<Point>(); //My snake
            var longitudSnake = 3; // largo de la snake al inicio
            var posicionInicio = new Point(0, 13); // Inicio de la snake en pantalla
            var direccion = Direction.Derecha; // Direccion que toma el snake al inicio


            var objSnake = new SnakeColaLineal(pantalla, snake, posicionInicio);
            var objPantalla = new WindowSnake(pantalla, punteo);

            objPantalla.dibujaPantalla();
            objPantalla.mostrarPunteo(punteo);

            while (objSnake.MoverLaCulebrita(posicionInicio, longitudSnake))
            {
                Thread.Sleep(velocidad);
                direccion = (Direction)objSnake.ObtieneDireccion((SnakeColaLineal.Direction)direccion);
                posicionInicio = objSnake.ObtieneSiguienteDireccion((SnakeColaLineal.Direction)direccion, posicionInicio);

                if (posicionInicio.Equals(posicionComida))
                {
                    soundPlyaer.Play();
                    posicionComida = Point.Empty;
                    longitudSnake++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                    //Este if me sirve para incrementar la velocidad de la snake 
                    if (punteo >= 10 && velocidad >= 1)
                    {
                        velocidad -= 3;
                    }
                    objPantalla.mostrarPunteo(punteo);

                }
                if (posicionComida == Point.Empty)
                {
                    posicionComida = objSnake.MostrarComida();
                }
            }
            int uno = 1;
            Console.ResetColor();
            Console.SetCursorPosition(pantalla.Width / 2 - 4, pantalla.Height / 2);
            Console.Write("Fin del Juego.");
            Thread.Sleep(2000);
            Console.ReadKey();

        }
        private static void StartGameListaEnlazada()
        {
            var soundPlyaer = new SoundPlayer(@"C:\Users\click\Downloads\coinMarioBross (mp3cut.net).wav");
            int punteo = 0; // Variable para mi punteo 
            int velocidad = 112; //Variable la velociadd
            var posicionComida = Point.Empty; // pocicion de la comida
            var pantalla = new Size(60, 20); //tamano de la patalla
            var snake = new ListaEnlazada<Point>(); //My snake
            var longitudSnake = 3; // largo de la snake al inicio
            var posicionInicio = new Point(0, 13); // Inicio de la snake en pantalla
            var direccion = Direction.Derecha; // Direccion que toma el snake al inicio


            var objSnake = new SnakeListaEnlazada(pantalla, snake, posicionInicio);
            var objPantalla = new WindowSnake(pantalla, punteo);

            objPantalla.dibujaPantalla();
            objPantalla.mostrarPunteo(punteo);

            while (objSnake.MoverLaCulebrita(posicionInicio, longitudSnake))
            {
                Thread.Sleep(velocidad);
                direccion = (Direction)objSnake.ObtieneDireccion((SnakeListaEnlazada.Direction)direccion);
                posicionInicio = objSnake.ObtieneSiguienteDireccion((SnakeListaEnlazada.Direction)direccion, posicionInicio);

                if (posicionInicio.Equals(posicionComida))
                {
                    soundPlyaer.Play();
                    posicionComida = Point.Empty;
                    longitudSnake++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                    //Este if me sirve para incrementar la velocidad de la snake 
                    if (punteo >= 10 && velocidad >= 1)
                    {
                        velocidad -= 3;
                    }
                    objPantalla.mostrarPunteo(punteo);

                }
                if (posicionComida == Point.Empty)
                {
                    posicionComida = objSnake.MostrarComida();
                }
            }
            int uno = 1;
            Console.ResetColor();
            Console.SetCursorPosition(pantalla.Width / 2 - 4, pantalla.Height / 2);
            Console.Write("Fin del Juego.");
            Thread.Sleep(2000);
            Console.ReadKey();

        }


    }//end class
}













