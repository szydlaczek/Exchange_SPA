using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public string EmailAddress { get; set; }

        public decimal WalletAmount { get; set; }
    }
}
