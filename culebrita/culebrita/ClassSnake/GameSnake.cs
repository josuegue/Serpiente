using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace culebrita.ClassSnake
{
    public class GameSnake
    {
        //Variables 
        Size pantalla;
        Queue<Point> snake;
        Point puntoInicio;

        //Referencia a mis direcciones
        public enum Direction { Abajo, Izquierda, Derecha, Arriba}

        //Constructor para crear a mi serpiente
        public GameSnake(Size tmPantalla, Queue<Point> snk, Point pocisionInicio)
        {
            this.pantalla = tmPantalla;
            this.snake = snk;
            this.puntoInicio = pocisionInicio;
            this.snake.Enqueue(this.puntoInicio);
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

            
            if (snake.Any(x => x.Equals(posiciónObjetivo))) return false;

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= pantalla.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= pantalla.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            snake.Enqueue(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (snake.Count > longitudCulebra)
            {
                var removePoint = snake.Dequeue();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
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
                var que_pasa = (snake.All(p => p.X != x || p.Y != y) && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8);
                if (snake.All(p => p.X != x || p.Y != y)
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
