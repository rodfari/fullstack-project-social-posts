
using Core.Application.Reponses;
using Core.Application.Reponses.UserResponses;
using Core.Domain.Contracts;
using MediatR;

namespace Application.Feature.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, TResponse<GetUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<TResponse<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user =  await _userRepository.GetByIdAsync(request.Id);
        var userResponse = new GetUserResponse()
        {
            Id = user.Id,
            UserName = user.Username,
        };
        return new TResponse<GetUserResponse>(){
            Success = true,
            Data = userResponse
        };
        }
    }
}