using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioCafe.Modelos
{
    /// MODELO DE BASE DE DATOS - Tabla "Cafes" en SQL Server
    public class CafeModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool EstaPreparado { get; set; }
        public string Tamaño { get; set; } = "Mediano";
        public DateTime FechaCreacion { get; set; }
    }
}
