using AplicacionCafeteria.DTOs;
using AplicacionCafeteria.Interfaces;
using AplicacionCafeteria.Mappers;
using DominioCafe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCafeteria.Servicios
{
    /// CASO DE USO - Implementa la lógica para gestionar cafés
    public class ServicioCafe : IServicioCafe
    {
        private readonly IRepositorioCafe _repositorioCafe;
        private readonly IObtenerCafe _obtenerCafe;

        public ServicioCafe(IRepositorioCafe repositorioCafe, IObtenerCafe obtenerCafe)
        {
            _repositorioCafe = repositorioCafe;
            _obtenerCafe = obtenerCafe;
        }

        public async Task<IEnumerable<CafeDTO>> ObtenerTodosAsync()
        {
            var cafes = await _repositorioCafe.ObtenerTodosAsync();
            return cafes.Select(c => MapeadorCafe.ADominioDTO(c));
        }

        public async Task<CafeDTO?> ObtenerPorIdAsync(int id)
        {
            var cafe = await _obtenerCafe.ObtenerPorIdAsync(id);
            return cafe == null ? null : MapeadorCafe.ADominioDTO(cafe);
        }

        public async Task<CafeDTO> CrearAsync(CafeDTO cafeDTO)
        {
            var cafe = MapeadorCafe.AEntidad(cafeDTO);
            await _repositorioCafe.AgregarAsync(cafe);
            return MapeadorCafe.ADominioDTO(cafe);
        }

        public async Task<CafeDTO> ActualizarAsync(CafeDTO cafeDTO)
        {
            var cafeExistente = await _obtenerCafe.ObtenerPorIdAsync(cafeDTO.Id);

            if (cafeExistente == null)
                throw new InvalidOperationException($"No se encontró el café con ID {cafeDTO.Id}");

            cafeExistente.Nombre = cafeDTO.Nombre;
            cafeExistente.Precio = cafeDTO.Precio;

            if (!cafeExistente.EstaPreparado)
            {
                cafeExistente.CambiarTamaño(cafeDTO.Tamaño);
            }

            await _repositorioCafe.ActualizarAsync(cafeExistente);
            return MapeadorCafe.ADominioDTO(cafeExistente);
        }
    }
}
