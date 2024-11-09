using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories
{
    public interface IVeiculosRepository
    {
        Task<IEnumerable<Veiculos>> GetAll()
        Task<IEnumerable<Veiculos>> GetVeiculosProduct()
        Task<Veiculos> GetById(int id)
        Task<Veiculos> Create (Veiculos veiculos);
        Task<Veiculos> Update (Veiculos veiculos);
        Task<Veiculos> Delete (int id);
    }
}