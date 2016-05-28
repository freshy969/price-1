using System.Linq;
using Infrastructure.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace Data.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IGenericEntity
    {
        protected ISession Session { get { return NhibernateUnitOfWork.Current.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public void Add(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(long id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public T GetById(long id)
        {
            return Session.Get<T>(id);
        }
    }
}