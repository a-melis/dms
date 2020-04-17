using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Clients
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            public DateTime? DateOfBirth { get; set; }

            public string Email { get; set; }
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
                
                client.FirstName = request.FirstName ?? client.FirstName;
                client.LastName = request.LastName ?? client.LastName;
                client.Address = request.Address ?? client.Address;
                client.DateOfBirth = request.DateOfBirth ?? client.DateOfBirth;
                client.Email = request.Email ?? client.Email;
                
                var succes = await _context.SaveChangesAsync() > 0;

                if (succes) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}