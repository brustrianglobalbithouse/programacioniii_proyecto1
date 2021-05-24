using System;
using System.Text.RegularExpressions;

namespace Proyecto1
{
    public class Program
    {
        PilaOperadores operadores;
        PilaNodos nodos;
        ColaVariables variables;
        string expresion;

        public void IngresarExpresion(string[] sp)
        {
            operadores = new PilaOperadores();
            nodos = new PilaNodos();
            variables = new ColaVariables();

            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == "+" || sp[i] == "-" || sp[i] == "*" || sp[i] == "/" || sp[i] == "(" || sp[i] == ")") {
                    if (i == 0)
                    {
                        operadores.Push(expresion[i].ToString());
                    }
                    else
                    {
                        if (sp[i] == "(")
                        {
                            operadores.Push(sp[i]);
                        }
                        else if (sp[i] == ")")
                        {
                            bool cierre = false;
                            while (!cierre)
                            {
                                string aux_op = operadores.Pop();
                                if (aux_op == "(")
                                {
                                    cierre = true;
                                }
                                else
                                {
                                    nodos.PushOperador(aux_op);
                                }
                            }
                        }
                        else
                        {
                            //Verificar precedencia de operadores
                            if (operadores.Peak() != null)
                            {
                                bool precedencia = false;
                                if ((sp[i] == "+" || sp[i] == "-") && (operadores.Peak() == "*" || operadores.Peak() == "/"))
                                {
                                    precedencia = true;
                                }
                                else if((sp[i] == "*" && operadores.Peak() == "/") || (sp[i] == "/" && operadores.Peak() == "*"))
                                {
                                    precedencia = true;
                                }
                                if (precedencia)
                                {
                                    string aux_op2 = operadores.Pop();
                                    nodos.PushOperador(aux_op2);
                                }
                            }
                            operadores.Push(sp[i]);
                        }
                    }
                } else {
                    int number_test;
                    bool isNumeric = int.TryParse(sp[i], out number_test);
                    if (!isNumeric)
                    {
                        variables.Enqueue(sp[i]);
                    }
                    nodos.Push(sp[i]);
                }
            }

            if(operadores.Peak() != null)
            {
                bool final = false;
                while (!final)
                {
                    string aux_op = operadores.Pop();
                    nodos.PushOperador(aux_op);
                    if (operadores.Peak() == null)
                    {
                        final = true;
                    }
                }
            }

        }

        public void EvaluarExpresion()
        {
            variables.rellenar();
            nodos.EvaluarArbol(variables);
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.operadores = new PilaOperadores();
            pg.nodos = new PilaNodos();
            pg.expresion = "";

            int op = 0;
            string linea;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Ingresar expresión");
                Console.WriteLine("2. Mostrar expresión Posfija y Árbol binario");
                Console.WriteLine("3. Evaluar la expresion");
                Console.WriteLine("4. Salir.");
                Console.WriteLine();

                Console.WriteLine("Ingrese su opción:");
                linea = Console.ReadLine();
                op = int.Parse(linea);

                if (op == 1)
                {
                    Console.WriteLine("Ingrese expresión (separando cada valor con espacios):");
                    pg.expresion = Console.ReadLine();
                    string[] split = pg.expresion.Split(null);
                    pg.IngresarExpresion(split);
                    Console.WriteLine("Expresión ingresada con éxito.");
                }
                else if (op == 2)
                {
                    if(pg.expresion != "")
                    {
                        Console.WriteLine("Expresión original: " + pg.expresion);
                        pg.nodos.ImprimirPost();
                        pg.nodos.ImprimirArbol();
                    }
                    else
                    {
                        Console.WriteLine("ERROR. Ingrese primero una expresión.");
                    }
                }
                else if (op == 3)
                {
                    if (pg.expresion != "")
                    {
                        Console.WriteLine("Expresión original: " + pg.expresion);
                        pg.EvaluarExpresion();
                    }
                    else
                    {
                        Console.WriteLine("ERROR. Ingrese primero una expresión.");
                    }
                }
                else
                {
                    Console.WriteLine("Desea salir o la opción no es válida");
                }
                Console.ReadKey();

            } while (op != 4);
        }
    }
}
