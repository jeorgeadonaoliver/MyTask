using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common.Dto;
using MyTask.Application.Features.UserManagement.Query.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Common.Extension
{
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
    }
}
