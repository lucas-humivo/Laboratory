using Microsoft.EntityFrameworkCore;
using Laboratory.Data;

namespace Laboratory.Models
{
    public class SeedData
    {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LaboratoryContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<LaboratoryContext>>()))
        {
            if (context == null || context.Client == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Client.Any())
            {
                return;   // DB has been seeded
            }

            context.Client.AddRange(
                new Client
                {
                    CompanyName = "PLUM",
                    Address = "Wspólna 19",
                    ContactPerson = "Łukasz Kozłowski",
                    PhoneNumber = "+48851121313",
                    NIP = "1234567891",
                    Currency = "PLN",
                    PaymentTerms = 14
                },

                new Client
                {
                    CompanyName = "AZBEST",
                    Address = "Dzika 1",
                    ContactPerson = "Łukasz Kozłowski",
                    PhoneNumber = "+48855555555",
                    NIP = "1234567891",
                    Currency = "PLN",
                    PaymentTerms = 14
                },

                new Client
                {
                    CompanyName = "FASADA",
                    Address = "Sienkiewicza 8",
                    ContactPerson = "Sylwia Wyszołmirska",
                    PhoneNumber = "+48851121556",
                    NIP = "1234567891",
                    Currency = "PLN",
                    PaymentTerms = 14
                },

                new Client
                {
                    CompanyName = "DENNA",
                    Address = "Wąska 4",
                    ContactPerson = "Łukasz Siny",
                    PhoneNumber = "+48851121313",
                    NIP = "1234567891",
                    Currency = "PLN",
                    PaymentTerms = 14
                }
            );

            context.Order.AddRange(
                new Order
                {
                    ClientID = 1,
                    Number = "100/LA/TH/2021",
                    Description = "SD700",
                    Price = 280,
                    Discount = 0 
                },
                new Order
                {
                    ClientID = 2,
                    Number = "105/LA/TH/2021",
                    Description = "LB-701",
                    Price = 868,
                    Discount = 0
                },
                new Order
                {
                    ClientID = 3,
                    Number = "110/LA/TH/2021",
                    Description = "TESTO 174",
                    Price = 210,
                    Discount = 0
                },
                new Order
                {
                    ClientID = 4,
                    Number = "124/LA/TH/2021",
                    Description = "TESTO 174H",
                    Price = 435,
                    Discount = 5
                }
            );

            context.SaveChanges();
        }
    }
}
}