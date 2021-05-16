using AutoMapper;
using PatientSystem.DB.Entities;
using PatientSystem.ViewModel.NOKDetails;
using PatientSystem.ViewModel.Patient;
using PatientSystem.ViewModel.PropertyItems;
using PatientSystem.ViewModel.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientSystem.Repository
{
    public class ReqResToEntityProfile : Profile
    {
        public ReqResToEntityProfile()
        {
            CreateMap<RelationShips, RelationshipsViewModel>();
            CreateMap<RelationshipsViewModel, RelationShips>();

            CreateMap<Patients, PatientViewModel>();
            CreateMap<PatientViewModel, Patients>();

            CreateMap<NOKDetails, NOKDetailsViewModel>()
                .ForMember(x => x.Patient,
                           y => y.MapFrom(src => src.Patient))
                .ForMember(x => x.Relationship,
                           y => y.MapFrom(src => src.Relationship));

            CreateMap<NOKDetailsViewModel, NOKDetails>()
                .ForMember(x => x.Patient,
                           y => y.MapFrom(src => src.Patient))
                 .ForMember(x => x.Relationship,
                           y => y.MapFrom(src => src.Relationship));


            CreateMap<PropertyItems, PropertyItemsViewModel>()
                .ForMember(x => x.Patient,
                           y => y.MapFrom(src => src.Patient));

            CreateMap<PropertyItemsViewModel, PropertyItems>()
                .ForMember(x => x.Patient,
                           y => y.MapFrom(src => src.Patient));
        }
    }
}
