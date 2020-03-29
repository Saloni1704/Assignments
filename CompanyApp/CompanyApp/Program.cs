using CompanyApp.Models;
using System;
using System.Linq;

namespace CompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int choice;
            string OwnerName, Password;
            do
            {
                Console.WriteLine("You are 1.Owner 2.Employee 3.Exit ");
                Console.WriteLine("Enter choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter UserName");
                        OwnerName = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        Password = Console.ReadLine();
                        if (OwnerName == "admin" && Password == "admin")
                        {
                            p.Owner();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid User");
                            break;
                        }

                    case 2:
                        p.Employee();
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
        public void Owner()
        {
            int choice;
            do
            {
                Console.WriteLine("1. Add Employess 2.View Employees 3.Add Business Units 4.View Business Units 5.Add Projects 6.View Projects 7.View Employee On Vacation 8.Select Project Teams 9.Exit");
                Console.WriteLine("Select choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewEmployee();
                        break;
                    case 3:
                        AddBusinessUnit();
                        break;
                    case 4:
                        ViewBusinessUnit();
                        break;
                    case 5:
                        AddProject();
                        break;
                    case 6:
                        ViewProject();
                        break;
                    case 7:
                        SelectProjectTeam();
                        break;
                    case 8:
                        ViewEmployeeOnVacation();
                        break;
                    case 9:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 9);
        }
        public void AddEmployee()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Employee Name");
                string EmpName = Console.ReadLine();
                Console.WriteLine("Enter Employee Code ");
                int EmpCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Contact Number");
                string ContactNumber = Console.ReadLine();
                Console.WriteLine("Enter Gender");
                string Gender = Console.ReadLine();
                Console.WriteLine("Enter EmailId");
                string EmailId = Console.ReadLine();
                Console.WriteLine("Enter BusinessUnitName");
                string BusinessUnitName = Console.ReadLine();

                int BusinessUnitId = businessapp.BusinessUnits.SingleOrDefault<BusinessUnits>(t => t.BusinessUnitName == BusinessUnitName).BusinessUnitId;

                Console.WriteLine("Enter Address");
                string Address = Console.ReadLine();

                var employee = new Employees
                {
                   EmployeeName=EmpName,
                   EmployeeCode=EmpCode,
                   MobileNumber=ContactNumber,
                   Gender=Gender,
                   EmailId=EmailId,
                   BusinessUnitId=BusinessUnitId,
                   Address=Address
                   
                };
                businessapp.Employees.Add(employee);
                businessapp.SaveChanges();
                Console.WriteLine("Successfully Added");
            }
        }
        public void ViewEmployee()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                var employees = businessapp.Employees;
                foreach (var employee in employees)
                {
                    Console.WriteLine("Employee Code :" + employee.EmployeeCode + "Employee Name :" + employee.EmployeeName);
                }
            }

        }
        public void AddBusinessUnit()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Business Unit Name");
                string BusinessUnitName = Console.ReadLine();

                var businessunit = new BusinessUnits
                {
                    
                    BusinessUnitName = BusinessUnitName

                };
                businessapp.BusinessUnits.Add(businessunit);
                businessapp.SaveChanges();
                Console.WriteLine("Successfully Added");
            }
        }
        public void ViewBusinessUnit()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                var businessunits = businessapp.BusinessUnits;
                foreach (var businessunit in businessunits)
                {
                    Console.WriteLine("BusinessUnit Id:" + businessunit.BusinessUnitId + "BusinessUnit Name :" + businessunit.BusinessUnitName);
                }
            }

        }
        public void AddProject()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Project Name");
                string ProjectName = Console.ReadLine();
                Console.WriteLine("Enter Project Description");
                string Description = Console.ReadLine();
                Console.WriteLine("Enter Business Unit Name");
                string BusinessUnitName = Console.ReadLine();

                int BusinessUnitId = businessapp.BusinessUnits.SingleOrDefault<BusinessUnits>(t => t.BusinessUnitName == BusinessUnitName).BusinessUnitId;

                var project = new Projects
                {

                    ProjectName = ProjectName,
                    Description=Description,
                    BusinessUnitId=BusinessUnitId

                };
                businessapp.Projects.Add(project);
                businessapp.SaveChanges();
                Console.WriteLine("Successfully Added");
            }
        }
        public void ViewProject()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                var projects = businessapp.Projects;
                foreach (var project in projects)
                {
                    Console.WriteLine("Project Id:" + project.ProjectId + "Project Name :" + project.ProjectName+"Description :"+project.Description);
                }
            }

        }

        public void SelectProjectTeam()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine(" Enter Project Name:");
                string ProjectName = Console.ReadLine();

                int ProjectId = businessapp.Projects.SingleOrDefault<Projects>(t => t.ProjectName == ProjectName).ProjectId;

                Console.WriteLine("Enter Employee Name");
                int EmpCode = Convert.ToInt32(Console.ReadLine());


                int EmployeeId = businessapp.Employees.SingleOrDefault<Employees>(t => t.EmployeeCode == EmpCode).EmployeeId;

                int EmployeeOnVacation = businessapp.Vacations.Count<Vacations>(t => t.EmployeeId == EmployeeId);

                Console.WriteLine("Enter Employee Designation");
                string Designation = Console.ReadLine();

                if(EmployeeOnVacation==0)
                {
                    var projectTeamMembers = new ProjectTeams
                    {

                        ProjectId = ProjectId,
                        EmployeeId = EmployeeId,
                        EmployeeDesignation = Designation

                    };
                    businessapp.ProjectTeams.Add(projectTeamMembers);
                    businessapp.SaveChanges();
                    Console.WriteLine("Project Team Successfully Selected.. ");
                }
                else
                {
                    Console.WriteLine("This Employee is on vacation...you can't assign to Project");
                }
                

            }
        }
        public void ViewEmployeeOnVacation()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                var employeeOnVacation = businessapp.Vacations;
                foreach(var employees in employeeOnVacation)
                {

                    string EmployeeName = businessapp.Employees.Find(employees.EmployeeId).EmployeeName;
                    int EmployeeCode = businessapp.Employees.Find(employees.EmployeeId).EmployeeCode;
                    Console.WriteLine("VacationId :" + employees.VacationId + "Employee Code:" + EmployeeCode + "EmployeeName :" + EmployeeName);
                }
            }

        }

        public void Employee()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                int EmpCode, choice;

                Console.WriteLine("Enter Employee Code :");
                EmpCode = Convert.ToInt32(Console.ReadLine());

                int EmployeeCode = businessapp.Employees.SingleOrDefault<Employees>(t => t.EmployeeCode == EmpCode).EmployeeCode;
                if (EmployeeCode!=0)
                {
                    do
                    {
                        Console.WriteLine("1.Apply for Vacation 2.View OwnDetails 3.View AssignProjectsDetails 4. ViewCompanyProjects 5.Exit");
                        Console.WriteLine("Enter your choice");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                ApplyForVacation();
                                break;
                            case 2:
                                ViewOwnDetails();
                                break;
                            case 3:
                                ViewAssignProjectDetails();
                                break;
                            case 4:
                                ViewProject();
                                break;
                            case 5:
                                Console.WriteLine("Exit");
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }

                    } while (choice != 5);
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");

                }
            }

        }

        public void ApplyForVacation()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Employee Code");
                int EmpCode = Convert.ToInt32(Console.ReadLine());

                int EmployeeId = businessapp.Employees.SingleOrDefault<Employees>(t => t.EmployeeCode == EmpCode).EmployeeId;
                if (EmployeeId != 0)
                {
                    int EmpId = businessapp.Vacations.Count<Vacations>(t => t.EmployeeId == EmployeeId);
                    if(EmpId==0)
                    {
                        var applyforvacation = new Vacations
                        {
                            EmployeeId=EmployeeId
                        };

                        businessapp.Vacations.Add(applyforvacation);
                        businessapp.SaveChanges();
                        Console.WriteLine("You are successfully applied for Vacation");
                    }
                    else
                    {
                        Console.WriteLine("Employee is Already On Vacation");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Employee Code");
                    Console.WriteLine("Please Try Again");
                }
            }

        }

        public void ViewOwnDetails()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Employee Code");
                int EmployeeCode = Convert.ToInt32(Console.ReadLine());

                var EmplyoeeDetail = businessapp.Employees.SingleOrDefault<Employees>(t => t.EmployeeCode == EmployeeCode);
                Console.WriteLine("Employee Code :" + EmplyoeeDetail.EmployeeCode + "Employee Name :" + EmplyoeeDetail.EmployeeName + "ContactNumber :" + EmplyoeeDetail.MobileNumber + "Gender:" + EmplyoeeDetail.Gender + "Address" + EmplyoeeDetail.Address + "EmailId" + EmplyoeeDetail.EmailId);
            }
        }

        public void ViewAssignProjectDetails()
        {
            using (var businessapp = new CompanyBusinessAppDbContext())
            {
                Console.WriteLine("Enter Employee Code :");
                int EmployeeCode = Convert.ToInt32(Console.ReadLine());
                int EmployeeId = businessapp.Employees.SingleOrDefault<Employees>(t => t.EmployeeCode == EmployeeCode).EmployeeId;
                if (EmployeeId != 0)
                {
                    int EmpProject = businessapp.ProjectTeams.Count<ProjectTeams>(t => t.EmployeeId == EmployeeId);
                    if(EmpProject!=0)
                    {
                        var ProjectDetail = businessapp.ProjectTeams.SingleOrDefault<ProjectTeams>(t => t.EmployeeId == t.EmployeeId);
                        string ProjectName = businessapp.Projects.Find(ProjectDetail.ProjectId).ProjectName;
                        string Description = businessapp.Projects.Find(ProjectDetail.ProjectId).Description;

                        Console.WriteLine("Employee Code :" + EmployeeCode + "Project Name :" + ProjectName + "Description" + Description);
                    }
                    else
                    {
                        Console.WriteLine("No Project is Assign for this Employee Code");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Employee Code");
                }
            }
        }
    }
}
