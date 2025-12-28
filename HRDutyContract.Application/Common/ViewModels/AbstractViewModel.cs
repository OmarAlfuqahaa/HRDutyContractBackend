using System.Collections.Generic;

namespace HRDutyContract.Application.Common.ViewModels
{
    public class AbstractViewModel
    {
        public bool status { get; set; } = false;
        public int EntityId { get; set; }
        public List<string> lstError { get; set; } = new List<string>();

        public List<AbstractViewModel> lstResult { get; set; } = new List<AbstractViewModel>();

    }
}
