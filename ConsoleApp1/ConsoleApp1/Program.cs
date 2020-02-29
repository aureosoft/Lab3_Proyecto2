using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
            Console.WriteLine("hola");
            var hola = Console.ReadLine();

        }

        static async Task Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("esequeiran@ucenfotec.ac.cr", "Evelyn");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("dbermudezc1@ucenfotec.ac.cr", "Cristina");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
