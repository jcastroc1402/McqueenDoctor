using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using McqueenDoctor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext Context;
        protected readonly DbSet<T> Entities;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            Entities.Remove(entity);
        }
    }
}
