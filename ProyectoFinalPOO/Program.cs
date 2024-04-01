using ProyectoFinalPOO;
using System;
using System.Collections.Generic;
using System.IO;
//MORA POOL JONATHAN DONATO 22DV
//LOS ARCHIVO DE EMPLEADOS, DIAS_TRABAJADOS Y PAGOS ESTAN EN LA CARPETA BIN
namespace ProyectoFinalPOO
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>(); // Crea una lista de empleados
        static List<Pago> pagos = new List<Pago>(); // Crea una lista de pagos

        static void Main(string[] args)
        {
            // Cargar empleados desde el archivo
            CargarEmpleados("empleados.txt");

            // Opción para cargar los días trabajados
            Console.WriteLine("¿Desea cargar los días trabajados por mes? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                CargarDiasTrabajados("dias_trabajados.txt");
            }

            // Desplegar empleados y pagos históricos
            MostrarEmpleados();
            MostrarPagos();

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

            static void CargarEmpleados(string archivo) // Método para cargar empleados desde un archivo
        {
            try
            {
                string[] lineas = File.ReadAllLines(archivo); // Lee todas las líneas del archivo especificado
                foreach (string linea in lineas) // Itera sobre cada línea leída
                {
                    string[] datos = linea.Split(','); // Divide la línea en partes utilizando la coma como separador
                    int numeroNomina = int.Parse(datos[0]); // Extrae el número de nómina
                    string nombre = datos[1]; // Extrae el nombre del empleado
                    decimal salarioDiario = decimal.Parse(datos[2]); // Extrae el salario diario
                    empleados.Add(new Empleado(numeroNomina, nombre, salarioDiario)); // Agrega un nuevo empleado a la lista
                }
            }
            catch (Exception ex) //manejo de errores
            {
                Console.WriteLine("Error al cargar los empleados: " + ex.Message);
            }
        }

        static void CargarDiasTrabajados(string archivo) // Método para cargar los días trabajados desde un archivo
        {
            try
            {
                string[] lineas = File.ReadAllLines(archivo); // Lee todas las líneas del archivo especificado
                foreach (string linea in lineas) // Itera sobre cada línea leída
                {
                    string[] datos = linea.Split(','); // Divide la línea en partes utilizando la coma como separador
                    int numeroNomina = int.Parse(datos[0]);  // Extrae el número de nómina
                    DateTime fecha = DateTime.Parse(datos[1]); // Extrae la fecha
                    int diasTrabajados = int.Parse(datos[2]); // Extrae los días trabajados
                    decimal pagoRealizado = diasTrabajados * empleados.Find(e => e.NumeroNomina == numeroNomina).SalarioDiario; // Calcula el pago realizado
                    pagos.Add(new Pago(numeroNomina, fecha, pagoRealizado)); // Agrega un nuevo pago a la lista de pagos

                    // Guardar el pago en un archivo
                    GuardarPagoEnArchivo(numeroNomina, fecha, pagoRealizado);
                }
            }
            catch (Exception ex) //manejo de errores
            {
                Console.WriteLine("Error al cargar los días trabajados: " + ex.Message); //mensaje de error
            }
        }

        static void MostrarEmpleados()
        {
            Console.WriteLine("Empleados:");
            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Número de nómina: {empleado.NumeroNomina}, Nombre: {empleado.Nombre}, Salario Diario: {empleado.SalarioDiario}");
            }
        }

        static void MostrarPagos() // Método para mostrar la lista de empleados
        {
            Console.WriteLine("Pagos Realizados:"); // Muestra un encabezado
            foreach (Pago pago in pagos) // Itera sobre cada empleado en la lista de empleados
            {
                Console.WriteLine($"Número de nómina: {pago.NumeroNomina}, Fecha: {pago.Fecha}, Pago Realizado: {pago.PagoRealizado}");
            }
        }

        static void GuardarPagoEnArchivo(int numeroNomina, DateTime fecha, decimal pagoRealizado)// Método para guardar un pago en un archivo
        {
            try
            {
                using (StreamWriter sw = File.AppendText("pagos.txt")) // Abre un archivo para añadir texto
                {
                    sw.WriteLine($"{numeroNomina},{fecha},{pagoRealizado}"); // Escribe una línea en el archivo con los datos del pago
                }
            }
            catch (Exception ex) //manejo de errores
            {
                Console.WriteLine("Error al guardar el pago en el archivo: " + ex.Message);
            }
        }
    }
}