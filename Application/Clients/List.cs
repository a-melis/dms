using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Clients
{
    public class List
    {
        public class Query : IRequest<List<Client>> { }

        public class Handler : IRequestHandler<Query, List<Client>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }
            public async Task<List<Client>> Handle(Query request, CancellationToken cancellationToken)
            {
                var clients = await _context.Clients.ToListAsync();
                return clients;
            }
        }
    }
}