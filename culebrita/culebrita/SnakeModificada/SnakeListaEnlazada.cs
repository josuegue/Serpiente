using culebrita.EstructuraDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeModificada
{
    public class SnakeListaEnlazada
    {
        //Variables 
        Size pantalla;
        ListaEnlazada<Point> snake;
        Point puntoInicio;
        
        //Referencia a mis direcciones
        public enum Direction { Abajo, Izquierda, Derecha, Arriba }

        //Constructor para crear a mi serpiente
        public SnakeListaEnlazada(Size tmPantalla, ListaEnlazada<Point> snk, Point pocisionInicio)
        {
            this.pantalla = tmPantalla;
            this.snake = snk;
            this.puntoInicio = pocisionInicio;
            this.snake.Insertar(puntoInicio);
        }



        public Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            // El objeto point representa un par ordenado de coordenadas x e y que definen
            // un punto en la pantalla
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }

        public Direction ObtieneDireccion(Direction direccionAcutal)
        {
            // KeyAvailable, obtiene un valor que indica si una tecla esta disponible en
            //el flujo de entrada
            if (!Console.KeyAvailable) return direccionAcutal;

            //El metodo hace que el programa espera a que se precione alguna tecla y evita la pantalla 
            // hasta que se precione una tecla. 
            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }

        public bool MoverLaCulebrita(Point posiciónObjetivo,
            int longitudCulebra)
        {
            var lastPoint = snake.Last();

            
            if (lastPoint.Equals(posiciónObjetivo)) return true;

            //Retorna true o false, pero como tiene el ! cambia el valor retornado
            if (!snake.Any((posiciónObjetivo))) return false;

            //Esta validacion hace que la culebrita no se salga de la pantalla, si se sale me retorna un false, sino un true.
            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= pantalla.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= pantalla.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            snake.Insertar(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // conteo de mis inserciones
            var cont = snake.Count();
            if (cont > longitudCulebra)
            {
                //remueve un nodo -------------- metodo aun por definir
                snake.Eliminar();
            }
            return true;
        }

        public Point MostrarComida()
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = snake.Last();
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, pantalla.Width - 1);
                var y = rnd.Next(0, pantalla.Height - 1);
                //Me verifica que mi punto p.x y p.y sea diferente a las coordenadas de donde estara mi comida
                // y la suma de (pocisionY - Cabeza culebra)+ (pocisionX - Cabeza culebra) con su Valor absoluto sea mayor a 8
                //Si no se cumple el if se vuelve a reiniciar el lugar de la comida a vacio y se reasignan las variables
                if (!snake.All(new Point(x,y))
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }
    }
}
