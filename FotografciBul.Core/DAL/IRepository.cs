using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FotografciBul.Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity //Entity tipinde class tarafından implement edilebilir.
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
