using MediatR;

namespace Portfolio.Application.Features.UserFeatures.GetAllUser
{
    public sealed class GetAllUserRequest : IRequest<List<GetAllUserResponse>> 
    { 
    }
}
