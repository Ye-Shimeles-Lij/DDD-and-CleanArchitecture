using EmployeePos.Domain;
using EmployeePos.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Position.Command
{
    public class DeletePositionCommand : IRequest<DeletePositionCommand>
    {
        public Guid Id { get; set; }
    }

    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, DeletePositionCommand>
    {
        private readonly PositionDbContext _context;
        public DeletePositionCommandHandler(PositionDbContext context)
        {
            _context = context;
        }
        public async Task<DeletePositionCommand> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions.FindAsync(request.Id);
            if (position == null)
                throw new Exception("no");
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync(cancellationToken);
            return request;

        }
    }
}
