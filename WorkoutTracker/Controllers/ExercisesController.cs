using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Core.Contracts;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Dtos.Exersise;

namespace WorkoutTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IGenericRepo<Exercises> _repo;
        private readonly IMapper _mapper;

        public ExercisesController(IGenericRepo<Exercises> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetAllExercises()
        {
            var Exercises = await _repo.GetAllAsync();
            var MappedExercises = _mapper.Map<List<ExerciseDto>>(Exercises);
            return Ok(MappedExercises);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDto>> GetExerciseById(int id)
        {
            var Exercise = await _repo.GetByIdAsync(id);
            var MappedExercise = _mapper.Map<ExerciseDto>(Exercise);
            return Ok(MappedExercise);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateExercise([FromBody] CreateExerciseDto dto)
        {
            if (dto == null) return BadRequest();

            var MappedExercise = _mapper.Map<Exercises>(dto);
            var ExerciseCreated = await _repo.AddAsync(MappedExercise);

            if (!ExerciseCreated) return BadRequest();

            return CreatedAtAction(
                nameof(GetExerciseById),
                new { id = MappedExercise.Id },
                _mapper.Map<ExerciseDto>(MappedExercise) 
            );
        }



        #region WrongApi

        //[HttpPut("{id}")]
        //public async Task<ActionResult<ExerciseDto>> UpdateExercise(int id, [FromBody] CreateExerciseDto dto)
        //{
        //    var existingExercise = await _repo.GetByIdAsync(id);
        //    if (existingExercise == null) return NotFound();

        //    var MappedExercise = _mapper.Map<Exercises>(dto);
        //    var UpdatedExercise = await _repo.UpdateAsync(MappedExercise);
        //    if (!UpdatedExercise) return BadRequest();
        //    return Ok(_mapper.Map<ExerciseDto>(UpdatedExercise));
        //} 
        #endregion

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseDto>> UpdateExercise(int id, [FromBody] CreateExerciseDto dto)
        {
            // 1. Check if the exercise exists
            var existingExercise = await _repo.GetByIdAsync(id);
            if (existingExercise == null) return NotFound();

            // 2. Map dto values into the existing object (in-place update)
            _mapper.Map(dto, existingExercise); // Overwrite properties

            // 3. Save the changes
            var isUpdated = await _repo.UpdateAsync(existingExercise);
            if (!isUpdated) return BadRequest();

            // 4. Return updated object
            return Ok(_mapper.Map<ExerciseDto>(existingExercise));
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExercise(int id )
        {
            var Result = await _repo.DeleteAsync(id); 
            if (!Result) return BadRequest();

            return NoContent();
        }
        



    }
}
