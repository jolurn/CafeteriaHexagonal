using AplicacionCafeteria.Interfaces;
using DominioCafe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCafeteria.Servicios
{
    /// CASO DE USO - Implementa la lógica para preparar un café
    public class ServicioPrepararCafe : IServicioPrepararCafe
    {
        private readonly IPrepararCafe _prepararCafe;
        private readonly IObtenerCafe _obtenerCafe;

        public ServicioPrepararCafe(IPrepararCafe prepararCafe, IObtenerCafe obtenerCafe)
        {
            _prepararCafe = prepararCafe;
            _obtenerCafe = obtenerCafe;
        }

        public async Task PrepararAsync(int id)
        {
            var cafe = await _obtenerCafe.ObtenerPorIdAsync(id);

            if (cafe == null)
                throw new InvalidOperationException($"No se encontró el café con ID {id}");

            cafe.Preparar();
            await _prepararCafe.PrepararAsync(id);
        }
    }
}
