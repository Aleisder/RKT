using System;
using System.Collections.Generic;

namespace DemoExam.Repository
{
    public abstract class Repository<T>
    {
        protected readonly string connectionString = $"Data Source={Environment.GetEnvironmentVariable("Server")}; Initial Catalog={Environment.GetEnvironmentVariable("Database")}";

        public abstract List<T> GetAll();
        public abstract T GetById(int id);
        public abstract int Add(T item);
        public abstract int Update(T item);
        public abstract void Delete(T item);
    }
}
