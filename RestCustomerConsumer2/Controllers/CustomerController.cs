using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestCustomerConsumer2.Model;

namespace RestCustomerConsumer2.Controllers
{
    public class CustomerController
    {
        private static string CustomersUri = "https://localhost:44334/api/customer/";
        
        public class CustomersController : ControllerBase
        {
            // GET api/values
            [HttpGet]
            public static async Task<IList<Customer>> GetCustomersAsync()
            {
                using (HttpClient client = new HttpClient())
                {
                    string content = await client.GetStringAsync(CustomersUri);
                    IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                    return cList;
                }
            }

            // GET api/values/5
            [HttpGet("{id}")]
            public static async Task<Customer> GetCustomerInfoAsync(int id)
            {
                string CusomerIdUri = CustomersUri + "/" + id;
                using (HttpClient client = new HttpClient())
                {
                    string content = await client.GetStringAsync(CusomerIdUri);
                    Customer c1 = JsonConvert.DeserializeObject<Customer>(content);
                    return c1;
                }
            }

            // POST api/values
            [HttpPost]
            public static async Task<Customer> PostNewCustomerAsync(Customer newCust)
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonString = JsonConvert.SerializeObject(newCust);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(CustomersUri, content);

                    string message = await response.Content.ReadAsStringAsync();
                    Customer newCustPrint = JsonConvert.DeserializeObject<Customer>(message);
                    return newCustPrint;
                }
            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public static async Task<Customer> UpdateCustomerAsync(Customer uCust, int id)
            {
                using (HttpClient client = new HttpClient())
                {
                    string requestUri = CustomersUri + id;
                    var jsonString = JsonConvert.SerializeObject(uCust);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(requestUri, content);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Customer not found. Try another id");
                    }
                    string str = await response.Content.ReadAsStringAsync();
                    Customer updCustomer = JsonConvert.DeserializeObject<Customer>(str);
                    return updCustomer;
                }
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public static async Task<Customer> DeleteOneCustomerAsync(int id)
            {
                string requestUri = CustomersUri + id;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(requestUri);
                    //Console.WriteLine("Statuscode" + response.StatusCode);
                    string print = await response.Content.ReadAsStringAsync();
                    Customer deletedCustomer = JsonConvert.DeserializeObject<Customer>(print);
                    return deletedCustomer;
                }
            }
        }
    }
}
