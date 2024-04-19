using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTs.Repository.Interfaces;

public interface IRepository<TEntity, TId>
{
    Task<bool> Add(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(long id);
    Task<IEnumerable<TEntity>> GetAll();
}
