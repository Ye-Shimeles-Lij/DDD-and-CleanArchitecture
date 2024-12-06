using AutoMapper;
using EmployeePos.Domain;
using EmployeePos.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.Common;
using EmployeePos.Application.DTOs;

namespace EmployeePos.Application.Position.Query
{
    public class GetAllPositionsQuery : IRequest<List<GetPo>>
    {
    }
    public class GetAllPositionsHandler : IRequestHandler<GetAllPositionsQuery, List<GetPo>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public GetAllPositionsHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection; 
            _mapper = mapper;
        }
        public async Task<List<GetPo>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            const string sql = "SELECT * FROM pos.positions";
            var positions = await _dbConnection.QueryAsync<GetPo>(sql);
            return positions.ToList();
        }
    }
}
