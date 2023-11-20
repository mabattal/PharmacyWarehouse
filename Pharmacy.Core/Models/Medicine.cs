using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Models
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int SuplierId { get; set; }
        public Suplier Suplier { get; set; }
    }
}
