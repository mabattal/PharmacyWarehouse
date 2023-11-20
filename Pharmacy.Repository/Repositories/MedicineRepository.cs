using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Repository.Repositories
{
    public class MedicineRepository : GenericRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Medicine>> GetMedicineWithSuplier()
        {
            return await _context.Medicines.Include(x => x.Suplier).ToListAsync();
        }
    }
}
