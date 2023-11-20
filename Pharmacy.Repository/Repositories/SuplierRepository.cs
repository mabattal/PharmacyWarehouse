using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;

namespace Pharmacy.Repository.Repositories
{
    public class SuplierRepository : GenericRepository<Suplier>, ISuplierRepository
    {
        public SuplierRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Suplier> GetSingleSuplierByIdWithMedicineAsync(int suplierId)
        {
            return await _context.Supliers.Include(x=>x.Medicines).Where(x=>x.Id == suplierId).SingleOrDefaultAsync();
        }
    }
}
