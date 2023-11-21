using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Services
{
    public interface ISuplierService : IService<Suplier, SuplierDto>
    {
        Task<CustomResponseDto<SuplierWithMedicinesDto>> GetSingleSuplierByIdWithMedicineAsync(int suplierId);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(SuplierUpdateDto dto);

        Task<CustomResponseDto<SuplierDto>> AddAsync(SuplierCreateDto dto);
    }
}
