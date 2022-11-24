using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Resources;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace InnovaMind.API.InnovaMind.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<SocialNetwork, SocialNetworkResource>();
        CreateMap<Address, AddressResource>();
        CreateMap<Company, CompanyResource>();
        CreateMap<Post, PostResource>();
        CreateMap<Recruiter, RecruiterResource>();
        CreateMap<Message, MessageResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<Driver, DriverResource>();
        CreateMap<Driverprofile, DriverprofileResource>();
        CreateMap<License, LicenseResource>();
        CreateMap<Education, EducationResource>();
        CreateMap<School, SchoolResource>();
    }
}