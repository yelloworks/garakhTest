using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using garakhTest.Interfaces;

namespace garakhTest.Context
{
    public class UserRepository : IRepository<Student>
    {
        DbEntities _context = new DbEntities();

        public void Dispose()
        {

        }

        public IEnumerable<Student> ReadList()
        {
            return _context.GetData().ToList();
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
            Save();
        }

        public Student Read(int id)
        {
            return _context.GetUser(id).FirstOrDefault();
        }

        public void Update(Student item)
        {
            var firstOrDefault = Read(item.Id);
            if (firstOrDefault != null)
            {
                firstOrDefault.Name = item.Name;
                firstOrDefault.Group = item.Group;
                Save();
            }

            ////Mark2
            //if (firstOrDefault != null)
            //{
            //_context.Entry(firstOrDefault).State = EntityState.Detached;
            //_context.Students.Attach(item);
            //Save();
            //}

        }

        public void Delete(int id)
        {
            _context.DeleteUser(id);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}