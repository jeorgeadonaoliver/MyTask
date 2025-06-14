using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Features.RoleManagement.Command.CreateUserRole;
using MyTask.Application.Features.RoleManagement.Query.GetUserRole;
using MyTask.Application.Features.UserManagement.Query.GetDataForUserRegistrationForm;

namespace MyTask.Application.Common.Extension;

public static class UserRoleExtension
{
    public static GetDataForUserRegistrationFormQueryDto MapToGetDataForUserRegistrationForm(this UserRole userRole) {

        return new GetDataForUserRegistrationFormQueryDto { 
        
            Id = userRole.RoleId,
            name = userRole.Name,
        };
    }

    public static GetUserRoleQueryDto MapToGetUserRoleQueryDto(this UserRole userRole) {

        return new GetUserRoleQueryDto() { 
        
            Id = userRole.RoleId,
            Name = userRole.Name,
            CreatedAt = userRole.CreatedAt,
        };
    }
}
