using Core.Application.Reponses;
using Core.Application.Reponses.UserResponses;
using MediatR;

namespace Application.Feature.Users.GetUserById;
public class GetUserByIdQuery : IRequest<TResponse<GetUserResponse>>
{
    public int Id { get; set; }
}