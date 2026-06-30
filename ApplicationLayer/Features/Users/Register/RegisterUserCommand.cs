using ApplicationLayer.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users.Register
{
    public sealed record RegisterUserCommand(string FullName,string Email,string Password,int Age):IRequest<Result<int>>;
}
