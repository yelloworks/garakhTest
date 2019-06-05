using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using garakhTest.Entities;
using garakhTest.Interfaces;

namespace garakhTest.Context
{
    public class UserRepository : IRepository<User>
    {
        public void Dispose()
        {

        }

        public IEnumerable<User> ReadList()
        {
            throw new NotImplementedException();
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public User Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}