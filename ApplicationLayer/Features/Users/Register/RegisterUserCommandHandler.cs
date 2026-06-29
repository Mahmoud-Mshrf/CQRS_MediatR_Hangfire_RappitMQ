using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users.Register
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
