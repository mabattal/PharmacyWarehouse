using AutoMapper;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Core.Services;
using Pharmacy.Core.UnitOfWorks;

namespace Pharmacy.Service.Services
{
    public class SuplierService : Service<Suplier>, ISuplierService
    {
        private readonly ISuplierRepository _suplierRepository;
        private readonly IMapper _mapper;
        public SuplierService(IGenericRepository<Suplier> repository, IUnitOfWork unitOfWork, ISuplierRepository suplierRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _suplierRepository = suplierRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<SuplierWithMedicinesDto>> GetSingleSuplierByIdWithMedicineAsync(int suplierId)
        {
            var suplier = await _suplierRepository.GetSingleSuplierByIdWithMedicineAsync(suplierId);
            var suplierDto = _mapper.Map<SuplierWithMedicinesDto>(suplier);

            return CustomResponseDto<SuplierWithMedicinesDto>.Successs(200, suplierDto);
        }
    }
}
