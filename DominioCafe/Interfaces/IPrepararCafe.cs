using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioCafe.Interfaces
{
    /// PUERTO DE SALIDA - Especializado en preparar café
    public interface IPrepararCafe
    {
        Task PrepararAsync(int id);
    }
}
