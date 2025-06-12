using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.UserManagement.Query.GetUser;
using MyTask.Application.Features.UserManagement.Query.GetUserById;

namespace MyTask.Application.Common.Extension;

public static class UserExtension 
{
    public static GetUserByIdDto MapToGetUserByIdDto(this User user) 
    {
        return new GetUserByIdDto() { 
        
            UserId = user.UserId,
            RoleId = user.RoleId,
            Email = user.Email,
            AvatarUrl = user.AvatarUrl,
            FullName = user.FullName,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            PasswordHash = user.PasswordHash
        };
    }

    public static GetUserQueryDto MapToGetUserQueryDto(this User user) 
    {
        return new GetUserQueryDto()
        {
            Id = user.UserId,
            RoleId = user.RoleId,
            Email = user.Email,
            AvatarUrl = user.AvatarUrl,
            FullName = user.FullName,
            CreatedAt= user.CreatedAt,
            IsActive = user.IsActive,
            UpdatedAt = user.UpdatedAt,
        };
    }
}
