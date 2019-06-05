using System;
using System.Collections.Generic;
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
            return _context.GetData();
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
        }

        public Student Read(int id)
        {
            return _context.GetUser(id).FirstOrDefault();
        }

        public void Update(Student item)
        {
            _context.Students.Attach(item);
        }

        public void Delete(int id)
        {
            _context.DeleteUser(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}