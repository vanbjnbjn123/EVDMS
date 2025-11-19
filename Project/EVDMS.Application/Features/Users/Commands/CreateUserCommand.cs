namespace EVDMS.Application.Features.Users.Commands;

public record CreateUserCommand(
    string Username,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    DateTime? DateOfBirth,
    int Gender,
    string Address) : IRequest<Guid>;
