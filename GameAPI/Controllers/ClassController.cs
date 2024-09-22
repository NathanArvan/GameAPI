using GameDomain.Classes;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class ClassController : Controller
    {
        private ClassService _service;

        public ClassController(ClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async  Task<List<Class>> GetClasses()
        {
            return await _service.GetClasses();
        }
    }
}
