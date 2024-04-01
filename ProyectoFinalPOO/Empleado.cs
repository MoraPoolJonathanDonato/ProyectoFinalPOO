using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mora Pool Jonathan Donato
namespace ProyectoFinalPOO
{
    class Empleado // Define una clase llamada Empleado
    {
        // Propiedades
        public int NumeroNomina { get; set; } // Número de nómina del empleado
        public string Nombre { get; set; } // Nombre del empleado
        public decimal SalarioDiario { get; set; } // Salario diario del empleado

        // Constructor
        public Empleado(int numeroNomina, string nombre, decimal salarioDiario)
        {
            NumeroNomina = numeroNomina; // Asigna el número de nómina proporcionado al atributo NumeroNomina
            Nombre = nombre; // Asigna el nombre proporcionado al atributo Nombre
            SalarioDiario = salarioDiario; // Asigna el salario diario proporcionado al atributo SalarioDiario
        }
    }
}