﻿using GTL.Application.Data;
using GTL.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GTL.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private ApplicationDbContext _context = null;

        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            table = _context.Set<T>();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
            //It will mark the Entity state as Added State
            table.Add(obj);
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
            return table.ToList();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
            //First attach the object to the table
            table.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }
        
        public void Save()
        {
            throw new NotImplementedException();
            _context.SaveChanges();
        }
    }
}
