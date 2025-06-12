using MyTask.Api.Client.MyTaskDbModel;
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
}
