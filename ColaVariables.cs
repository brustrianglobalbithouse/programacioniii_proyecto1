using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoVariables
    {
        public string variable;
        public int valor;
        public NodoVariables sig;
    }
    public class ColaVariables
    {
        private NodoVariables raiz;

        public ColaVariables()
        {
            raiz = null;
        }

        public void Enqueue(string vr)
        {
            if (!Existe(vr))
            {
                NodoVariables nuevo;
                nuevo = new NodoVariables();
                nuevo.variable = vr;
                nuevo.valor = 0;
                nuevo.sig = null;
                if (raiz == null)
                {
                    nuevo.sig = null;
                    raiz = nuevo;
                }
                else
                {
                    NodoVariables reco = raiz;
                    bool encontrado = false;
                    while (!encontrado)
                    {
                        if (reco.sig == null)
                        {
                            encontrado = true;
                        }
                        else
                        {
                            reco = reco.sig;
                        }
                    }
                    reco.sig = nuevo;
                }
            }
        }

        public string Dequeue()
        {
            if (raiz == null)
            {
                return null;
            }
            else
            {
                string top = raiz.variable;
                raiz = raiz.sig;
                return top;
            }
        }

        public void InsertarValor(string var, int val)
        {
            NodoVariables reco = raiz;
            while (reco != null)
            {
                if (reco.variable == var)
                {
                    reco.valor = val;
                }
                reco = reco.sig;
            }
        }

        public bool Existe(string var)
        {
            NodoVariables reco = raiz;
            while (reco != null)
            {
                if (reco.variable == var)
                {
                    return true;
                }
                reco = reco.sig;
            }
            return false;
        }

        public int BuscarValor(string var)
        {
            NodoVariables reco = raiz;
            while (reco != null)
            {
                if (reco.variable == var)
                {
                    return reco.valor;
                }
                reco = reco.sig;
            }
            return 0;
        }

        public void rellenar()
        {
            NodoVariables reco = raiz;
            while (reco != null)
            {
                Console.WriteLine("Ingrese el valor de " + reco.variable + " :");
                string linea = Console.ReadLine();
                int op = int.Parse(linea);
                reco.valor = op;
                reco = reco.sig;
            }
        }

    }
}
