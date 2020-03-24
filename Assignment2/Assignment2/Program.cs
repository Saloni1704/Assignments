using System;
using System.Data;
using System.Data.SqlClient;

namespace Assignment2
{
    class Program
    {
        int choice;

        string connString = @"Data Source=PRATIKPC\SQLEXPRESS;Initial Catalog=Assignmen2Db;Integrated Security=true";
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
            Console.WriteLine("1.track 2.Artist 3.Search 4.Filter 5.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Track();
                    Menu();
                    break;

                case 2:
                    Artist();
                    Menu();
                    break;
                case 3:
                    Search();
                    Menu();
                    break;

                case 4:
                    filter();
                    Menu();
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        public void Track()
        {   
            Console.WriteLine("Select Choice");
            Console.WriteLine("1 for Add tracks,2 for Delete tracks 3.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddTracks();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter TrackId to delete");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DeleteTracks(choice);

                    Menu();
                    break;


                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
        public void AddTracks()
        {
            string TrackName;
            int artistId;
            Console.WriteLine("Enter Track Name");
            TrackName = Console.ReadLine();
            Console.WriteLine("Enter ArtistId Id");
            artistId = Convert.ToInt32(Console.ReadLine());
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Tracks(TrackName,ArtistId)values('{TrackName}','{artistId}')", cnn);
            c.ExecuteNonQuery();
        }

        public void DeleteTracks(int id)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Tracks where TrackId = " + choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }

        public void Artist()
        {
            Console.WriteLine("Select Choice");
            Console.WriteLine("1 for Add Artist,2 for Delete Artist 3.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddArtist();
                    Menu();
                    break;

                case 2:
                    Console.WriteLine("enter ArtistId to delete");
                    choice = Convert.ToInt32(Console.ReadLine());
                    DeleteArtist(choice);

                    Menu();
                    break;

                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
        public void AddArtist()
        {
            string artistName;

            Console.WriteLine("Enter Artist Name");
            artistName = Console.ReadLine();

            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"insert into Artists(ArtistName)values('{artistName}')", cnn);
            c.ExecuteNonQuery();
        }

        public void DeleteArtist(int choice)
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            string cmd = "delete from Artists where ArtistId = " + choice;
            SqlCommand c = new SqlCommand(cmd, cnn);
            c.ExecuteNonQuery();
        }

        public void Search()
        {
            string artistName;
            Console.WriteLine("Enter artistName:");
            artistName = Console.ReadLine();


            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand($"select * from vMusic where artistName = '{artistName}'", cnn);
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("artistName :"+reader.GetString(1)+"Track Title :"+reader.GetString(4));
            }

        }

        public void filter()
        {
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();
            SqlCommand c = new SqlCommand("select * from vMusic", cnn);         

            Console.WriteLine("Enter artistName :  ");
           string ArtistName =Console.ReadLine();
            c.Connection = cnn;
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "spSerachMusic";

            c.Parameters.Add(new SqlParameter("@ArtistName", SqlDbType.VarChar)).Value = ArtistName;
            reader = c.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }

        }

    }


}
