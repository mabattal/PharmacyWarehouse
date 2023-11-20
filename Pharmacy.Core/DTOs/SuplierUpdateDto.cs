using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DTOs
{
    public class SuplierUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaxNumber { get; set; }
    }
}
