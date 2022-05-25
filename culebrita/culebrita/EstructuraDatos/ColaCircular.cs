using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.EstructuraDatos
{
    public class ColaCircular<Point>
    {
        protected int fin;
        private static int MAXTM = 100;
        protected int frente;
        protected Object[] listaCola;

        private int siguiente(int r)
        {
            return (r + 1) % MAXTM;
        }

        public ColaCircular()
        {
            frente = 0;
            fin = MAXTM - 1;
            listaCola = new Object[MAXTM];
        }

        //Insercion de datos, y el if anidado que tiene lo que hace es que verifica si 
        //El array esta lleno, si esta lleno vuelve a reasignar fin a el tamano de MAXTM-1,
        //Se ubica a la primera pocision (indice 0) luego asigna ahi el nuevo dato que es elemento
        public void Insert(Point element)
        {
            // fin = siguiente(seguiente(fin)) es si esta lleno
            if (!(fin == siguiente(siguiente(fin))))
            {
                fin = siguiente(fin);
                listaCola[fin] = element;
            }
            if (fin == siguiente(siguiente(fin)))
            {
                fin = MAXTM - 1;
                fin = siguiente(fin);
                listaCola[fin] = element;
            }
        }

        /*** 
         * Metodo que retorna un punto eliminado.
         * Como el frente se incrementa para sacar datos, y donde los saca es null
         * se llega al final del array, entonces lo que hace el if anidado. Es, si frente == MAXTM,
         * Frente se vuelve a iniciar a 0, para seguir sacando datos y asi puedo usar 
         * esta estructura de datos para poder procesar la culebrita
         * */
        public Point Quitar()
        {
            // frente = seguiente(fin) es si esta vacio
            if (!(frente == siguiente(fin)))
            {
                var eliminado = listaCola[frente];
                listaCola[frente] = null;
                frente++;
                if(frente == MAXTM) frente = 0;
                return (Point)eliminado;
            }

            return default;
        }

        //Metodo que me retorna mi ultimo elemento 
        public Point Last()
        {
            // En el frente esta mi ultimo elemento porque los datos se insertan al final y el frente es donde salen
            //Osea FIFO, First Input, First Ouput
            return (Point)listaCola[frente];
        }

        // Metodo booleano, que me recibe un dato tipo Point y me va comparando si hay una coincidencia con mi array
        //Aparte de eso si mi array tiene datos, entonces retorna true
        // Y si existe una coincidencia de datos pues retorna true;
        public bool Any(Point pocision)
        {
            
            var encontrado = !(frente == siguiente(fin));
            if (encontrado) return true;

            foreach (Object o in listaCola)
            {
                if(o != null)
                {
                    encontrado = (o.Equals(pocision)) ? true : false;
                }
            }
            return encontrado;
        }

        //Cuenta los valores introducidos en mi array
        public int Count()
        {
            int count = 0;
            foreach (Object o in listaCola)
            {
                if (o != null) count++; 
            }
            return count;
        }

        // Metodo All, tipo booleano. Entrada como parametro un point, 
        //Me retorna true si el array esta vacio 
        // Y si existe alguna coincidencia me retorna true
        public bool All(Point punto)
        {
            
            var all = (frente == siguiente(fin));
            if (all) return true;

            for(int i = 0; i<listaCola.Length; i++)
            {
                if(listaCola[i] != null)
                {
                    all = (listaCola[i].Equals(punto)) ? true : false;
                }
            }
            return all;
        }

    }
}
