using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresTraining.V1.Boundary.Request;

namespace PostgresTraining.V1.Controllers
{
    [ApiController]
    [Route("api/v1/residents")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class PostgresTrainingController : BaseController
    {
        private readonly IGetByIdUseCase _getByIdUseCase;
        private readonly IPostPersonUseCase _createPersonUseCase;
        private readonly IUpdatePersonUseCase _updatePersonUseCase;
        public PostgresTrainingController(IGetByIdUseCase getByIdUseCase, IPostPersonUseCase postPersonUseCase, IUpdatePersonUseCase updatePersonUseCase)
        {
            _getByIdUseCase = getByIdUseCase;
            _createPersonUseCase = postPersonUseCase;
            _updatePersonUseCase = updatePersonUseCase;
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No person found for the specified ID</response>
        [ProducesResponseType(typeof(ResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        [Route("{Id}")]
        public IActionResult ViewRecord(int yourId)
        {
            return Ok(_getByIdUseCase.Execute(yourId));
        }

        /// <summary>
        /// Create a new person record for a resident
        /// </summary>
        /// <response code="201">Successful operation</response>
        [ProducesResponseType(typeof(ResponseObject), StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult CreatePersonRecord([FromBody] PersonRequestObject createPersonRequestObject)
        {

            var person = _createPersonUseCase.Execute(createPersonRequestObject);
            return CreatedAtAction("ViewRecord", person);

        }

        /// <summary>
        /// Update a new person record for a resident
        /// </summary>
        /// <response code="200">Successful operation</response>
        [ProducesResponseType(typeof(ResponseObject), StatusCodes.Status204NoContent)]
        [HttpPatch]
        public IActionResult UpdatePersonRecord([FromBody] PersonRequestObject updatePersonRequestObject)
        {

            var person = _updatePersonUseCase.Execute(updatePersonRequestObject);
            return NoContent();

        }


    }
}
