using Microsoft.Extensions.DependencyInjection;

using RuntimeCode.Core.Interfaces.UnitOfWork;
using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.Services;

using RuntimeCode.Core.Implementation.UnitOfWork;
using RuntimeCode.Core.Implementation.Repositories;
using RuntimeCode.Core.Implementation.Services;

namespace RuntimeCode.Core.Initialization
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddExtInternalReferences(this IServiceCollection service){
            //todo: Adcionar Injecoes de Dependencia.
            service.AddScoped<IUnitOfWork>( s => new UnitOfWork("mongodb://localhost:27017/dbEnt"));
            service.AddScoped<IEntityTypeRepository, EntityTypeRepository>();
            service.AddScoped<IEntityTypeService, EntityTypeService>();
            return service;
        }
    }
}