using Microsoft.AspNetCore.Mvc;
using SkeletonAPI.DataAccess;
using SkeletonAPI.Models;

namespace SkeletonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly UserRepository _weatherForecastRepository;

        public UserController(ILogger<UserController> logger, UserRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostAsync([FromBody] UserCreateRequest request, CancellationToken cancellationToken)
        {
            User weatherForecast = new User
            {
                _id = request._id,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
            };

            await _weatherForecastRepository.InsertAsync(weatherForecast, cancellationToken);

            return Ok(weatherForecast);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<User>> GetAsync([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var weatherForecast = await _weatherForecastRepository.GetAsync(userId, cancellationToken);

            return Ok(weatherForecast);
        }

        [HttpPut]
        public async Task<ActionResult<User>> PutAsync([FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            User weatherForecastUpdate = new User
            {
                _id = request._id,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
            };

            var weatherForecastResponse = await _weatherForecastRepository.UpdateAsync(weatherForecastUpdate, cancellationToken);

            return Ok(weatherForecastResponse);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var success = await _weatherForecastRepository.DeleteAsync(userId, cancellationToken);

            return success ? Ok(true) : new StatusCodeResult(500);
        }
    }
}
