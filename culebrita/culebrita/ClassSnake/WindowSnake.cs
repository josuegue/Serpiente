using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.ClassSnake
{
    public class WindowSnake
    {
        private Size tmPantalla;
        private int puntos;
        public WindowSnake(Size tamanioPantalla, int pts)
        {
            this.tmPantalla = tamanioPantalla;
            this.puntos = pts;

        }

        public void dibujaPantalla()
        {
            Console.Title = "GAME SNAKE";
            Console.WindowHeight = this.tmPantalla.Height + 2;
            Console.WindowWidth = this.tmPantalla.Width + 2;
            Console.BufferHeight = Console.WindowWidth;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            for (int row = 0; row < this.tmPantalla.Height; row++)
            {
                for (int col = 0; col < this.tmPantalla.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                
                }
            }
        }

        public void mostrarPunteo(int punteo)
        {
            this.puntos = punteo;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {this.puntos.ToString("00000000")}");
        }
    }
}
