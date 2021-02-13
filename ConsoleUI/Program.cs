using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer() {CompanyName = "Company 3"};

            customerManager.Add(customer1);

            var customers = customerManager.GetAll().Data;

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName + "/" + customer.UserId);
            }

        }
    }
}
