using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using lab123.Models;

namespace lab123.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private static List<Data> _memCache = new List<Data>();

        [HttpGet]
        public ActionResult<IEnumerable<Data>> Get()
        {
            return _memCache;
        }

        [HttpGet("{id}")]
        public ActionResult<Data> Get(int id)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Данные отсутствуют!");

            return _memCache[id];
        }

        [HttpPost]
        public void Post([FromBody] Data value)
        {
            _memCache.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Data value)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Данные отсутствуют!");

            _memCache[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Данные отсутствуют!");

            _memCache.RemoveAt(id);
        }
    }
}
