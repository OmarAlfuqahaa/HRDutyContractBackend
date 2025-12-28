using AutoMapper;
using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Commands;
using HRDutyContract.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractMonthlyShiftCommandHandler
       : IRequestHandler<ManageHRContractMonthlyShiftCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;
        private readonly IMapper _mapper;

        public ManageHRContractMonthlyShiftCommandHandler(IHRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AbstractViewModel> Handle(
    ManageHRContractMonthlyShiftCommand request,
    CancellationToken cancellationToken)
        {
            var response = new AbstractViewModel();

            try
            {
                if (request.Shift == null)
                {
                    response.lstError.Add("Shift object cannot be null.");
                    return response;
                }

                var existingShift = await _context.HRContractMonthlyShifts
                    .FirstOrDefaultAsync(x =>
                        x.DetailsID == request.Shift.DetailsID &&
                        x.ContractID == request.Shift.ContractID &&
                        x.CompanyID == request.Shift.CompanyID,
                        cancellationToken);

                if (request.IsDelete)
                {
                    if (existingShift == null)
                    {
                        response.lstError.Add("Shift not found for deletion.");
                        return response;
                    }

                    existingShift.RecordDeleted = true;
                    await _context.SaveChangesAsync(cancellationToken);

                    response.status = true;
                    response.EntityId = existingShift.DetailsID;
                    return response;
                }

                if (existingShift != null)
                {
                    existingShift.Month = request.Shift.Month;
                    existingShift.Year = request.Shift.Year;
                    existingShift.TotalShifts = request.Shift.TotalShifts;
                    existingShift.Note = request.Shift.Note;
                    existingShift.IsActive = request.Shift.IsActive;
                }
                else
                {
                    request.Shift.RecordDeleted = false;
                    await _context.HRContractMonthlyShifts
                        .AddAsync(request.Shift, cancellationToken);
                }

                await _context.SaveChangesAsync(cancellationToken);

                response.status = true;
                response.EntityId = request.Shift.DetailsID;
            }
            catch (Exception ex)
            {
                response.lstError.Add(ex.Message);
            }

            return response;
        }

    }
}
