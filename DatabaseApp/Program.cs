using System.Collections.Generic;

namespace DatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Repository instanzieren
            CustomerRepository customerRepository = new CustomerRepository();

            // CRUD
            // Create - Read - Update - Delete

            // Neuen Datensatz einfügen (Create)
            // Objekt instanzieren
            Customer customer = new Customer();
            // Eigenschaften festlegen
            customer.CompanyName = "Honk";
            customer.City = "Paris";
            customer.Country = "Frankreich";
            // Objekt speichen
            customerRepository.Insert(customer);

            // Einzelnen Datensatz holen (Read)
            Customer oneCustomer = customerRepository.GetById(1);
            // Alle Datensätze holen (Read)
            List<Customer> customerList = customerRepository.GetAll();


            // Datensatz aktualisieren (Update)
            customerList[0].City = "Madrid";
            customerRepository.Update(customerList[0]);

            // Datensatz löschen (Delete)
            customerRepository.Delete(1);

        }
    }
}
