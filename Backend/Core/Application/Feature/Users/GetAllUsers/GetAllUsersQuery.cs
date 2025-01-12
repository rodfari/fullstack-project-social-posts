using Core.Application.Reponses.UserResponses;
using MediatR;

namespace Application.Feature.Users.GetAllUsers;
public class GetAllUsersQuery: IRequest<IEnumerable<GetUserResponse>>
{
        
}