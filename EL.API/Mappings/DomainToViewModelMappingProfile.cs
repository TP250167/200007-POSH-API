using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.Domain.Entities;
using EL.ViewModel;

namespace EL.API.Mappings
{

    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Schedule, ScheduleViewModel>()
                .ForMember(vm => vm.Creator,
                    map => map.MapFrom(s => s.Creator.Name))
                .ForMember(vm => vm.Attendees, map =>
                    map.MapFrom(s => s.Attendees.Select(a => a.UserId))).ReverseMap();

            CreateMap<Schedule, ScheduleDetailsViewModel>()
                .ForMember(vm => vm.Creator,
                    map => map.MapFrom(s => s.Creator.Name))
                .ForMember(vm => vm.Attendees, map =>
                    map.MapFrom(src=> new List<UserViewModel>()))
                .ForMember(vm => vm.Status, map =>
                    map.MapFrom(s => ((ScheduleStatus)s.Status).ToString()))
                .ForMember(vm => vm.Type, map =>
                    map.MapFrom(s => ((ScheduleType)s.Type).ToString()))
                .ForMember(vm => vm.Statuses, map =>
                    map.MapFrom(src=>Enum.GetNames(typeof(ScheduleStatus)).ToArray()))
                .ForMember(vm => vm.Types, map =>
                    map.MapFrom(src=>Enum.GetNames(typeof(ScheduleType)).ToArray())).ReverseMap();

            CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.TotalSchedulesCreated,
                    map => map.MapFrom(u => u.SchedulesCreated.Count()))
                .ForMember(vm => vm.Id,
                    map => map.MapFrom(u => u.Id))
                .ForMember(vm => vm.UserName,
                    map => map.MapFrom(u => u.UserName))
                .ForMember(vm => vm.Name,
                    map => map.MapFrom(u => u.Name))
                .ForMember(vm => vm.Avatar,
                    map => map.MapFrom(u => u.Avatar))
                .ForMember(vm => vm.Profession,
                    map => map.MapFrom(u => u.Profession))
                .ReverseMap();
        }
    }
}
