using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories
{
    public interface ISalariosRepository
    {
        Task<IEnumerable<Salarios>> GetAll()
        Task<IEnumerable<Salarios>> GetSalariosProduct()
        Task<Salarios> GetById(int id)
        Task<Salarios> Create (Salarios salarios);
        Task<Salarios> Update (Salarios salarios);
        Task<Salarios> Delete (int id);
    }
}