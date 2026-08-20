using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioCafe.Entidades
{
    /// ENTIDAD DEL DOMINIO - Representa un Café en el negocio
    public class Cafe
    {
        // ============================================
        // PROPIEDADES
        // ============================================
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool EstaPreparado { get; set; }
        public string Tamaño { get; set; } = "Mediano";
        public DateTime FechaCreacion { get; set; }

        // ============================================
        // CONSTRUCTORES
        // ============================================

        // Constructor vacío (para crear nuevos cafés)
        public Cafe()
        {
            EstaPreparado = false;
            Tamaño = "Mediano";
            FechaCreacion = DateTime.Now;
        }

        // Constructor con parámetros (para crear desde el repositorio)
        public Cafe(int id, string nombre, decimal precio, bool estaPreparado, string tamaño, DateTime fechaCreacion)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            EstaPreparado = estaPreparado;
            Tamaño = tamaño;
            FechaCreacion = fechaCreacion;
        }

        // ============================================
        // MÉTODOS DE NEGOCIO
        // ============================================

        /// Preparar el café (marcar como preparado)

        public void Preparar()
        {
            if (EstaPreparado)
                throw new InvalidOperationException("El café ya está preparado");

            EstaPreparado = true;
        }

        /// Cambiar el tamaño del café

        public void CambiarTamaño(string nuevoTamaño)
        {
            if (EstaPreparado)
                throw new InvalidOperationException("No se puede cambiar el tamaño de un café preparado");

            if (nuevoTamaño != "Pequeño" && nuevoTamaño != "Mediano" && nuevoTamaño != "Grande")
                throw new InvalidOperationException("Tamaño no válido. Use: Pequeño, Mediano o Grande");

            Tamaño = nuevoTamaño;
        }

        /// Aplicar descuento al café

        public void AplicarDescuento(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
                throw new InvalidOperationException("El descuento debe estar entre 0% y 100%");

            Precio = Precio * (1 - (porcentaje / 100));
        }
    }
}
