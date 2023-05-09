using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
