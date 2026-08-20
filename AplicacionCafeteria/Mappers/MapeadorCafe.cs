using AplicacionCafeteria.DTOs;
using DominioCafe.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCafeteria.Mappers
{
    /// MAPEADOR - Convierte entre DTOs y Entidades del dominio
    public static class MapeadorCafe
    {
        
        /// Convertir DTO → Entidad de dominio
        
        public static Cafe AEntidad(CafeDTO dto)
        {
            return new Cafe
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                EstaPreparado = dto.EstaPreparado,
                Tamaño = dto.Tamaño,
                FechaCreacion = dto.FechaCreacion
            };
        }
                
        /// Convertir Entidad de dominio → DTO
        
        public static CafeDTO ADominioDTO(Cafe entidad)
        {
            return new CafeDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Precio = entidad.Precio,
                EstaPreparado = entidad.EstaPreparado,
                Tamaño = entidad.Tamaño,
                FechaCreacion = entidad.FechaCreacion
            };
        }
    }
}
