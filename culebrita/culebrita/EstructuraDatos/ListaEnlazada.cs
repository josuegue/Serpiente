using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.EstructuraDatos
{
    public class ListaEnlazada<Point>
    {
        public Nodo raiz;

        public ListaEnlazada()
        {
            this.raiz = null;
        }
        
        public void Insertar(Point dto)
        {
            raiz = new Nodo(dto, raiz);
        }

        //Metodo Eliminar aun por definir, por esto no funciona correctamente
        public void Eliminar()
        {
            Nodo actual;
            actual = raiz.enlace;
            raiz = actual;
        }

        //Metodo que me retorna mi ultimo elemento 
        public Point Last()
        {
            Point retorno = default;
            Nodo nodo = this.raiz;
            while (nodo != null)
            {
                if (nodo.enlace == null) retorno = (Point)nodo.dato;
                nodo = nodo.enlace;
            }
            return retorno;
        }

        // Metodo que me recibe una funcion anonima, y que me compara el dato de mi listaCola con la variable p, que es un parametro
        // el Bool, es una variable de Ouput
        public bool Any(Point p)
        {
            Nodo nod = raiz;
            var comparador = (raiz != null);
            if (comparador) return true;

            while(nod != null)
            {
                comparador =(nod.dato.Equals(p)); 
                nod = nod.enlace;
            }
            return comparador;
        }

        //Cuenta los valores introducidos en mi array
        public int Count()
        {
            int count = 0;
            Nodo node = raiz;
            while (node != null)
            {
                count++;
                node = node.enlace;
            }
            return count;
        }

        public bool All(Point p)
        {
            Nodo node = raiz;
            var verificador = (raiz == null);
            if(verificador) return true;

            while (node != null)
            {
                verificador = (node.dato.Equals(p));
                node = node.enlace;
            }
            return verificador;
        }
    }
}

