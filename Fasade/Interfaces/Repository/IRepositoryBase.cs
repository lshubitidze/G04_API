using System.Linq.Expressions;

namespace Fasade.Interfaces.Repository
{
    public interface IRepositoryBase<TModel> : IDisposable where TModel : class
    {
        TModel Insert(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        void Delete(int id);
        TModel GetById(int id);
        void SaveCanges();
    }
}
