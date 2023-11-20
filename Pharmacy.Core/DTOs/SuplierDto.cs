using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTOs
{
    public class SuplierDto : BaseDto
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }
}
