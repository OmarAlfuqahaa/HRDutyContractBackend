using System.ComponentModel.DataAnnotations;

namespace HRDutyContract.Application.Common.Services
{
    public class UpdaterManager<T> where T : class
    {
        public T getUpdatedEntityBasedNewEntityWithNullsUpdate(T existing, T updated, System.Type commandType)
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                var isKey = prop.GetCustomAttributes(typeof(KeyAttribute), true).Any()
                            || prop.Name.Equals("ContractID", StringComparison.OrdinalIgnoreCase)
                            || prop.Name.Equals("CompanyID", StringComparison.OrdinalIgnoreCase);

                if (isKey || prop.Name.Equals("RecordDeleted", StringComparison.OrdinalIgnoreCase))
                    continue;

                var newValue = prop.GetValue(updated);
                if (newValue != null)
                    prop.SetValue(existing, newValue);
            }


            return existing;
        }
    }
}
