﻿using MediatR;
using MyTask.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.SprintStatusManagement.Command.CreateSprintStatus
{
    public class CreateSprintStatusCommand : BaseDto, IRequest<bool>
    {
        public DateTime? CreatedAt { get; set; }

        public string Name { get; set; } = null!;
    }
}
