namespace AndersonPayModel
{
    public class Service
    {
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public int TypeOfServiceId { get; set; }

        public string Description { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual TypeOfService typeofservices { get; set; }
    }
}
