using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Clients
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            public DateTime DateOfBirth { get; set; }

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
                var client = new Client
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    DateOfBirth = request.DateOfBirth
                };

                _context.Clients.Add(client);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}