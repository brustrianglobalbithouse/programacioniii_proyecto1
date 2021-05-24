using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class NodoArbol
    {
        public string info;
        public NodoArbol izq, der;
    }
    class Arbol
    {

        private NodoArbol raiz;
        private int altura;
        private int contador;
        private string[] exp;
        public Arbol()
        {
            raiz = null;
        }
        
        public void InsertarRaiz(string info)
        {
            NodoArbol nuevo;
            nuevo = new NodoArbol();
            nuevo.info = info;
            nuevo.izq = null;
            nuevo.der = null;

            raiz = nuevo;
            altura = 1;
        }

        public void InsertarHijos(Arbol a1, Arbol a2)
        {
            raiz.izq = a1.raiz;
            raiz.der = a2.raiz;
            if(a1.altura > a2.altura) {
                altura += a1.altura;
            } else {
                altura += a2.altura;
            }
        }

        private void ImprimirArbol(NodoArbol reco)
        {
            if (reco != null)
            {
                contador += 1;
                ImprimirArbol(reco.izq);
                ImprimirArbol(reco.der);
                exp[contador - 1] += "[" + reco.info + "] ";
                contador -= 1;
            }
        }

        public void ImprimirArbol()
        {
            exp = new string[altura];
            contador = 0;
            ImprimirArbol(raiz);
            Console.WriteLine("Árbol por niveles: ");
            for(int i = 0; i < exp.Length; i++)
            {
                Console.WriteLine("Nivel "+ (i + 1) + ": " + exp[i]);
            }
        }

        private void ImprimirPost(NodoArbol reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Console.Write(reco.info + " ");
            }
        }

        public void ImprimirPost()
        {
            Console.Write("Expresión posfija: ");
            ImprimirPost(raiz);
            Console.WriteLine();
        }

        private double EvaluarArbol(ColaVariables valores, NodoArbol reco)
        {
            if (reco.izq != null && reco.der != null)
            {
                double info_izq = EvaluarArbol(valores, reco.izq);
                double info_der = EvaluarArbol(valores, reco.der);
                if(reco.info == "+")
                {
                    return info_izq + info_der;
                }else if(reco.info == "-")
                {
                    return info_izq - info_der;
                }
                else if (reco.info == "*")
                {
                    return info_izq * info_der;
                }
                else if (reco.info == "/")
                {
                    return info_izq / info_der;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                int number_test;
                bool isNumeric = int.TryParse(reco.info, out number_test);
                if (isNumeric)
                {
                    return number_test;
                }
                else
                {
                    int valor_evaluado = valores.BuscarValor(reco.info);
                    contador++;
                    return valor_evaluado;
                }
            }
        }

        public void EvaluarArbol(ColaVariables valores)
        {
            contador = 0;
            double total = EvaluarArbol(valores, raiz);
            Console.WriteLine("Resultado de expresión evaluada: " + total.ToString());
        }
    }
}
