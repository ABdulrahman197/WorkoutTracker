using AutoMapper;
using AutoMapper.Execution;
using WorkoutTracker.Core.Entites;
using WorkoutTracker.Dtos.Account;
using WorkoutTracker.Dtos.ExerciseLog;
using WorkoutTracker.Dtos.Exersise;
using WorkoutTracker.Dtos.Workout;
using WorkoutTracker.Dtos.WorkoutExercise;

namespace WorkoutTracker.helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Exercises, CreateExerciseDto>().ReverseMap();
            CreateMap<Exercises, ExerciseDto>().ReverseMap();


            CreateMap<Workouts,WorkoutCreateDto>().ReverseMap();
            CreateMap<Workouts,WorkoutUpdateDto>().ReverseMap();
            CreateMap<Workouts,WorkoutReadDto>().ReverseMap();


            CreateMap<ApplicationUser, UserDto>().ReverseMap(); 


            CreateMap<WorkoutExercises,WorkoutExerciseCreateDto>().ReverseMap();
            CreateMap<WorkoutExercises, WorkoutExerciseUpdateDto>().ReverseMap(); 

            CreateMap<WorkoutExercises, WorkoutExerciseReadDto>()
                .ForMember(dest => dest.ExerciseName,opt => opt.MapFrom(src => src.exercises.Name))
                .ForMember(dest => dest.WorkoutName, opt => opt.MapFrom(opt => opt.Workout.Name));


            CreateMap<ExerciseLog, CreateExerciseLogDto>().ReverseMap();
            CreateMap<ExerciseLog, ExerciseLogReadDto>().ReverseMap();




















            
        }
    }
}
