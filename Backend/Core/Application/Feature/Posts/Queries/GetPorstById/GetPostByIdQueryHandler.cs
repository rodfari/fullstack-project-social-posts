using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Domain.Contracts;
using Core.Domain.Enums;
using MediatR;

namespace Core.Application.Feature.Posts.Queries.GetPorstById;
public class GetPostByIdQueryHandler: IRequestHandler<GetPostByIdQuery, TResponse<PostDto>>
{
    private readonly IPostsRepository _postsRepository;
    private readonly IMapper _mapper;
    public GetPostByIdQueryHandler(IPostsRepository postsRepository, IMapper mapper)
    {
        _postsRepository = postsRepository;
        _mapper = mapper;
    }
    public async Task<TResponse<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postsRepository.GetPostAndUserByIdAsync(request.Id);

        if (post == null)
        {
            return new TResponse<PostDto>().SetIsSuccess(false)
            .SetErrors(new List<Error>()
                { new Error{

                    Code = Enum.GetName(ErrorCodes.POST_NOT_FOUND),
                    Message = "Post not found!"
                }
                });
        }

        return new TResponse<PostDto>()
                .SetIsSuccess(true)
                .SetData(_mapper.Map<PostDto>(post));
    }
}