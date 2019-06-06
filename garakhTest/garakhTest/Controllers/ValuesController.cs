using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using garakhTest.Context;
using garakhTest.Interfaces;
using garakhTest.Models;

namespace garakhTest.Controllers
{
    public class ValuesController : ApiController
    {
        readonly IRepository<Student> _repository = new UserRepository(); 
        // GET api/values
        public JsonResponse<Student> Get()
        {
            return new JsonResponse<Student>(_repository.ReadList());
        }

        // GET api/values/5
        public Student Get(int id)
        {
            return _repository.Read(id);
        }

        // POST api/values
        public void Post([FromBody]Student value)
        {
            _repository.Create(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Student value)
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
