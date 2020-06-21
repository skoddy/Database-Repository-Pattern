namespace DatabaseApp
{
    public class Customer
    {
        // POCO Objekt
        public int CustomerID { set; get; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
