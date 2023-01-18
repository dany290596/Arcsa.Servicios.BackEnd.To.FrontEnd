using Evaluacion.Data.Context;
using Evaluacion.Data.Interfaces.Common;
using Evaluacion.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion.Data.Implements.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EvaluacionContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(EvaluacionContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T t)
        {
            await _entities.AddAsync(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }

        public async Task Delete(Guid id)
        {
            T t = await GetById(id);
            _context.Remove(t);
        }
    }
}