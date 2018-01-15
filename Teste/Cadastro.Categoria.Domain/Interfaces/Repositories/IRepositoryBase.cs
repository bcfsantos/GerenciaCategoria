using System.Collections.Generic;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        T GetId(int id);

        IEnumerable<T>GetAll();

        void Update(T obj);

        void Remove(T obj);

        void Dispose();

    }
}
