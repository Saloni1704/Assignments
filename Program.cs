using LinqApp.Model;
using System;
using System.Linq;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AdventureContext db = new AdventureContext())
            {
                //2
                var EmpDetail2 = from emp in db.Employees select emp;
                foreach (var i in EmpDetail2)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "\nLastName :" + i.LastName + "\nSalary :" + i.Salary + "\nJoining Date :" + i.JoiningDate + "\nDepartment :" + i.Department);
                    Console.WriteLine("-----------");
                }

                //3 & 4
                var EmpDetails3 = from emp in db.Employees
                                       select new
                                       {
                                           FirstsName = emp.FirstName,
                                           LastName = emp.LastName
                                       };
                foreach (var empd in EmpDetails3)
                {
                    Console.WriteLine("FirstName:" + empd.FirstsName + "------" + "LastName: " + empd.LastName);
                }

                //5
                var EmpDetails5 = from emp in db.Employees select emp.FirstName.ToUpper();
                foreach (var empd in EmpDetails5)
                {
                    Console.WriteLine("FirstName:" + empd);
                }

                //6
                var EmpDetails6 = from emp in db.Employees select emp.FirstName.ToLower();
                foreach (var empd in EmpDetails6)
                {
                    Console.WriteLine("FirstName:" + empd);
                }

                //7
                var EmpDetails7 = (from dep in db.Employees select dep.Department).Distinct();
                foreach (var department in EmpDetails7)
                {
                    Console.WriteLine("Department:" + department);
                }

                //8
                var EmpDetails8 = from fName in db.Employees select fName.FirstName.Substring(0, 3);
                foreach (var firstname in EmpDetails8)
                {
                    Console.WriteLine("Department:" + firstname);
                }

                //9
                var EmpDetails9 = from positionofchar in db.Employees where positionofchar.FirstName == "John" select positionofchar.FirstName.IndexOf('o');
                foreach (var position in EmpDetails9)
                {
                    Console.WriteLine("Index of o:" + position);
                }

                //10
                var EmpDetails10 = from firstName in db.Employees select firstName.FirstName.Trim();
                foreach (var name in EmpDetails10)
                {
                    Console.WriteLine("Name:" + name);
                }

                //12
                var EmpDetails12 = from nl in db.Employees select nl.FirstName.Length;
                foreach (var name in EmpDetails12)
                {
                    Console.WriteLine("Name:" + name);
                }

                //13
                var EmpDetails13 = from repl in db.Employees select repl.FirstName.Replace('o', '$');
                foreach (var name in EmpDetails13)
                {
                    Console.WriteLine("Name:" + name);
                }

                //15
                var EmpDetails15 = from con in db.Employees
                           select new
                           {
                               FirstName = con.FirstName,
                               Year = con.JoiningDate.Year,
                               Month = con.JoiningDate.Month,
                               Date = con.JoiningDate.Date,

                           };
                foreach (var val in EmpDetails15)
                {
                    Console.WriteLine("Name:" + val.FirstName + "----" + "Year:" + val.Year + "----" + "Month:" + val.Month + "----" + "Date:" + val.Date + "----");
                }

                //16
                var EmpDetails16 = from order in db.Employees orderby order.FirstName ascending select order.FirstName;
                foreach (var empd in EmpDetails16)
                {
                    Console.WriteLine("FirstName:" + empd);
                }

                //17
                var EmpDetails17 = from order in db.Employees orderby order.FirstName descending select order.FirstName;
                foreach (var empd in EmpDetails17)
                {
                    Console.WriteLine("FirstName:" + empd);
                }

                //18
                var EmpDetails18 = from emp in db.Employees
                               orderby emp.FirstName descending, emp.Salary descending
                               select new
                               {
                                   emp.FirstName,
                                   emp.Salary
                               };
                foreach (var empd in EmpDetails18)
                {
                    Console.WriteLine("FirstName:" + empd.FirstName + "------" + "Salary:" + empd.Salary);
                }

                //19
                var EmpDetails19 = from emp in db.Employees where emp.FirstName == "John" select emp;
                foreach (var i in EmpDetails19)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "\nLastName :" + i.LastName + "\nSalary :" + i.Salary + "\nJoining Date :" + i.JoiningDate + "\nDepartment :" + i.Department);
                }

                //20
                var EmpDetails20 = from emp in db.Employees where emp.FirstName == "John" || emp.FirstName == "Roy" select emp;
                foreach (var i in EmpDetails20)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "\nLastName :" + i.LastName + "\nSalary :" + i.Salary + "\nJoining Date :" + i.JoiningDate + "\nDepartment :" + i.Department);
                }

                //21
                var EmpDetails21 = from emp in db.Employees where emp.FirstName != "John" || emp.FirstName != "Roy" select emp;
                foreach (var i in EmpDetails21)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "\nLastName :" + i.LastName + "\nSalary :" + i.Salary + "\nJoining Date :" + i.JoiningDate + "\nDepartment :" + i.Department);
                }

                //22
                var EmpDetails22 = from emp in db.Employees where emp.FirstName.StartsWith("J") select emp;
                foreach (var i in EmpDetails22)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //23
                var EmpDetails23 = from emp in db.Employees where emp.FirstName.Contains("o") select emp;
                foreach (var i in EmpDetails23)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //24
                var EmpDetails24 = from emp in db.Employees where emp.FirstName.EndsWith("n") select emp;
                foreach (var i in EmpDetails24)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //25
                var EmpDetails25 = from emp in db.Employees where emp.FirstName.EndsWith("n") && emp.FirstName.Length == 4 select emp;
                foreach (var i in EmpDetails25)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //26
                var EmpDetails26 = from emp in db.Employees where emp.FirstName.StartsWith("J") && emp.FirstName.Length == 4 select emp;
                foreach (var i in EmpDetails26)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //27
                var EmpDetails27 = from emp in db.Employees.Where<Employees>(emp => emp.Salary > 600000) select emp;
                foreach (var i in EmpDetails27)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "---" + "Salary" + i.Salary);
                }

                //28
                var EmpDetails28 = from emp in db.Employees.Where<Employees>(emp => emp.Salary < 800000) select emp;
                foreach (var i in EmpDetails28)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "---" + "Salary" + i.Salary);
                }

                //29
                var EmpDetails29 = from emp in db.Employees.Where<Employees>(emp => emp.Salary > 500000 && emp.Salary < 800000) select emp;
                foreach (var i in EmpDetails29)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "---" + "Salary" + i.Salary);
                }

                //30
                var EmpDetails30 = from emp in db.Employees where emp.FirstName == "John" || emp.FirstName == "Michael" select emp;
                foreach (var i in EmpDetails30)
                {
                    Console.WriteLine("FirstName :" + i.FirstName + "\nLastName :" + i.LastName + "\nSalary :" + i.Salary + "\nJoining Date :" + i.JoiningDate + "\nDepartment :" + i.Department);
                }

                //32
                var EmpDetails32 = from emp in db.Employees where emp.JoiningDate.Month == 01 select emp;
                foreach (var i in EmpDetails32)
                {
                    Console.WriteLine("FirstName :" + i.FirstName);
                }

                //39
                var EmpDetails39 = from emp in db.Employees select emp.LastName.Replace('%', ' ');
                foreach (var i in EmpDetails39)
                {
                    Console.WriteLine("LastName :" + i);
                }

                //41
                var EmpDetails41 = from emp in db.Employees
                          group emp by emp.Department into dep
                          orderby dep.Sum(x => x.Salary)
                          select new
                          {
                              Department = dep.Key,
                              salary = dep.Sum(x => x.Salary)
                          };
                foreach (var i in EmpDetails41)
                {
                    Console.WriteLine("Department :" + i.Department + "------" + "Salary:" + i.salary);
                }

                //44
                var EmpDetails44 = from emp in db.Employees
                          group emp by emp.Department into dep
                          orderby dep.Average(x => x.Salary) ascending
                          select new
                          {
                              Department = dep.Key,
                              salary = dep.Average(x => x.Salary)
                          };
                foreach (var i in EmpDetails44)
                {
                    Console.WriteLine("Department :" + i.Department + "------" + "Salary:" + i.salary);
                }

                //45
                var EmpDetails45 = from emp in db.Employees
                          group emp by emp.Department into dep
                          orderby dep.Max(x => x.Salary) ascending
                          select new
                          {
                              Department = dep.Key,
                              salary = dep.Max(x => x.Salary)
                          };
                foreach (var i in EmpDetails45)
                {
                    Console.WriteLine("Department :" + i.Department + "------" + "Salary:" + i.salary);
                }

                //46
                var EmpDetails46 = from emp in db.Employees
                          group emp by emp.Department into dep
                          orderby dep.Min(x => x.Salary) ascending
                          select new
                          {
                              Department = dep.Key,
                              salary = dep.Min(x => x.Salary)
                          };
                foreach (var i in EmpDetails46)
                {
                    Console.WriteLine("Department :" + i.Department + "------" + "Salary:" + i.salary);
                }

                //48
                var EmpDetails48 = from emp in db.Employees
                          group emp by emp.Department into dep
                          orderby dep.Sum(x => x.Salary)
                          where dep.Sum(x => x.Salary) > 800000
                          select new
                          {
                              Department = dep.Key,
                              salary = dep.Sum(x => x.Salary)
                          };
                foreach (var i in EmpDetails48)
                {
                    Console.WriteLine("Department :" + i.Department + "------" + "Salary:" + i.salary);
                }

                //49
                var EmpDetails49 = from emp in db.Employees
                         join inc in db.Incentives on emp.EmployeeId equals inc.EmployeeId
                         select new
                         {
                             emp.FirstName,
                             inc.IncentiveAmount
                         };
                foreach (var i in EmpDetails49)
                {
                    Console.WriteLine(i.FirstName);
                }

                //50
                var EmpDetails50 = from emp in db.Employees
                          join inc in db.Incentives on emp.EmployeeId equals inc.EmployeeId
                          where inc.IncentiveAmount > 3000
                          select new
                          {
                              emp.FirstName,
                              inc.IncentiveAmount
                          };
                foreach (var i in EmpDetails50)
                {
                    Console.WriteLine(i.FirstName);
                }

                //52
                var EmpDetails52 = from emp in db.Employees
                             join inc in db.Incentives
                            on emp.EmployeeId equals inc.EmployeeId into empDept
                             from res in empDept.DefaultIfEmpty()
                             select new
                             {
                                 EmployeeName = emp.FirstName,
                                 IncentiveAmount = res == null ? 0 : res.IncentiveAmount
                             };
                foreach (var i in EmpDetails52)
                {
                    Console.WriteLine("EmployeeNaame" + i.EmployeeName + "-----" + "IncentiveAmount" + i.IncentiveAmount);

                }

                //54
                var EmpDetails54 = (from emp in db.Employees select emp.Salary).Take(2);
                foreach (var i in EmpDetails52)
                    Console.WriteLine("Salary :"+i);

                //56
                var EmpDetails56 = (from emp in db.Employees orderby emp.Salary descending select emp.Salary).Skip(1).First();
                Console.WriteLine("Second Highest Salary:" + EmpDetails56);

                //57
                var num = Convert.ToInt32(Console.ReadLine());
                var EmpDetails57 = (from emp in db.Employees orderby emp.Salary descending select emp.Salary).Skip(num - 1).First();
                Console.WriteLine("Nth highest Salary: " + EmpDetails57);

            }
        }
    }
}
