using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Clients
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var client = await _context.Clients.FindAsync(request.Id);
                if (client == null)
                    throw new Exception("Could not find client");

                _context.Remove(client);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}