using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Examen
{

    internal class Program
    {
        static string[] codigos = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
        static string[] modelos = { "SUV Interceptor", "Sedan Executive", "PickUpTitan", "City Hatchback", "Electric EV", "Van Carga" };
        static public double[] precios = { 28000.0, 18500.0, 35000.0, 14000.0, 42000.0, 22500.0 };
        static  public double[] cantidad = { 2, 4, 1, 5, 1, 3 };
        static public double[,] datosdematriz =
        { { 28000.0,2 }, { 18500.0,4 }, { 35000.0,1 }, { 14000.0,5 },  { 42000.0,1 }, { 22500.0,3 }
        };

        static public void ValidarDatos(double precio, double cantidad)
        {
            Boolean valido = false;
            if (precio > 0 && cantidad > 0)
            {
                valido = true;
            }
            if (valido == false)
            {
                Console.WriteLine("Error: El precio y la cantidad deben ser mayores a cero.");
            }

        }
        
        static public void MontoNeto(double[] precios, double[] cantidad)
        {
            double c = 0;
            double S = 0;
            int P = 0;
            for (int i = 0; i < precios.Length - 1; i++)
            { 
                c = precios[i] * cantidad[i];
            S = S + c;
                if (c >= 50000)
                {
                    P++;
                }
            }


            Console.WriteLine("\t\tse recaudo un total de "+ S);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("\t\tSe realizaron un total de "+P+" ventas premium");
        }
        static public void ImprimirMatriz(double[,] matriz, string[] codigos)
        {
            Console.WriteLine("Codigo\tModelo\tPrecio\tCantidad");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.WriteLine($"{codigos[i]}\t{modelos[i]}\t{precios[i]}\t{cantidad[i]}");
            }
        }
        static public void Burbuja( string[] modelos, double[] montos)
        {
           
            for (int i = 0; i < montos.Length - 1; i++)
            {
                for (int j = 0; j < montos.Length - i - 1; j++)
                {
                    if (montos[j] > precios[j + 1])
                    {
                        double temp = precios[j];
                        precios[j] = precios[j + 1];
                        precios[j + 1] = temp;
                    }
                }
                Console.WriteLine("Ordenamiento de precios de menor a mayor realizado");

            }
        }
        static public void Busqueda(string[] codigos)
        {
            string busqueda;
            Console.WriteLine("Ingrese el codigo del auto");
            busqueda = Console.ReadLine();
            if (busqueda == null)
                Console.WriteLine("Codigo nulo, ingrese un valor");
            busqueda = Console.ReadLine();
            
                Console.WriteLine("Codigo\tModelo\tPrecio\tCantidad");
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                if (busqueda == codigos[i + 1])
                {
                    Console.WriteLine($"{codigos[i]}\t{modelos[i]}\t{precios[i]}\t{cantidad[i]}");
                }
            }


            }
        static void Main(string[] args)
        {
            int Operacion = 0;
            do
            {

                Console.WriteLine("Seleccione una opcion[1-4] ");
                Console.WriteLine("1. Ganancias");
                Console.WriteLine("2. Imprimir matriz");
                Console.WriteLine("3. Ordenar precios");
                Console.WriteLine("4. buscar por codigo");

                
                Operacion = int.Parse(Console.ReadLine());
                switch (Operacion)
                {

                    case 1:
                        MontoNeto(precios, cantidad);
                        Console.ReadKey();
                        break;
                    case 2:
                        ImprimirMatriz(datosdematriz, codigos);
                        Console.ReadKey();
                        break;
                    case 3:
                        Burbuja( modelos, precios);
                        Console.ReadKey();
                        break;
                    case 4:
                        Busqueda(codigos);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion inexistente, porfavor elige una opcion valida[1-4]");
                        Console.ReadKey();
                        break;
                }
                }
             while (Operacion != 5);
            Console.WriteLine("Saliendo del sistema");
        } 
    }
}

