using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferencePlannerApp.Queries;

namespace Conference.Api.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<List<ConferenceSystem.Models.Conference>> Get([FromQuery] SuggestionsQuery.Query query)
        {
            var result = await _mediator.Send(query);
            return result;
        }

        
    }
}