using AutoMapper;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Core.Services;
using Pharmacy.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service.Services
{
    public class MedicineService : Service<Medicine>, IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;
        public MedicineService(IGenericRepository<Medicine> repository, IUnitOfWork unitOfWork, IMedicineRepository medicineRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<MedicineWithSuplierDto>>> GetMedicineWithSuplier()
        {
            var medicines = await _medicineRepository.GetMedicineWithSuplier();
            var medicinesDto = _mapper.Map<List<MedicineWithSuplierDto>>(medicines);

            return CustomResponseDto<List<MedicineWithSuplierDto>>.Successs(200, medicinesDto);
        }
    }
}
