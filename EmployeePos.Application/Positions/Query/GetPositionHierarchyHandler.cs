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
    public class GetPositionHierarchyQuery : IRequest<List<PositionDto>> { }

    public class GetPositionHierarchyHandler : IRequestHandler<GetPositionHierarchyQuery, List<PositionDto>>
    {

        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public GetPositionHierarchyHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        public async Task<List<PositionDto>> Handle(GetPositionHierarchyQuery request, CancellationToken cancellationToken)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            const string sql = @" WITH RECURSIVE positionhierarchy AS 
                                    ( SELECT id, name, description, parent_id
                                    FROM pos.positions 
                                    WHERE parent_id IS NULL 
                                    UNION ALL 
                                    SELECT p.id, p.name, p.description, p.parent_id 
                                    FROM pos.positions p 
                                    JOIN positionhierarchy ph ON p.parent_id = ph.id )
                                    SELECT * FROM positionhierarchy";

            var positions = await _dbConnection.QueryAsync<PositionDto>(sql);
            return positions.ToList();

        }
    }
}
