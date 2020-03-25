using System;
using System.Data.SqlClient;

namespace Project6
{
    class Program
    {
        int Choice;

        string connString = "Data Source=PRATIKPC\\SQLEXPRESS;Initial Catalog=Problem6Db;Integrated Security=true";
        SqlDataReader reader;
        SqlCommand command;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }

        public void Menu()
        {
            Console.WriteLine("Press 1 for Movies,2 for Actors ,3 for select view 4.Exit");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Movie();
                    Menu();
                    break;

                case 2:
                    Actor();
                    Menu();
                    break;
                case 3:
                    View();
                    Menu();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void Movie()
        {
            Console.WriteLine("Press 1 for Add Movies,2 for Delete Movie 3.Exit");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    AddMovie();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter Movieid to delete");
                    Choice = Convert.ToInt32(Console.ReadLine());
                    DeleteMovie(Choice);
                    Menu();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void AddMovie()
        {
            string movieName;
            int actorId;
            Console.WriteLine("Enter Movie Name");
            movieName = Console.ReadLine();
            
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Movies(MovieName)values('{movieName}')", cnn);
            c.ExecuteNonQuery();
        }
        public void DeleteMovie(int Choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Movies where MovieId = " + Choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();

        }
        public void Actor()
        {
            Console.WriteLine("Press 1 for Add Actors,2 for Delete Actor 3.Exit");
            Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    AddActor();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter ActorId to delete");
                    Choice = Convert.ToInt32(Console.ReadLine());
                    DeleteActor(Choice);

                    Menu();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
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
        public void DeleteActor(int Choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Actors where ActorId = " + Choice;
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
