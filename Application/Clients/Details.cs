using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Clients
{
    public class Details
    {
        public class Query : IRequest<Client>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Client>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Client> Handle(Query request, CancellationToken cancellationToken)
            {
                var client = await _context.Clients.FindAsync(request.Id);

                if (client == null) throw new Exception("Could not find client");

                return client;
            }
        }
    }
}