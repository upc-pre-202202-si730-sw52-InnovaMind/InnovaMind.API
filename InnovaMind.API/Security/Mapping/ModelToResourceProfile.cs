using AutoMapper;
using InnovaMind.API.Security.Domain.Models;
using InnovaMind.API.Security.Domain.Services.Communication;
using InnovaMind.API.Security.Resources;
namespace InnovaMind.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();

        CreateMap<User, UserResource>();
    }
}
