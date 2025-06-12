namespace MyTask.Application.Common.Dto;

public class AuthResponseDto
{
    public string fullName { get; set; } = string.Empty; 

    public string token { get; set; } = string.Empty;

    public string role { get; set; } = string.Empty;
}
