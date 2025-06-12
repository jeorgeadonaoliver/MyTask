using MyTask.Application.Common.Dto;

namespace MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;

public class GetDataForUserRegistrationFormQueryDto : BaseDto
{
    public string name { get; set; } = string.Empty;
}
