using Microsoft.AspNetCore.Mvc.Formatters;
using AdventureWorksNS.Data;
using static System.Console;


namespace AventureWordsAppi.Repositories;
 {

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // agrega el contexto de la base da datos de AventureWorks
            builder.Services.AdventureWorksDBContext();



            // Add services to the container.
            // agregar y visualizar los formatos soportados 

            builder.Services.AddControllers(options =>
            {
                WriteLine("Formatos por omision");
                foreach(IOutputFormatter formatter in options.OutputFormatters)
                {
                    OutputFormatter? mediaFormatter = formatter as OutputFormatter;
                    if (mediaFormatter == null)
                    {
                        WriteLine($"{formatter.GetType().Name}");
                    }
                    else
                    {
                        WriteLine($" {mediaFormatter.GetType().Name}, " +
                                 $"Media types: {string.Join(", ", mediaFormatter.SupportedMediaTypes)}");

                    }
                }
            })
            .AddXmlDataContractSerializerFormatters()
                .AddXmlSerializerFormatters();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
             builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}