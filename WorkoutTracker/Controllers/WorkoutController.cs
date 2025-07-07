using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Dtos.Workout;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IGenericRepo<Workouts> _repo;
        private readonly IMapper _mapper;

        public WorkoutController(IGenericRepo<Workouts> repo , IMapper mapper ) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<WorkoutReadDto>>> GetAllWorkouts()
        {
            var Workouts = await _repo.GetAllAsync();
            var MappedWorkouts = _mapper.Map<List<WorkoutReadDto>>( Workouts );
            return Ok(MappedWorkouts);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutReadDto>> GetWorkoutById(int id ) 
        {
            var Workout = await _repo.GetByIdAsync( id ); 
            return Ok( _mapper.Map<WorkoutReadDto>(Workout));     
        }

        [Authorize]
        [HttpPost] 
        public async Task<ActionResult> CreateWorkout([FromBody] WorkoutCreateDto dto )
        {
            if (dto == null) return BadRequest();
            //Mapping Workout From DTO  => Workout For AddAsync It In Repo => DbContext 
            var MappedWorkout = _mapper.Map<Workouts>(dto);
            var WorkoutCreated = await _repo.AddAsync(MappedWorkout); 
            if (!WorkoutCreated) return BadRequest();

            // 3. Return 201 Created + location of the new workout
            return CreatedAtAction(
                nameof(GetWorkoutById),                        // name of GET method
                new { id = MappedWorkout.Id },                 // route values
                _mapper.Map<WorkoutReadDto>(MappedWorkout)      // return DTO
                );    


        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutReadDto>> UpadateWorkout(int id, WorkoutUpdateDto dto)
        {
            if (dto == null)  return BadRequest(); 
            var existingWorkout = await _repo.GetByIdAsync(id);   
            if (existingWorkout == null) return NotFound();


            // 2. Map dto values into the existing object (in-place update)
            _mapper.Map(dto , existingWorkout);         //OverWrite On Existing WORKOUT  
            var isUpdated = await _repo.UpdateAsync(existingWorkout); 
            if (!isUpdated) return BadRequest(); 

            return Ok(_mapper.Map<WorkoutReadDto>(existingWorkout));

        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutById(int id) 
        {
            var result = await _repo.DeleteAsync( id );
            if (!result ) return BadRequest(); 
            return NoContent();
        }
    }
}
