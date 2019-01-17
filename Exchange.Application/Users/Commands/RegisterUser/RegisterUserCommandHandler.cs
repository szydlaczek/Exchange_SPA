using Exchange.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response>
    {
        private readonly UserManager<User> _userManager;
        
        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.Adapt<User>();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
                return new Response();
            else
                return new Response().AddError(result.Errors.FirstOrDefault().Description);
        }
    }
}
