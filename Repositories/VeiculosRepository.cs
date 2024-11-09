using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.models;

namespace Repositories;
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly AppDbContext _context;

        public VeiculosRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Veiculos>> GetAll()
        {
            return await _context.Veiculos.ToListAsync();
        }


        public async Task<IEnumerable<Veiculos>> GetVeiculosProduct()
        {
            return await _context.Veiculos.Include(v=> v.Veiculos).ToListAsync();
        }


          public async Task<Veiculos> GetById(int id)
        {
            return await _context.Veiculos.Where(v=> v.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Veiculos> Create(Veiculos veiculos)
        {
            _context.Veiculos.Add(veiculos);
            await _context.SaveChangesAsync();
            return veiculos;
        }

        public async Task<Veiculos> Update(Veiculos veiculos)
        {
            _context.Entry(veiculos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return veiculos;
        }
        public async Task<Veiculos> Delete(int id)
        {
            var Veiculos = await GetById(id);
            _context.Funcionarios.Remove(veiculos);
            await _context.SaveChangesAsync();
            return veiculos;
        }
        }
    }
}