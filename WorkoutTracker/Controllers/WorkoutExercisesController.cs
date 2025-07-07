using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Core.ModelsSpecs;
using WorkoutTracker.Dtos.Workout;
using WorkoutTracker.Dtos.WorkoutExercise;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExercisesController : ControllerBase
    {
        private readonly IGenericRepo<WorkoutExercises> _repo;
        private readonly IMapper _mapper;

        public WorkoutExercisesController(IGenericRepo<WorkoutExercises> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExerciseReadDto>>> GetAllWorkoutExercises()
        {
            var specs = new WorkoutExercisesSpecs(); 
            var WorkoutExercises = await _repo.GetAllWithSpecAsync(specs); 
            var MappedWorkoutExercises = _mapper.Map<List<WorkoutExerciseReadDto>>(WorkoutExercises);
            return Ok(MappedWorkoutExercises);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExerciseReadDto>> GetWorkoutById(int id)
        {
            var specs = new WorkoutExercisesSpecs();
            var Workout = await _repo.GetByIdWithSpecAsync(specs);
            return Ok(_mapper.Map<WorkoutExerciseReadDto>(Workout));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateWorkout([FromBody] WorkoutExerciseCreateDto dto)
        {
            if (dto == null) return BadRequest();
            //Mapping Workout From DTO  => Workout For AddAsync It In Repo => DbContext 
            var MappedWorkout = _mapper.Map<WorkoutExercises>(dto);
            var WorkoutCreated = await _repo.AddAsync(MappedWorkout);
            if (!WorkoutCreated) return BadRequest();

            // 3. Return 201 Created + location of the new workout
            return CreatedAtAction(
                nameof(GetWorkoutById),                        // name of GET method
                new { id = MappedWorkout.Id },                 // route values
                _mapper.Map<WorkoutExerciseReadDto>(MappedWorkout)      // return DTO
                );


        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutExerciseReadDto>> UpadateWorkout(int id, WorkoutExerciseUpdateDto dto)
        {
            if (dto == null) return BadRequest();
            var existingWorkout = await _repo.GetByIdAsync(id);
            if (existingWorkout == null) return NotFound();


            // 2. Map dto values into the existing object (in-place update)
            _mapper.Map(dto, existingWorkout);         //OverWrite On Existing WORKOUT  
            var isUpdated = await _repo.UpdateAsync(existingWorkout);
            if (!isUpdated) return BadRequest();

            return Ok(_mapper.Map<WorkoutExerciseReadDto>(existingWorkout));

        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutById(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return BadRequest();
            return NoContent();
        }
    }
}
