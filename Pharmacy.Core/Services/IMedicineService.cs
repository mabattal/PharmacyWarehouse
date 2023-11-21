using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Services
{
    public interface IMedicineService : IService<Medicine, MedicineDto>
    {
        Task<CustomResponseDto<List<MedicineWithSuplierDto>>> GetMedicinesWithSuplierAsync();
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(MedicineUpdateDto dto);

        Task<CustomResponseDto<MedicineDto>> AddAsync(MedicineCreateDto dto);
    }
}
