using AutoMapper;
using MediatR;
using Portfolio.Application.Repositories;

namespace Portfolio.Application.Features.UserFeatures.GetAllUser
{
    public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserHandler(IUnitOfWork unitOfWork,
                                 IUserRepository userRepository,
                                 IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll(cancellationToken);

            List<GetAllUserResponse> result = new();
            foreach (var user in users)
            {
                result.Add(_mapper.Map<GetAllUserResponse>(user));
            }
            return result;
        }
    }
}
