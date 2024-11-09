using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories;
{
    public class SalariosRepository : ISalariosRepository
    {
        private readonly AppDbContext _context;

        public SalariosRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Salarios>> GetAll()
        {
            return await _context.Salarios.ToListAsync();
        }


        public async Task<IEnumerable<Salarios>> GetSalariosProduct()
        {
            return await _context.Salarios.Include(f=> f.Salarios).ToListAsync();
        }


          public async Task<Salarios> GetById(int id)
        {
            return await _context.Salarios.Where(f=> f.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Salarios> Create(Salarios salarios)
        {
            _context.Salarios.Add(salarios);
            await _context.SaveChangesAsync();
            return salarios;
        }

        public async Task<Salarios> Update(Salarios salarios)
        {
            _context.Entry(salarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return salarios;
        }
        public async Task<Salarios> Delete(int id)
        {
            var Salarios = await GetById(id);
            _context.Salarios.Remove(salarios);
            await _context.SaveChangesAsync();
            return salarios;
        }
        }
    }
}