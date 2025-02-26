using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Feature.Posts.Commands.CreatePosts;
using Core.Domain.Entities;

namespace Application.Mappings
{
    public class PostMappings: Profile
    {
        public PostMappings()
        {
            CreateMap<Posts, PostDto>();
            CreateMap<PostDto, Posts>();

            CreateMap<CreatePostCommand, Posts>();
        }
    }
}