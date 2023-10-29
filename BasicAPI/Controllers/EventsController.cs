using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> { new Event { Id = 1, Title = "default" ,Start=DateTime.Now,End=DateTime.Now.AddHours(5)} };
        private static int cnt = 2;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]


        public void Post([FromBody] Event newevent) 
        {
            events.Add(new Event { Id = cnt++, Title =newevent.Title,Start=newevent.Start,End=newevent.End});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Event newevent)
        {
            Event newevent1 = events.Find(e => e.Id == id);
            newevent1.Title=newevent.Title;
            newevent1.Start=newevent.Start;
            newevent1.End=newevent.End;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event newevent = events.Find(e => e.Id == id); 
            if(newevent!=null)
            events.Remove(newevent);



        }
    }
}
