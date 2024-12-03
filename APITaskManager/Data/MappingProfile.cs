using APITaskManager.Domain;
using APITaskManager.ViewModels;
using AutoMapper;
using Task = APITaskManager.Domain.Task;

namespace APITaskManager.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Project, ProjectViewModel>();
            CreateMap<ProjectViewModel, Project>();


            CreateMap<Task, TaskViewModel>();
            CreateMap<TaskViewModel, Task>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => Utils.TaskStatus.Pending)); 

            
            //CreateMap<TaskHistory, TaskHistoryDto>();

            
            //CreateMap<Comment, CommentDto>();
        }
    }
}
