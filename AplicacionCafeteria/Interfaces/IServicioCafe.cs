using AplicacionCafeteria.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCafeteria.Interfaces
{
    /// PUERTO DE ENTRADA - Servicio principal para gestionar cafés
    public interface IServicioCafe
    {
        Task<IEnumerable<CafeDTO>> ObtenerTodosAsync();
        Task<CafeDTO?> ObtenerPorIdAsync(int id);
        Task<CafeDTO> CrearAsync(CafeDTO cafeDTO);
        Task<CafeDTO> ActualizarAsync(CafeDTO cafeDTO);
    }
}
