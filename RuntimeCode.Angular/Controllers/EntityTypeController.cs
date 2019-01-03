using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using RuntimeCode.Core.Implementation.Entities;
using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Interfaces.Entities.Enums;
using RuntimeCode.Core.Interfaces.Services;
using RuntimeCode.Core.Interfaces.UnitOfWork;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.Net;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RuntimeCode.Angular.Controllers
{
    [Route("api/[controller]")]
    public class EntityTypeController : Controller
    {

        IEntityTypeService<EntityType> _service;
        IUnitOfWork _uow;
        IServiceProvider _serviceProvider;

        public EntityTypeController(IEntityTypeService<EntityType> service, IUnitOfWork uow, IServiceProvider serviceProvider){
            this._service = service;
            this._uow = uow;
            this._serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IEnumerable<EntityType> Get()
        {
            return (List<EntityType>) _service.SelectAll();
        }

        [HttpGet("{id}")]
        public ActionResult<EntityType> Get(string id)
        {
            var find = _service.GetById(id);
            
            if(find == null)
                return NotFound();

           return (EntityType)find;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<EntityType> Post([FromBody] EntityType item)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            return (EntityType)_service.Save(item);
        }

        [HttpPut("{id}")]
        public ActionResult<EntityType> Put([FromBody] EntityType item)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var find = _service.GetById(item?.Id);
            if(find == null){
                return NotFound();
            }

            item = (EntityType)_service.Save(item);

            return Ok(item);
        } 

    }

}
