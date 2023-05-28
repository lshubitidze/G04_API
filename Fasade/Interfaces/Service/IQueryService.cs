namespace Fasade.Interfaces.Service
{
    public interface IQueryService<TModel> : IDisposable where TModel : class
    {
        public TModel GetById(int id);
    }
}
