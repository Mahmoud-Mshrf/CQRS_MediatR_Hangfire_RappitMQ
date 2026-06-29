using ApplicationLayer.Dtos;
using ApplicationLayer.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users.GetUserProfile
{
    public sealed record GetUserQuery(int id) : IRequest<UserProfileDto>;
    public sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserProfileDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper mapper;

        public GetUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user =await _dbContext.Users.Where(x=>x.UserId==request.id).ProjectTo<UserProfileDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return user;
        }
    }
    
}
