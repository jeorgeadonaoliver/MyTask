using System;
using System.Collections.Generic;

namespace MyTask.Api.Client.MyTaskDbModel;

public partial class TaskStatus
{
    public Guid StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
