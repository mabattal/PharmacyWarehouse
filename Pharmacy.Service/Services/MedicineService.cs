using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Core.Services;
using Pharmacy.Core.UnitOfWorks;

namespace Pharmacy.Service.Services
{
    public class MedicineService : Service<Medicine, MedicineDto>, IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineService(IGenericRepository<Medicine> repository, IUnitOfWork unitOfWork, IMedicineRepository medicineRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task<CustomResponseDto<MedicineDto>> AddAsync(MedicineCreateDto dto)
        {
            var newEntity = _mapper.Map<Medicine>(dto);
            await _medicineRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<MedicineDto>(newEntity);
            return CustomResponseDto<MedicineDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<MedicineWithSuplierDto>>> GetMedicineWithSuplier()
        {
            var medicines = await _medicineRepository.GetMedicineWithSuplier();
            var medicinesDto = _mapper.Map<List<MedicineWithSuplierDto>>(medicines);

            return CustomResponseDto<List<MedicineWithSuplierDto>>.Success(200, medicinesDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(MedicineUpdateDto dto)
        {
            var entity = _mapper.Map<Medicine>(dto);
            _medicineRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
