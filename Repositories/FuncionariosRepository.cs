using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories;
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly AppDbContext _context;

        public FuncionariosRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Funcionarios>> GetAll()
        {
            return await _context.Funcionarios.ToListAsync();
        }


        public async Task<IEnumerable<Funcionarios>> GetFuncionariosProduct()
        {
            return await _context.Funcionarios.Include(f=> f.Funcionarios).ToListAsync();
        }


          public async Task<Funcionarios> GetById(int id)
        {
            return await _context.Funcionarios.Where(f=> f.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Funcionarios> Create(Funcionarios funcionarios)
        {
            _context.Funcionarios.Add(funcionarios);
            await _context.SaveChangesAsync();
            return funcionarios;
        }

        public async Task<Funcionarios> Update(Funcionarios funcionarios)
        {
            _context.Entry(funcionarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return funcionarios;
        }
        public async Task<Funcionarios> Delete(int id)
        {
            var Funcionarios = await GetById(id);
            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();
            return funcionarios;
        }
        }
    }
}