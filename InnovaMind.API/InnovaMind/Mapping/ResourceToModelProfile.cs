using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Resources;
namespace InnovaMind.API.InnovaMind.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveSocialNetworkResource, SocialNetwork> ();
        CreateMap<SaveAddressResource, Address> ();
        CreateMap<SavePostResource, Post> ();
        CreateMap<SaveCompanyResource, Company> (); 
        CreateMap<SaveRecruiterResource, Recruiter> ();
        CreateMap<SaveMessageResource, Message> ();
        CreateMap<SaveNotificationResource, Notification> ();
        CreateMap<SaveDriverResource, Driver> ();
        CreateMap<SaveDriverprofileResource, Driverprofile> ();
        CreateMap<SaveEducationResource, Education> ();
        CreateMap<SaveLicenseResource, License> ();
        CreateMap<SaveSchoolResource, School> ();
    }
}
