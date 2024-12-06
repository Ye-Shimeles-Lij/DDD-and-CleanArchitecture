using AutoMapper;
using EmployeePos.Domain.IRepositories;
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
    public class AddPositionCommand : IRequest<AddPositionCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public Guid Id { get; set; }
 
    }

    public class AddPositionHandler : IRequestHandler<AddPositionCommand, AddPositionCommand>
    {
        private readonly IPositionRepository _context;
        private readonly IMapper _mapper;

        public AddPositionHandler(IPositionRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<AddPositionCommand> Handle(AddPositionCommand request, CancellationToken cancellationToken)
        {
            var positions = new Domain.Models.Position(request.Name, request.Description, request.ParentId);
            var position = _mapper.Map<Domain.Models.Position>(request);
            await _context.AddPositionAsync(position);
            //return _mapper.Map<GetPo>(position);
            request.Id = position.Id;

            return request;
        }
    }
}
