using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.UnitOfWork
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {

    }
}
