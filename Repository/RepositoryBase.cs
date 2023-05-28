using Fasade.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Database;

namespace Repository
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
    {
        private readonly TBCDbContext _dbContext;
        protected readonly DbSet<TModel> _dbSet;

        public RepositoryBase(TBCDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TModel>();
        }


        public virtual TModel GetById(int id) =>
            _dbSet.Find(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");

        public virtual TModel Insert(TModel model)
        {
            _dbSet.Add(model);
            return model;
        }

        public virtual void Update(TModel model)
        {
            _dbSet.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public virtual void Delete(TModel model)
        {
            if (_dbContext.Entry(model).State == EntityState.Detached)
            {
                _dbSet.Attach(model);
            }
            _dbSet.Remove(model);
        }

        public virtual void Delete(int id) =>
            Delete(GetById(id));

        public void SaveCanges() =>
            _dbContext.SaveChanges();

        public void Dispose() =>
            _dbContext.Dispose();
    }
}