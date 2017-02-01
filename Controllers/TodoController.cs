using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BetPlatformAlpha.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult  Index()
        {
            return View();
        }

        /// <summary>
        /// TODO://refactor async 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<TodoTask> TodoTasks()
        {
            //test stub 
            List<TodoTask> task = new List<TodoTask>();
            
            task.Add(new TodoTask("TestTask1", DateTime.Now));
            task.Add(new TodoTask("TestTask2", DateTime.Now));
            return task; 
        }
    }

    public class TodoTask
    {
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        double Weight { get; set; }

        public TodoTask(string taskName, DateTime deadline)
        {
            TaskName = taskName;
            Deadline = deadline; 
        }
    }
}
