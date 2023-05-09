using MediatR;
using Portfolio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [EnumDataType(typeof(Role), ErrorMessage = "the value entered for the Role field is not valid")]
        public Role Role { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password confirmation doesn't match with your chosen password")]
        public string ConfirmPassword { get; set; }
    }
}
