using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade.Interfaces.Service
{
    public interface ICommandService<TModel> : IDisposable where TModel : class
    {
        public void Delete(TModel model);
        public void Delete(int id);
        public TModel Insert(TModel model);
        public void Update(TModel model);
    }
}
