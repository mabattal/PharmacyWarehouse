using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public interface ISuplierService : IService<Suplier>
    {
        Task<CustomResponseDto<SuplierWithMedicinesDto>> GetSingleSuplierByIdWithMedicineAsync(int suplierId);
    }
}
