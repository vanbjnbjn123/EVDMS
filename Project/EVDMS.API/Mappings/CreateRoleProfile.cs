using System;
using EVDMS.Application.Features.Roles.Commands;

namespace EVDMS.API.Mappings;

public class CreateRoleProfile : Profile
{
    public CreateRoleProfile()
    {
        CreateMap<CreateRoleRequest, CreateRoleCommand>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsSystemRole, opt => opt.MapFrom(src => src.IsSystemRole ?? false));
    }
}
