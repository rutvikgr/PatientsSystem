using AutoMapper;
using PatientSystem.Repository;
using PatientSystem.Repository.Implementation;
using PatientSystem.Repository.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PatientSystem
{
    /// <summary>
    /// Dependency injection unity configuration
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registering repositories for dependency injections
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<INOKDetailsRepository, NOKDetailsRepository>();
            container.RegisterType<IPropertyItemsRepository, PropertyItemsRepository>();
            container.RegisterType<IRelationshipRepository, RelationshipRepository>();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ReqResToEntityProfile>();
            });

            container.RegisterInstance<IMapper>(config.CreateMapper());
        }
    }
}