using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita
{
    public class Nodo
    {
        public Object dato;
        public Nodo enlace;

        public Nodo(Object dto)
        {
            this.dato = dto;
            this.enlace = null;

        }
        public Nodo(Object dto, Nodo nd)
        {
            this.dato = dto;
            this.enlace = nd;
        }

    }
}
