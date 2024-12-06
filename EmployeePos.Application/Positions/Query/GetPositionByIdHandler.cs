using AutoMapper;
using EmployeePos.Domain;
using EmployeePos.Persistence;
using MediatR;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePos.Application.DTOs;

namespace EmployeePos.Application.Position.Query
{
    public class GetPositionByIdQuery : IRequest<PositionDto>
    {
        public Guid Id { get; set; }
    }
    public class GetPositionByIdHandler : IRequestHandler<GetPositionByIdQuery, PositionDto>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public GetPositionByIdHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        public async Task<PositionDto> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            const string sql = "SELECT * FROM pos.positions WHERE id = @id";
            var position = await _dbConnection.QuerySingleOrDefaultAsync<PositionDto>(sql, new { Id = request.Id });
            return position;

        }
    }
}
