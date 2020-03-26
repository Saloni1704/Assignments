using System;
using System.Linq;
using ToyCompanyApp.Models;

namespace ToyCompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int choice;
            string ownerName, Password;
            using (var toyapp = new ToyApplicationDbContext())
            {
                do
                {
                    Console.WriteLine("You are a 1. Compoany owner 2. Customer 3. Exit ");
                    Console.WriteLine("Enter Choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Owner Name:");
                            ownerName = Console.ReadLine();
                            Console.WriteLine("Enter Password");
                            Password = Console.ReadLine();
                            if (ownerName == "owner" && Password == "owner")
                            {
                                p.CompanyOwner();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Enteries");
                                break;
                            }
                        case 2:
                            p.Customer();
                            break;
                        case 3:
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                } while (choice != 3);
            }
        }
        public void CompanyOwner()
        {
            int choice;
            do
            {
                Console.WriteLine(" 1. Add Toy Category 2. Add Toy 3.Add Plants  4.View Plants 5.View Toys 6.View Toy Category 7.Add Schemes 8.Exit");
                Console.WriteLine("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddToyCategory();
                        break;
                    case 2:
                        AddToy();
                        break;
                    case 3:
                        AddPlant();
                        break;
                    case 4:
                        ViewPlant();
                        break;
                    case 5:
                        ViewToy();
                        break;
                    case 6:
                        ViewToyCategory();
                        break;
                    case 7:
                        AddSchemes();
                        break;
                    case 8:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            while (choice != 8);

        }
        public void AddToyCategory()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                string CategoryName;
                Console.WriteLine("Enter CategoryName");
                CategoryName = Console.ReadLine();
                var toycategory = new ToyCategory
                {
                    ToyCategoryName = CategoryName,
                };
                toyapp.ToyCategory.Add(toycategory);
                toyapp.SaveChanges();
                Console.WriteLine(" Toy Category Successfully Added");
            }

        }
        public void AddToy()
        {
            string ToyName, Description, CategoryName, PlantName;
            int Price;
            using (var toyapp = new ToyApplicationDbContext())
            {
                Console.WriteLine("Enter Toy Name");
                ToyName = Console.ReadLine();
                Console.WriteLine("Enter Toy Description");
                Description = Console.ReadLine();
                Console.WriteLine("Enter Price");
                Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Category Name");
                CategoryName = Console.ReadLine();

                int CategoryId = toyapp.ToyCategory.SingleOrDefault<ToyCategory>(t => t.ToyCategoryName == CategoryName).ToyCategoryId;
                Console.WriteLine("Enter Plant Name");
                PlantName = Console.ReadLine();
                int PlantId = toyapp.Plants.SingleOrDefault<Plants>(t => t.PlantName == PlantName).PlantId;

                var toy = new Toys
                {
                    ToyName = ToyName,
                    Description = Description,
                    Price = Price,
                    CategoryId = CategoryId,
                    PlantId = PlantId
                };
                toyapp.Toys.Add(toy);
                toyapp.SaveChanges();
                Console.WriteLine(" Toy  Successfully Added");


            }
        }
        public void AddPlant()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                string plantName, plantAddress;
                Console.WriteLine("Enter plantName");
                plantName = Console.ReadLine();
                Console.WriteLine("Enter plantAddress");
                plantAddress = Console.ReadLine();

                var plant = new Plants
                {
                    PlantName = plantName,
                    Address = plantAddress

                };
                toyapp.Plants.Add(plant);

                toyapp.SaveChanges();

                Console.WriteLine(" Plant Successfully Added");
            }
        }
        public void ViewPlant()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                var plants = toyapp.Plants;
                foreach (var plant in plants)
                {
                    Console.WriteLine("PlantID :" + plant.PlantId + "PlantName :" + plant.PlantName);
                }

            }

        }
        public void ViewToy()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                var toys = toyapp.Toys;
                foreach (var toy in toys)
                {
                    Console.WriteLine("ToyId :" + toy.ToyId + "ToyName :" + toy.ToyName);
                }

            }

        }
        public void ViewToyCategory()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                var toycategory = toyapp.ToyCategory;
                foreach (var toycat in toycategory)
                {
                    Console.WriteLine("ToyCategoryId :" + toycat.ToyCategoryId + "ToyCategoryName :" + toycat.ToyCategoryName);
                }

            }
        }
        public void AddSchemes()
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                string schemeName, Description;
                Console.WriteLine("Enter schemeName");
                schemeName = Console.ReadLine();
                Console.WriteLine("Enter Description");
                Description = Console.ReadLine();

                var scheme = new Schemes
                {
                    SchemeName = schemeName,
                    Description = Description

                };
                toyapp.Schemes.Add(scheme);

                toyapp.SaveChanges();

                Console.WriteLine(" Scheme Successfully Added");
            }

        }

        public void Customer()
        {
            int choice;
            do
            {
                Console.WriteLine(" 1.Signup 2.Login 3.Exit");
                Console.WriteLine("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CustomerRegister();
                        break;
                    case 2:
                        CustomerLogin();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            while (choice != 4);
        }
        public void CustomerRegister()
        {
            int CustomerId = 0;
            using (var toyapp = new ToyApplicationDbContext())
            {
                string Name, Email, Mobile, Password;

                Console.WriteLine("Enter Name");
                Name = Console.ReadLine();
                Console.WriteLine("Enter Contact Number");
                Mobile = Console.ReadLine();
                Console.WriteLine("Enter Email");
                Email = Console.ReadLine();
                Console.WriteLine("Enter Password");
                Password = Console.ReadLine();

                var customer = new Customers
                {
                    CustomerName = Name,
                    Mobile = Mobile,
                    Email = Email,
                    Password = Password
                };
                toyapp.Customers.Add(customer);

                toyapp.SaveChanges();
                CustomerId = customer.CustomerId;

                Console.WriteLine("Successfully Added");
                ViewSchemes(CustomerId);


            }
        }
        public void CustomerLogin()
        {
            String Email, Password;
            int CustomerId = 0;
            Console.WriteLine("Enter Email");
            Email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            Password = Console.ReadLine();
            using (var toyapp = new ToyApplicationDbContext())
            {
                var customers = toyapp.Customers.Where(t => t.Email == Email && t.Password == Password).FirstOrDefault<Customers>();
                if (customers != null)
                {
                    Console.WriteLine("Login Success");
                    CustomerId = customers.CustomerId;
                    ViewSchemes(CustomerId);

                }
                else
                {
                    Console.WriteLine("failed");
                }
            }
        }
        public void ViewSchemes(int CustomerId)
        {
            using (var toyapp = new ToyApplicationDbContext())
            {
                Console.WriteLine("Here U will get These Schemes");
                foreach (var i in toyapp.Schemes)
                {
                    Console.WriteLine(i.SchemeId + " ...... " + i.SchemeName);
                }
            }
            SelectCategory(CustomerId);
        }
        public void SelectCategory(int CustomerId)
        {
            int CategoryId;
            Console.WriteLine("Enter Categry Id");
            CategoryId = Int32.Parse(Console.ReadLine());

            OrderToys(CategoryId, CustomerId);
        }
        public void OrderToys(int CategoryId, int CustomerId)
        {
            string ToyName;
            using (var toyapp = new ToyApplicationDbContext())
            {
                var toys = toyapp.Toys.Where(t => t.CategoryId == CustomerId).ToList();
                foreach (var i in toys)
                {
                    Console.WriteLine("ToyId:"+i.ToyId + " ToyName" + i.ToyName + "Price" + i.Price);
                }
                Console.WriteLine("Enter Toy Name");
                ToyName=Console.ReadLine();
                int ToyId = toyapp.Toys.SingleOrDefault<Toys>(t => t.ToyName == ToyName).ToyId;
                Console.WriteLine("enter Quantity");
                int quantity = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Address");
                string address = Console.ReadLine();

                var order = new Orders
                {
                    CustomerId = CustomerId,
                    ToyId = ToyId,
                    Address = address,
                    Quantity = quantity

                };
                toyapp.Orders.Add(order);
                toyapp.SaveChanges();
                Console.WriteLine("Order placed success..");

            }
        }
    }
}
