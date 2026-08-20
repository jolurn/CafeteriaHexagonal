using DominioCafe.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioCafe.Interfaces
{
    /// PUERTO DE SALIDA - Especializado en obtener café por ID
    public interface IObtenerCafe
    {
        Task<Cafe?> ObtenerPorIdAsync(int id);
    }
}
