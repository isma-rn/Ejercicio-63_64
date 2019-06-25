using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E63_E64_Arreglo_Head_Tail
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion, entrada;
            do
            {
                Console.Clear();
                int[] prueba = ObtenerArregloEnterosConAleatorios(10, 99, 10);

                if (prueba != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Dado un arreglo Arr y un string s");                    
                    Console.WriteLine("> imprmir el primer elemento del arreglo si s es la palabra \"head\"");
                    Console.WriteLine("> imprimir el contenido de arreglo, excluyendo el primer elemento si s es igual a \"tail\"");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Arreglo de enteros generado automáticamente con número aleatorios:");                    
                    foreach (var v in prueba)
                        Console.Write("[{0}]", v);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nIngrese");
                    entrada = Console.ReadLine();

                    var resultado = ImprimirElementos(prueba, entrada);
                    if( resultado != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine( "Resultado:\n\t{0}",resultado );
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, no se pudo obtener el elemento");
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, no se puedo obtener arreglo");
                }

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nn : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);
        }
        public static string ImprimirElementos( int[] arreglo, string etiqueta )
        {
            StringBuilder result = new StringBuilder();
            if( etiqueta.Length>0)
            {
                switch (etiqueta.ToLower())
                {
                    case "head":
                        for (int i = 0; i < arreglo.Length; i++)
                            if (i == 0)
                                result.Append(string.Format("[{0}] ", arreglo[i]));
                        break;

                    case "tail":
                        for (int i = 0; i < arreglo.Length; i++)
                            if (i != 0)
                                result.Append(string.Format("[{0}] ", arreglo[i]));
                        break;
                    default:
                        return null;
                }
                return result.ToString();
            }

            return null;
        }
        public static int[] ObtenerArregloEnterosConAleatorios(int min, int max, int size)
        {
            if (size > 0 && min < max)
            {
                Random random = new Random();
                int[] resultado = new int[size];
                for (int i = 0; i < size; i++)
                    resultado[i] = random.Next(min, max);
                return resultado;
            }
            return null;
        }
    }
}