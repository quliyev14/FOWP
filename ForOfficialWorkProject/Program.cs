global using System;
global using System.Text;
global using System.Text.Json;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.MS;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Admin class => {
        1)prop => name,surname,mail
        2)Method => Add, Delete, Find(filter [1.name, 2.#code]), BudgetInOrOut.


        Product class => {
        1)prop => name,firma-name,#code,color,age-range or size-range,count,count in packet,price
        }

        User class => {

        }



        //}*/
        //string s = "elgun1234";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        //var product = new Product(
        //       name: "T-Shirt",
        //       firmaName: "FashionCo",
        //       code: "F1234",
        //       color: "Blue",
        //       ageRangeMin: 5,
        //       ageRangeMax: 16,
        //       count: 100,
        //       countInPacket: 10,
        //       price: 19.99
        //   );
        //Console.WriteLine(product.ToString());

        Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        Console.ReadKey();
    }
}