using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyTask.Application.Common.Extension;
using MyTask.Application.Contracts;

namespace MyTask.Application.Features.UserManagement.Command.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _memoryCache;
    public RegisterUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _memoryCache = memoryCache;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();
        request.Id = Guid.NewGuid();
        var data = await _repository.CreateAsync(request.MapToEntity());
        await _unitOfWork.CommitTransactionAsync();
        _memoryCache.Remove("GetUserQuery");


        return data.Value;
    }
}
