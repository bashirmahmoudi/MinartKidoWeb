﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinartKidoWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/places")]
    [Authorize]
    public class PlacesController : Controller
    {
        // GET: api/Places
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            //HttpContext.User.HasClaim(c => c.Type == "");
            await Task.Run(() => { });
            return new string[] { "value1", "value2" };
        }

        // GET: api/Places/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Places
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Places/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
