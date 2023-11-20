using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Repositories
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        Task<List<Medicine>> GetMedicineWithSuplier();
    }
}
