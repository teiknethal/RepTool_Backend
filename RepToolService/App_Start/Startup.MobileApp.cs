using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using RepToolService.DataObjects;
using RepToolService.Models;
using Owin;

namespace RepToolService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new RepToolInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<RepToolContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);


            using (var ctx = new RepToolContext())
            {
                ActionCode actionCode = new ActionCode();
                actionCode.Description = "Created new user";

                DataObjects.Action action = new DataObjects.Action();
                action.Date = DateTime.Now;
                action.Code = actionCode;

                List<DataObjects.Action> actions = new List<DataObjects.Action>();
                actions.Add(action);

                Customer customer = new Customer();
                customer.Name = "Test Customer";
                customer.Email = "test@lasergifts.com";
                customer.Address = "1234 W All American Lane";
                customer.City = "Chino Valley";
                customer.State = "Arizona";
                customer.Country = "USA";

                List<Customer> customers = new List<Customer>();
                customers.Add(customer);


                Rep rep = new Rep();
                rep.FirstName = "Todd";
                rep.LastName = "Hubbard";
                rep.Email = "todd.hubbard@lasergifts.com";
                rep.IsAdmin = true;
                rep.IsManager = true;
                rep.Actions = actions;
                rep.Customers = customers;

                Product product = new Product();
                product.Name = "KMP";

                List<Names> names = new List<Names>();
                for (int i = 0; i < 5; i++){
                    Names name = new Names();
                    name.Name = "Test" + i.ToString();
                    names.Add(name);
                }

                Namelist namelist = new Namelist();
                namelist.Name = "Boys";
                namelist.Product = product;
                namelist.Names = names;

                OrderStatus orderStatusCode = new OrderStatus();
                orderStatusCode.Description = "Just created";

                List<OrderLine> orderLines = new List<OrderLine>();
                foreach (Names nameWorking in names)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Name = nameWorking.Name;
                    orderLine.Qty = 3;
                    orderLine.Order_ID = 1;
                    orderLines.Add(orderLine);
                }

                Order order = new Order();
                order.Product = product;
                order.Rep = rep;
                order.Customer = customer;
                order.PO = "12345";
                order.PlacedOn = DateTime.Now;
                order.FullfulBy = DateTime.Now;
                order.CompletedOn = DateTime.Now;
                order.ShippedOn = DateTime.Now;
                order.Status = orderStatusCode;
                order.OrderLines = orderLines;


                ctx.ActionCodes.Add(actionCode);
                ctx.Actions.Add(action);
                ctx.Customers.Add(customer);
                ctx.Reps.Add(rep);
                ctx.Products.Add(product);
                ctx.Namelists.Add(namelist);
                ctx.OrderStatusCodes.Add(orderStatusCode);
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
        }
    }

    public class RepToolInitializer : CreateDatabaseIfNotExists<RepToolContext>
    {
        protected override void Seed(RepToolContext context)
        {
        //    List<TodoItem> todoItems = new List<TodoItem>
        //    {
        //        new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
        //        new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
        //    };

        //    foreach (TodoItem todoItem in todoItems)
        //    {
        //        context.Set<TodoItem>().Add(todoItem);
        //    }

        //    base.Seed(context);
        }
    }
}

