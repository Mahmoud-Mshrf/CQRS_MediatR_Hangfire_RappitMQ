using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users.Register
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IMediator _mediator;
        public RegisterUserCommandHandler(IApplicationDbContext context, IPasswordHasher<User> hasher, IMediator mediator)
        {
            _context = context;
            _hasher = hasher;
            _mediator = mediator;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Age = request.Age, Email = request.Email, FullName = request.FullName, Password = _hasher.HashPassword(null, request.Password) };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new UserRegisteredNotification(user.FullName, user.UserId, user.Email));
            return user.UserId;
        }
    }
}
