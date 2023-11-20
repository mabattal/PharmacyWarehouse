namespace Pharmacy.Core.DTOs
{
    public class MedicineWithSuplierDto : MedicineDto
    {
        public SuplierDto Suplier { get; set; }
    }
}
