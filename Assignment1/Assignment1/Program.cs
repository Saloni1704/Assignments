using System;
using System.Data.SqlClient;

namespace Assignment1
{
    class Program
    {
        int choice;

        string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }

        public void Menu()
        {
            Console.WriteLine("Select Choice");
            Console.WriteLine("1.Add 2.Select 3.Update 3.Update 4.Delete 5.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Add();
                    Menu();
                    break;

                case 2:
                    Select();
                    Menu();
                    break;
                case 3:
                    Update();
                    Menu();
                    break;
                case 4:
                    Console.WriteLine("Enter StudentId");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Delete(i);
                    Menu();
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void Add()
        {
            string studentName, contactNumber, dob, Address,Email,Gender;
            Console.WriteLine("Enter Student Details");
            Console.WriteLine("Enter studentName");
            studentName = Console.ReadLine();

            Console.WriteLine("contactNumber:");
            contactNumber = Console.ReadLine();

            Console.WriteLine("dob");
            dob = Console.ReadLine();

            Console.WriteLine("Address");
            Address = Console.ReadLine();


            Console.WriteLine("Email");
            Email = Console.ReadLine();

            Console.WriteLine("Gender");
            Gender = Console.ReadLine();

            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Students(StudentName,ContactNumber,DateOfBirth,Address,Email,Gender)values('{studentName}','{contactNumber}','{dob}','{Address}','{Email}','{Gender}')", cnn);
            c.ExecuteNonQuery();
        }
        public void Select()
        {
            int studentId;
            Console.WriteLine("Enter studentId:");
            studentId =Convert.ToInt32( Console.ReadLine());


            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"select * from Students where StudentId = {studentId}", cnn);
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("StudentName : " + reader.GetString(1) + "ContactNumber :"+reader.GetString(2)+"Address :"+reader.GetString(4));
            }
        }
        public void Update()
        {
            int studentId;
            string name;
            Console.WriteLine("Enter studentId:");
            studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Student Name");
            name = Console.ReadLine();
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"update Students set StudentName='{name}' where StudentId='{studentId}'", cnn);
            c.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Students where StudentId = " + id;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }
    }

    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
