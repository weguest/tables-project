using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RuntimeCode.Core.Implementation.Entities;
using RuntimeCode.Core.Implementation.Repositories;
using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.Services;
using RuntimeCode.Core.Interfaces.UnitOfWork;

namespace RuntimeCode.Angular.Controllers
{
    [Route("api/[controller]")]
    public class ModuleController : Controller
    {

        IModuleRepository<Module> _service;
        IUnitOfWork _uow;
        IServiceProvider _serviceProvider;

        public ModuleController(IModuleRepository<Module> service, IUnitOfWork uow, IServiceProvider serviceProvider){
            this._service = service;
            this._uow = uow;
            this._serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IEnumerable<Module> Get()
        {
            return (List<Module>) _service.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Module> Post([FromBody] Module item)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            return _service.Add( item );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<bool> Delete(string id)
        {
            var find = _service.GetById(id);
            
            if(find == null)
                return NotFound();

           return _service.Delete( id ).DeletedCount > 0;
        }
        
    }
}