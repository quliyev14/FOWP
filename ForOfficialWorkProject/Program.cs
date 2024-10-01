global using System;
global using System.Text;
global using System.Text.Json;
using ForOfficialWorkProject.Helper;
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
        string s = "elgun1234";

        Console.WriteLine(new GmailService("elgun1234@gmail.com","ATABALA111"));

        Console.ReadKey();
    }
}