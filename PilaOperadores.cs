using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoOperadores
    {
        public string operador;
        public NodoOperadores sig;
    }
    public class PilaOperadores
    {
        private NodoOperadores raiz;

        public PilaOperadores()
        {
            raiz = null;
        }

        public void Push(string op)
        {
            NodoOperadores nuevo = new NodoOperadores();
            nuevo.operador = op;
            if (raiz == null) {
                nuevo.sig = null;
                raiz = nuevo;
            } else {
                nuevo.sig = raiz;
                raiz = nuevo;
            }
        }

        public string Pop()
        {
            if (raiz == null) {
                return null;
            } else {
                string top = raiz.operador;
                raiz = raiz.sig;
                return top;
            }
        }

        public string Peak()
        {
            if (raiz != null)
            {
                return raiz.operador;
            }
            else
            {
                return null;
            }
        }
    }
}
