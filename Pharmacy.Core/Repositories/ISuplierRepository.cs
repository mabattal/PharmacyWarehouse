using Pharmacy.Core.Models;

namespace Pharmacy.Core.Repositories
{
    public interface ISuplierRepository : IGenericRepository<Suplier>
    {
        Task<Suplier> GetSingleSuplierByIdWithMedicineAsync(int suplierId);
    }
}
