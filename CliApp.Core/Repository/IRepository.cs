using CliApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CliApp.Core.Repository
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        T GetById<T>(int id, string include) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
