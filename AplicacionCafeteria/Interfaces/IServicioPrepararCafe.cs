using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCafeteria.Interfaces
{
    /// PUERTO DE ENTRADA - Especializado en preparar café
    public interface IServicioPrepararCafe
    {
        Task PrepararAsync(int id);
    }
}
