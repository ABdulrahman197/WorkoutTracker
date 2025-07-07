using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Dtos.ExerciseLog;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseLogController : ControllerBase
    {
        private readonly IGenericRepo<ExerciseLog> _repo;
        private readonly IMapper _mapper;

        public ExerciseLogController(IGenericRepo<ExerciseLog> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/ExerciseLog
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseLogReadDto>>> GetAll()
        {
            var logs = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExerciseLogReadDto>>(logs));
        }

        // GET by WorkoutExerciseId
        [Authorize]
        [HttpGet("workoutExercise/{workoutExerciseId}")]
        public async Task<ActionResult<IEnumerable<ExerciseLogReadDto>>> GetByWorkoutExercise(int workoutExerciseId)
        {
            var logs = await _repo.GetByWorkoutExerciseIdAsync(workoutExerciseId);

            if (logs == null || !logs.Any())
                return NotFound($"No logs found for WorkoutExercise ID {workoutExerciseId}");

            return Ok(_mapper.Map<IEnumerable<ExerciseLogReadDto>>(logs));
        }


        // POST: api/ExerciseLog
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateExerciseLogDto dto)
        {
            if (dto == null) return BadRequest();

            var log = _mapper.Map<ExerciseLog>(dto);
            var created = await _repo.AddAsync(log);

            if (!created) return BadRequest("Error creating log.");

            return Ok(_mapper.Map<ExerciseLogReadDto>(log));
        }

        // DELETE: api/ExerciseLog/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           

            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return BadRequest("Error deleting log.");

            return NoContent();
        }
    }
}
