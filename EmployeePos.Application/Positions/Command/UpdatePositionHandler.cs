using AutoMapper;
using EmployeePos.Application.DTOs;
using EmployeePos.Domain;
using EmployeePos.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePos.Application.Position.Command
{
    public class UpdatePositionCommand : IRequest<GetPo>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public Guid Id { get; set; }
      
    }
    public class UpdatePositionHandler : IRequestHandler<UpdatePositionCommand, GetPo>
    {
        private readonly PositionDbContext _context;
        private readonly IMapper _mapper;
        public UpdatePositionHandler(PositionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetPo> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            //var positions = new Domain.Position(request.Name, request.Description, request.ParentId);
            var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (position == null) 
            {
                throw new Exception("position not found");
            };

            position.Name = request.Name;
            position.Description = request.Description;
            position.ParentId = request.ParentId;

            _context.Positions.Update(position);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GetPo>(position);
        }
    }
}
