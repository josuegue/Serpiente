using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.EstructuraDatos
{
    public class ColaLineal<Point>
    {
        protected int fin;
        private static int MAXTM = 200;
        protected int frente;
        protected Object[] listaCola;

        public ColaLineal()
        {
            this.frente = 0;
            this.fin = 0;
            this.listaCola = new Object[MAXTM];
        }

        public void Insert(Point element)
        {
            if (!(fin == MAXTM))
            {
                this.listaCola[fin] = element;
                fin++;
            }
            if(fin == MAXTM) fin = 0;
        }

        //Metodo que me quita una pocision de mi array
        public Point Quitar()
        {
            if (fin != frente)
            {
                var eliminado = listaCola[frente];
                listaCola[frente]= null;
                frente++;
                if (frente == MAXTM) frente = 0;
                return (Point)eliminado;
            }
            
            return default(Point);
        }

        //Metodo que me retorna mi ultimo elemento 
        public Point Last()
        {
            // en el frente esta mi ultimo elemnto porque los datos se insertan al final y el frente es donde salen
            //Osea FIFO, First Input, First Ouput
            return (Point)listaCola[frente];
        }

        // Metodo booleano, que me recibe un dato tipo Point y me va comparando si hay una coincidencia con mi array
        //Aparte de eso si mi array tiene datos, entonces retorna true
        // Y si existe una coincidencia de datos pues retorna true;
        public bool Any(Point p)
        {
            var encontrado = !(frente == fin);
            if (encontrado) return true;
            foreach (Object o in listaCola)
            {
                if(o != null)
                {
                    encontrado = (o.Equals(p)) ? true : false;
                }
            }
            return encontrado;
        }

        //Cuenta los valores introducidos en mi array
        public int Count()
        {
            int count = 0;
            foreach(Object o in listaCola)
            {
                if (o != null) count++;
            }
            return count;
        }

        // Metodo All, tipo booleano. Entrada como parametro un point, 
        //Me retorna true si el array esta vacio 
        // Y si existe alguna coincidencia me retorna true
        public bool All(Point p)
        {
            var encontrado = (frente == fin);
            if(encontrado) return true;

            foreach(Object o in listaCola)
            {
                if(o != null)
                {
                    encontrado = (o.Equals(p)) ? true : false;
                }
            }
            return encontrado;
        }
    }


}
