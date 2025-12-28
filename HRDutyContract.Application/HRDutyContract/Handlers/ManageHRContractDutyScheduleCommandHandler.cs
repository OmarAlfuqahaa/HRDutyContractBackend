using HRDutyContract.Application.Common.Interfaces;
using HRDutyContract.Domain.Entities;
using MediatR;
using HRDutyContract.Application.HRDutyContract.Commands;
using Microsoft.EntityFrameworkCore;
using HRDutyContract.Application.Common.ViewModels;
using HRDutyContract.Application.Common.Services;

namespace HRDutyContract.Application.HRDutyContract.Handlers
{
    public class ManageHRContractDutyScheduleCommandHandler
        : IRequestHandler<ManageHRContractDutyScheduleCommand, AbstractViewModel>
    {
        private readonly IHRContext _context;

        public ManageHRContractDutyScheduleCommandHandler(IHRContext context)
        {
            _context = context;
        }

        public async Task<AbstractViewModel> Handle(ManageHRContractDutyScheduleCommand request, CancellationToken cancellationToken)
        {
            var vm = new AbstractViewModel();
            vm.lstResult = new List<AbstractViewModel>(); 

            foreach (var item in request.Schedules)
            {
                var singleVm = new AbstractViewModel();
                try
                {
                    // DELETE
                    if (item.IsDelete)
                    {
                        if (item.DetailsID <= 0)
                        {
                            singleVm.lstError.Add("Cannot delete a record with invalid DetailsID.");
                        }
                        else
                        {
                            var existingDelete = await _context.HRContractDutySchedules
                                .FirstOrDefaultAsync(x => x.DetailsID == item.DetailsID, cancellationToken);

                            if (existingDelete == null)
                            {
                                singleVm.lstError.Add($"Record with DetailsID = {item.DetailsID} does not exist.");
                            }
                            else
                            {
                                existingDelete.RecordDeleted = true;
                                existingDelete.IsActive = false;
                                await _context.SaveChangesAsync(cancellationToken);

                                singleVm.EntityId = existingDelete.DetailsID;
                                singleVm.status = true;
                            }
                        }
                        vm.lstResult.Add(singleVm);
                        continue;
                    }

                    // CREATE
                    if (item.DetailsID == 0)
                    {
                        var newEntity = new HRContractDutySchedule
                        {
                            ContractID = item.ContractID,
                            CompanyID = item.CompanyID,
                            ShiftTypeID = item.ShiftTypeID,
                            FromTime = item.FromTime != null ? TimeSpan.Parse(item.FromTime) : null,
                            ToTime = item.ToTime != null ? TimeSpan.Parse(item.ToTime) : null,
                            ShiftTotalHours = item.ShiftTotalHours != null ? TimeSpan.Parse(item.ShiftTotalHours) : null,
                            Multiplier = item.Multiplier,
                            InCall_Multiplier = item.InCall_Multiplier,
                            OnCall_Multiplier = item.OnCall_Multiplier,
                            Amount = item.Amount,
                            BaseLine = item.BaseLine,
                            AllowanceTypeID = item.AllowanceTypeID,
                            AllowanceTypeID2 = item.AllowanceTypeID2,
                            IsWithSalaryCalculate = item.IsWithSalaryCalculate,
                            ShiftBehaviorID = item.ShiftBehaviorID,
                            MonthlyMaxShifts = item.MonthlyMaxShifts,
                            HolidayMultiplier = item.HolidayMultiplier,
                            HolidayInCall_Multiplier = item.HolidayInCall_Multiplier,
                            HolidayOnCall_Multiplier = item.HolidayOnCall_Multiplier,
                            IsActive = item.IsActive ?? true,
                            Note = item.Note,
                            RecordAddBy = item.RecordAddBy,
                            RecordUpdateBy = item.RecordUpdateBy,
                            RecordNote = item.RecordNote,
                            RecordDeleted = false,
                            RecordDateEntry = item.RecordDateEntry ?? DateTime.Now
                        };

                        _context.HRContractDutySchedules.Add(newEntity);
                        await _context.SaveChangesAsync(cancellationToken);

                        singleVm.EntityId = newEntity.DetailsID;
                        singleVm.status = true;
                        vm.lstResult.Add(singleVm);
                        continue;
                    }

                    // UPDATE
                    var existingUpdate = await _context.HRContractDutySchedules
                        .FirstOrDefaultAsync(x => x.DetailsID == item.DetailsID, cancellationToken);

                    if (existingUpdate == null)
                    {
                        singleVm.lstError.Add($"Record with DetailsID = {item.DetailsID} does not exist, cannot update.");
                        vm.lstResult.Add(singleVm);
                        continue;
                    }

                    existingUpdate.ContractID = item.ContractID != 0 ? item.ContractID : existingUpdate.ContractID;
                    existingUpdate.CompanyID = item.CompanyID != 0 ? item.CompanyID : existingUpdate.CompanyID;
                    existingUpdate.ShiftTypeID = item.ShiftTypeID ?? existingUpdate.ShiftTypeID;
                    if (item.FromTime != null)
                        existingUpdate.FromTime = TimeSpan.Parse(item.FromTime);

                    if (item.ToTime != null)
                        existingUpdate.ToTime = TimeSpan.Parse(item.ToTime);

                    if (item.ShiftTotalHours != null)
                        existingUpdate.ShiftTotalHours = TimeSpan.Parse(item.ShiftTotalHours);

                    existingUpdate.Multiplier = item.Multiplier ?? existingUpdate.Multiplier;
                    existingUpdate.InCall_Multiplier = item.InCall_Multiplier ?? existingUpdate.InCall_Multiplier;
                    existingUpdate.OnCall_Multiplier = item.OnCall_Multiplier ?? existingUpdate.OnCall_Multiplier;
                    existingUpdate.Amount = item.Amount ?? existingUpdate.Amount;
                    existingUpdate.BaseLine = item.BaseLine ?? existingUpdate.BaseLine;
                    existingUpdate.AllowanceTypeID = item.AllowanceTypeID ?? existingUpdate.AllowanceTypeID;
                    existingUpdate.AllowanceTypeID2 = item.AllowanceTypeID2 ?? existingUpdate.AllowanceTypeID2;
                    existingUpdate.IsWithSalaryCalculate = item.IsWithSalaryCalculate ?? existingUpdate.IsWithSalaryCalculate;
                    existingUpdate.ShiftBehaviorID = item.ShiftBehaviorID ?? existingUpdate.ShiftBehaviorID;
                    existingUpdate.MonthlyMaxShifts = item.MonthlyMaxShifts ?? existingUpdate.MonthlyMaxShifts;
                    existingUpdate.HolidayMultiplier = item.HolidayMultiplier ?? existingUpdate.HolidayMultiplier;
                    existingUpdate.HolidayInCall_Multiplier = item.HolidayInCall_Multiplier ?? existingUpdate.HolidayInCall_Multiplier;
                    existingUpdate.HolidayOnCall_Multiplier = item.HolidayOnCall_Multiplier ?? existingUpdate.HolidayOnCall_Multiplier;
                    existingUpdate.IsActive = item.IsActive ?? existingUpdate.IsActive;
                    existingUpdate.Note = item.Note ?? existingUpdate.Note;
                    existingUpdate.RecordAddBy = item.RecordAddBy ?? existingUpdate.RecordAddBy;
                    existingUpdate.RecordUpdateBy = item.RecordUpdateBy ?? existingUpdate.RecordUpdateBy;
                    existingUpdate.RecordNote = item.RecordNote ?? existingUpdate.RecordNote;

                    await _context.SaveChangesAsync(cancellationToken);

                    singleVm.EntityId = existingUpdate.DetailsID;
                    singleVm.status = true;
                    vm.lstResult.Add(singleVm);
                }
                catch (Exception ex)
                {
                    singleVm.lstError.Add($"Error processing DetailsID = {item.DetailsID}: {ex.Message}");
                    vm.lstResult.Add(singleVm);
                }
            }

            vm.status = true;
            return vm;
        }
    }
}
