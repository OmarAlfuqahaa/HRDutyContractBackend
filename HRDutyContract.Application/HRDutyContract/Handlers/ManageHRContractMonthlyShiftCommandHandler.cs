using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.HRDutyContract.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractMonthlyShiftCommandHandler
       : IRequestHandler<ManageHRContractMonthlyShiftCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;

        public ManageHRContractMonthlyShiftCommandHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<AbstractViewModel> Handle(
            ManageHRContractMonthlyShiftCommand request,
            CancellationToken cancellationToken)
        {
            var response = new AbstractViewModel();

            foreach (var item in request.Shifts)
            {
                var singleResult = new AbstractViewModel();

                try
                {
                    if (item.Shift == null)
                    {
                        singleResult.lstError.Add("Shift object cannot be null.");
                        response.lstResult.Add(singleResult);
                        continue;
                    }

                    var existing = await _context.HRContractMonthlyShifts
                        .FirstOrDefaultAsync(x =>
                            x.DetailsID == item.Shift.DetailsID &&
                            x.ContractID == item.Shift.ContractID &&
                            x.CompanyID == item.Shift.CompanyID,
                            cancellationToken);

                    // DELETE
                    if (item.IsDelete)
                    {
                        if (existing == null)
                        {
                            singleResult.lstError.Add("Shift not found for deletion.");
                        }
                        else
                        {
                            existing.RecordDeleted = true;
                            existing.IsActive = false;
                            await _context.SaveChangesAsync(cancellationToken);

                            singleResult.status = true;
                            singleResult.EntityId = existing.DetailsID;
                        }

                        response.lstResult.Add(singleResult);
                        continue;
                    }

                    // UPDATE
                    if (existing != null)
                    {
                        existing.Month = item.Shift.Month;
                        existing.Year = item.Shift.Year;
                        existing.TotalShifts = item.Shift.TotalShifts;
                        existing.Note = item.Shift.Note;
                        existing.IsActive = item.Shift.IsActive;
                        existing.TotalHours = item.Shift.TotalHours;

                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = existing.DetailsID;
                    }
                    // CREATE
                    else
                    {
                        item.Shift.RecordDeleted = false;
                        await _context.HRContractMonthlyShifts
                            .AddAsync(item.Shift, cancellationToken);

                        await _context.SaveChangesAsync(cancellationToken);

                        singleResult.status = true;
                        singleResult.EntityId = item.Shift.DetailsID;
                    }
                }
                catch (Exception ex)
                {
                    singleResult.lstError.Add(ex.Message);
                }

                response.lstResult.Add(singleResult);
            }

            response.status = true;
            return response;
        }
    }
}
