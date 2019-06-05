using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using garakhTest.Context;
using garakhTest.Entities;
using garakhTest.Interfaces;

namespace garakhTest.Controllers
{
    public class ValuesController : ApiController
    {
        readonly IRepository<User> _repository = new UserRepository(); 
        // GET api/values
        public IEnumerable<User> Get()
        {
            return _repository.ReadList();
        }

        // GET api/values/5
        public User Get(int id)
        {
            return _repository.Read(id);
        }

        // POST api/values
        public void Post([FromBody]User value)
        {
            _repository.Create(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]User value)
        {
            _repository.Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
