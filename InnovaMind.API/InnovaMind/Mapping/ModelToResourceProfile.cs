using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Resources;

namespace InnovaMind.API.InnovaMind.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<SocialNetwork, SocialNetworkResource>();
        CreateMap<Address, AddressResource>();
        CreateMap<Message, MessageResource>();
    }
}