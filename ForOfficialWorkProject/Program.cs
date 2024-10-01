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
        string path_product = "product.json";
        string main_log = "main.log";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var product = new Product(
               name: "Jeans",
               firmaName: "F-Star",
               code: "F1234",
               color: "Dark blue",
               ageRangeMin: 4,
               ageRangeMax: 9,
               count: 20,
               countInPacket: 6,
               price: 5
           );

        //Console.WriteLine(product.ToString());

        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        AdminManeger.Add(in path_product, in main_log, product);

        Console.ReadKey();
    }
}