using System;
using System.Collections.Generic;

namespace MyTask.Api.Client.MyTaskDbModel;

public partial class UserRole
{
    public Guid RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
