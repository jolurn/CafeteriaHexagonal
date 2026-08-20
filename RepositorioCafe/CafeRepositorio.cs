using DominioCafe.Entidades;
using DominioCafe.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositorioCafe.Contexto;
using RepositorioCafe.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioCafe
{
    /// ADAPTADOR DE SALIDA - Implementa TODOS los puertos de Café
    public class CafeRepositorio : IRepositorioCafe, IPrepararCafe, IObtenerCafe
    {
        private readonly ContextoCafeteria _contexto;

        public CafeRepositorio(ContextoCafeteria contexto)
        {
            _contexto = contexto;
        }

        // ============================================
        // IMPLEMENTACIÓN DE IRepositorioCafe
        // ============================================

        public async Task<IEnumerable<Cafe>> ObtenerTodosAsync()
        {
            return await _contexto.Cafes
                .Select(m => new Cafe(
                    m.Id,
                    m.Nombre,
                    m.Precio,
                    m.EstaPreparado,
                    m.Tamaño,
                    m.FechaCreacion
                ))
                .ToListAsync();
        }

        public async Task AgregarAsync(Cafe cafe)
        {
            var modelo = new CafeModelo
            {
                Nombre = cafe.Nombre,
                Precio = cafe.Precio,
                EstaPreparado = cafe.EstaPreparado,
                Tamaño = cafe.Tamaño,
                FechaCreacion = cafe.FechaCreacion
            };

            await _contexto.Cafes.AddAsync(modelo);
            await _contexto.SaveChangesAsync();
            cafe.Id = modelo.Id;
        }

        public async Task ActualizarAsync(Cafe cafe)
        {
            var modelo = await _contexto.Cafes.FindAsync(cafe.Id);

            if (modelo == null)
                throw new InvalidOperationException($"No se encontró el café con ID {cafe.Id}");

            modelo.Nombre = cafe.Nombre;
            modelo.Precio = cafe.Precio;
            modelo.EstaPreparado = cafe.EstaPreparado;
            modelo.Tamaño = cafe.Tamaño;
            modelo.FechaCreacion = cafe.FechaCreacion;

            await _contexto.SaveChangesAsync();
        }

        // ============================================
        // IMPLEMENTACIÓN DE IPrepararCafe
        // ============================================

        public async Task PrepararAsync(int id)
        {
            var modelo = await _contexto.Cafes.FindAsync(id);

            if (modelo == null)
                throw new InvalidOperationException($"No se encontró el café con ID {id}.");

            modelo.EstaPreparado = true;
            await _contexto.SaveChangesAsync();
        }

        // ============================================
        // IMPLEMENTACIÓN DE IObtenerCafe
        // ============================================

        public async Task<Cafe?> ObtenerPorIdAsync(int id)
        {
            var modelo = await _contexto.Cafes.FindAsync(id);

            if (modelo != null)
            {
                return new Cafe(
                    modelo.Id,
                    modelo.Nombre,
                    modelo.Precio,
                    modelo.EstaPreparado,
                    modelo.Tamaño,
                    modelo.FechaCreacion
                );
            }

            return null;
        }
    }
}
