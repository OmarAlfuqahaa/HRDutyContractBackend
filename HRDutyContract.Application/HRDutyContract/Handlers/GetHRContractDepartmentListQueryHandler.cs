using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Application.HRDutyContract.Queries;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractDepartmentCommandHandler
        : IRequestHandler<ManageHRContractDepartmentCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public ManageHRContractDepartmentCommandHandler(
            IHRContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbstractViewModel> Handle(
    ManageHRContractDepartmentCommand request,
    CancellationToken cancellationToken)
        {
            var result = new AbstractViewModel();

            // ===== Normalize =====
            if (request.Department.DepartmentID == 0)
                request.Department.DepartmentID = null;

            // ================= DELETE =================
            if (request.IsDelete)
            {
                var entity = await _context.HRContractDepartments
                    .FirstOrDefaultAsync(x =>
                        x.DetailsID == request.Department.DetailsID &&
                        x.ContractID == request.Department.ContractID &&
                        x.CompanyID == request.Department.CompanyID,
                        cancellationToken);

                if (entity == null)
                {
                    result.lstError.Add("Record not found");
                    return result;
                }

                entity.RecordDeleted = true;
                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                result.status = true;
                result.EntityId = entity.DetailsID;
                return result;
            }

            // ================= CREATE =================
            if (request.Department.DetailsID == 0)
            {
                var entity = _mapper.Map<HRContractDepartment>(request.Department);
                entity.RecordDateEntry = DateTime.Now;
                entity.RecordDeleted = false;
                entity.IsActive ??= true;

                await _context.HRContractDepartments.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result.status = true;
                result.EntityId = entity.DetailsID;
                return result;
            }

            // ================= UPDATE =================
            var existing = await _context.HRContractDepartments
                .FirstOrDefaultAsync(x =>
                    x.DetailsID == request.Department.DetailsID &&
                    x.ContractID == request.Department.ContractID &&
                    x.CompanyID == request.Department.CompanyID,
                    cancellationToken);

            if (existing == null)
            {
                result.lstError.Add("Record not found");
                return result;
            }

            _mapper.Map(request.Department, existing);
            await _context.SaveChangesAsync(cancellationToken);

            result.status = true;
            result.EntityId = existing.DetailsID;
            return result;
        }

    }
}