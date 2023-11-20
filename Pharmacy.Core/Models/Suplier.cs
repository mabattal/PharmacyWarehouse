using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class Suplier:BaseEntity
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}
