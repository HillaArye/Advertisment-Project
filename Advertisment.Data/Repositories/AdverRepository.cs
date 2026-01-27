using Advertisment.Core.Entities;
using Advertisment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Data.Repositories
{
    //לעשות על כל המאגרי נתונים ToList()
    public class AdverRepository : IAdverRepository
    {
        private readonly DataContext _context;
        public AdverRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Adver>> GetAllAsync()
        {
            return await _context.advers.ToListAsync();
        }

        public async Task<Adver> GetByIdAsync(int id)
        {
            return await _context.advers.FindAsync(a => a.id == id);
        }
        public async Task<Adver> AddAdverAsync(Adver adver)
        {
           await _context.advers.AddAsync(adver);
            return adver;
        }
        public async Task<int> GetByIndexAsync(int id)
        {
            return await _context.advers.ToList().FindIndexAsync(a => a.id == id);
        }


        public async Task<Adver> UpdateAdverAsync(int id,Adver adver)
        {
            var a= await GetByIdAsync (id);
            a.id = adver.id;
            a.date=adver.date;
            a.start=adver.start;
            a.end=adver.end;
            a.desc=adver.desc;

            return a;
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}

