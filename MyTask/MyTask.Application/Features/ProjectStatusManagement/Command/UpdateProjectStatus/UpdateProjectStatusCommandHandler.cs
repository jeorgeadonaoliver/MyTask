﻿using MediatR;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTask.Application.Features.ProjectStatusManagement.Command.UpdateProjectStatus
{
    public class UpdateProjectStatusCommandHandler : IRequestHandler<UpdateProjectStatusCommand, bool>
    {
        private readonly IProjectStatusRepository _repository;
        public UpdateProjectStatusCommandHandler(IProjectStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectStatusCommandValidation(_repository);
            var result = await validator.ValidateAsync(request, cancellationToken);
            result.CheckValidationResult();


            var response = await _repository.UpdateProjectStatus(request.MapToProjectStatus());
            return response;
        }
    }
}
