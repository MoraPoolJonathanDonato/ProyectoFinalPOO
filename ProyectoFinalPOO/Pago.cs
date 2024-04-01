using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mora Pool Jonathan Donato
namespace ProyectoFinalPOO
{
    class Pago // Define una clase llamada Pago
    {
        // Propiedades 
        public int NumeroNomina { get; set; } // Número de nómina del empleado
        public DateTime Fecha { get; set; } // Fecha en que se realizó el pago
        public decimal PagoRealizado { get; set; } // Monto del pago realizado

        // Constructor
        public Pago(int numeroNomina, DateTime fecha, decimal pagoRealizado)
        {
            NumeroNomina = numeroNomina; // Asigna el número de nómina proporcionado al atributo NumeroNomina
            Fecha = fecha; // Asigna la fecha proporcionada al atributo Fecha
            PagoRealizado = pagoRealizado; // Asigna el monto del pago proporcionado al atributo PagoRealizado
        }
    }
}