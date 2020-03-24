using System;
using System.Data.SqlClient;

namespace Project6
{
    class Program
    {
        int ip;

        string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Problem6Db;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Select();
        }

        public void Select()
        {
            Console.WriteLine("Press 1 for Movies,2 for Actors ,3 for select view 4.Exit");
            ip = Convert.ToInt32(Console.ReadLine());
            switch (ip)
            {
                case 1:
                    Movie();
                    Select();
                    break;

                case 2:
                    Actor();
                    Select();
                    break;
                case 3:
                    View();
                    Select();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid ip");
                    break;
            }
        }

        public void Movie()
        {
            Console.WriteLine("Press 1 for Add Movies,2 for Delete Movie 3.Exit");
            ip = Convert.ToInt32(Console.ReadLine());
            switch (ip)
            {
                case 1:
                    AddMovie();
                    Select();
                    break;

                case 2:
                    Console.WriteLine("enter Movieid to delete");
                    ip = Convert.ToInt32(Console.ReadLine());
                    DeleteMovie(ip);

                    Select();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid ip");
                    break;
            }
        }

        public void AddMovie()
        {
            string movieName;
            int actorId;
            Console.WriteLine("Enter Movie Name");
            movieName = Console.ReadLine();
            Console.WriteLine("Enter Actor Id");
            actorId = Convert.ToInt32(Console.ReadLine());
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Movies(MovieName,ActorId)values('{movieName}','{actorId}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteMovie(int ip)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Movies where MovieId = " + ip;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();

        }
        public void Actor()
        {
            Console.WriteLine("Press 1 for Add Actors,2 for Delete Actor 3.Exit");
            ip = Convert.ToInt32(Console.ReadLine());
            switch (ip)
            {
                case 1:
                    AddActor();
                    Select();
                    break;

                case 2:
                    Console.WriteLine("enter ActorId to delete");
                    ip = Convert.ToInt32(Console.ReadLine());
                    DeleteActor(ip);

                    Select();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid ip");
                    break;
            }
        }
        public void AddActor()
        {
            string actorName;
          
            Console.WriteLine("Enter Actor Name");
            actorName = Console.ReadLine();
           
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Actors(ActorName)values('{actorName}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteActor(int ip)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Actors where ActorId = " + ip;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }

        public void View()
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"select * from vMovieDetails ", cnn);
            reader = c.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine( "Actor Name"+reader.GetString(2));
                Console.WriteLine("MovieName"+reader.GetString(1));
            }
        }
    }
}
