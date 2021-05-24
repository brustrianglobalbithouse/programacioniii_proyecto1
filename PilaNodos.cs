using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoNodo
    {
        public Arbol arbol;
        public NodoNodo sig;
    }
    public class PilaNodos
    {
        private NodoNodo raiz;

        public PilaNodos()
        {
            raiz = null;
        }

        public void Push(string op)
        {
            NodoNodo nuevo = new NodoNodo();
            nuevo.arbol = new Arbol();
            nuevo.arbol.InsertarRaiz(op);
            if (raiz == null)
            {
                nuevo.sig = null;
                raiz = nuevo;
            }
            else
            {
                nuevo.sig = raiz;
                raiz = nuevo;
            }
        }

        public void PushOperador(string op)
        {
            Arbol nuevoArbol = new Arbol();
            nuevoArbol.InsertarRaiz(op);
            nuevoArbol.InsertarHijos(raiz.sig.arbol, raiz.arbol);
            Pop();
            raiz.arbol = nuevoArbol;
        }

        public void Pop()
        {
            if (raiz != null)
            {
                raiz = raiz.sig;
            }
        }

        public void ImprimirPost()
        {
            raiz.arbol.ImprimirPost();
        }

        public void ImprimirArbol()
        {
            raiz.arbol.ImprimirArbol();
        }

        public void EvaluarArbol(ColaVariables valores)
        {
            raiz.arbol.EvaluarArbol(valores);
        }
    }
}
