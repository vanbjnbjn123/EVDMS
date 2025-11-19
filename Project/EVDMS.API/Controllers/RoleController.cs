using EVDMS.Application.Features.Roles.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Implementation for creating a role goes here
            _logger.LogInformation("Creating role {@Role}", request);
            // Call to the service layer to create the role
            var command = _mapper.Map<CreateRoleCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
