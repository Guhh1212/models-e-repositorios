using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories
{
    public interface IFuncionariosRepository
    {
        Task<IEnumerable<Funcionarios>> GetAll()
        Task<IEnumerable<Funcionarios>> GetFuncionariosProduct()
        Task<Funcionarios> GetById(int id)
        Task<Funcionarios> Create (Funcionarios funcionarios);
        Task<Funcionarios> Update (Funcionarios funcionarios);
        Task<Funcionarios> Delete (int id);
    }
}