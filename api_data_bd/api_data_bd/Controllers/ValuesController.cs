using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_data_bd.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// This api Url to get all values
        /// </summary>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// This api Url to get a specific value
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// This api Url to update a value
        /// </summary>
        
        /// <param name="value">updated value</param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// This api Url to create single  value
        /// </summary>
        /// <param name="id">The id of the data</param>
        /// <param name="value">new value</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// This api Url to delete a single value
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        public void Delete(int id)
        {
        }
    }
}
