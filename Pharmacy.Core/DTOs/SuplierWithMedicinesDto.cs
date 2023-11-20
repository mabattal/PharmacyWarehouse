using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTOs
{
    public class SuplierWithMedicinesDto : SuplierDto
    {
        public List<MedicineDto> Medicines { get; set; }
    }
}
