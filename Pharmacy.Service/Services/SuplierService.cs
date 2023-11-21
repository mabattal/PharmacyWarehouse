using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Core.Services;
using Pharmacy.Core.UnitOfWorks;

namespace Pharmacy.Service.Services
{
    public class SuplierService : Service<Suplier, SuplierDto>, ISuplierService
    {
        private readonly ISuplierRepository _suplierRepository;
        public SuplierService(IGenericRepository<Suplier> repository, IUnitOfWork unitOfWork, ISuplierRepository suplierRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _suplierRepository = suplierRepository;
        }

        public async Task<CustomResponseDto<SuplierDto>> AddAsync(SuplierCreateDto dto)
        {
            var newEntity = _mapper.Map<Suplier>(dto);
            await _suplierRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<SuplierDto>(newEntity);
            return CustomResponseDto<SuplierDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<SuplierWithMedicinesDto>> GetSingleSuplierByIdWithMedicineAsync(int suplierId)
        {
            var suplier = await _suplierRepository.GetSingleSuplierByIdWithMedicineAsync(suplierId);
            var suplierDto = _mapper.Map<SuplierWithMedicinesDto>(suplier);

            return CustomResponseDto<SuplierWithMedicinesDto>.Success(200, suplierDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(SuplierUpdateDto dto)
        {
            var entity = _mapper.Map<Suplier>(dto);
            _suplierRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
