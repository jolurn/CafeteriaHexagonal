using DominioCafe.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioCafe.Interfaces
{
    /// PUERTO DE SALIDA - Operaciones básicas del repositorio
    public interface IRepositorioCafe
    {
        Task<IEnumerable<Cafe>> ObtenerTodosAsync();
        Task AgregarAsync(Cafe cafe);
        Task ActualizarAsync(Cafe cafe);
    }
}
