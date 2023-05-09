using AutoMapper;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.UserFeatures.GetAllUser
{
    public sealed class GetAllUserMapper : Profile
    {
        public GetAllUserMapper()
        {
            CreateMap<User, GetAllUserResponse>();
        }
    }
}
