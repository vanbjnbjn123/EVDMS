using EVDMS.Application.Features.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Implementation for creating a user goes here
            _logger.LogInformation("Creating user {@User}", request);
            // Call to the service layer to create the user
            var command = _mapper.Map<CreateUserCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
