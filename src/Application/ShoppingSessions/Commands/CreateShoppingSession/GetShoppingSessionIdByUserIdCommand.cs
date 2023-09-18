using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.ShoppingSessions.Commands.CreateShoppingSession;

public record GetShoppingSessionIdByUserIdCommand : IRequest<Guid>
{
    public int? UserId { get; set; }
}

public class GetShoppingSessionIdByUserIdCommandHandler : IRequestHandler<GetShoppingSessionIdByUserIdCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public GetShoppingSessionIdByUserIdCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(GetShoppingSessionIdByUserIdCommand request, CancellationToken cancellationToken)
    {
        ShoppingSession? currentUsersShoppingSession = null;
        if (request.UserId != null)
        {
            currentUsersShoppingSession = _context.ShoppingSessions.FirstOrDefault(a => a.UserId == request.UserId && );
        }

        if (currentUsersShoppingSession != null)
        {
            return currentUsersShoppingSession.Id;
        }
        else
        {
            var newShoppingSession = new ShoppingSession
            {
                UserId = request.UserId
            };

            _context.ShoppingSessions.Add(newShoppingSession);

            await _context.SaveChangesAsync(cancellationToken);

            return newShoppingSession.Id;
        }
    }
}