using System;
using System.IO;

namespace FileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;
            do
            {
                Console.WriteLine("1.Create a file 2.Rename file 3.Concat two files 4.Display Content Of file 5.Write in a file 6.Delete File 7.Copy File 8. Exit");
                Console.WriteLine("Enter Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        program.CreateFile();
                        break;
                    case 2:
                        program.RenameFile();
                        break;
                    case 3:
                        program.ConcatFile();
                        break;
                    case 4:
                        program.DisplayContent();
                        break;
                    case 5:
                        program.WriteFile();
                        break;
                    case 6:
                        program.DeleteFile();
                        break;
                    case 7:
                        program.CopyFile();
                        break;
                    case 8:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;
                }

            } while (choice != 7);
        }

        public void CreateFile()
        {
           
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if(!File.Exists(Path))
            {
                var file=File.CreateText(Path);
                Console.WriteLine(" file successfully Created");
                file.Close();
            }
            else
            {
                Console.WriteLine("Already Exits");
            }
                
        }
        public void RenameFile()
        {
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
             
           FileInfo fileInfo = new System.IO.FileInfo(Path);
            
            if (fileInfo.Exists)
            {
                Console.WriteLine("Enter new File Name");
                string newName = Console.ReadLine();
                string newPath = filepath + newName;
                fileInfo.MoveTo(newPath);
                Console.WriteLine("File Renamed Successfully");
            }
            else
            {
                Console.WriteLine("File Not exist");
            }
        }
        public void ConcatFile()
        {
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter First FileName using .txt extension");
            string firstfileName = Console.ReadLine();
            string FirstFilePath = filepath + firstfileName;
            Console.WriteLine("Enter First FileName using .txt extension");
            string secondfileName = Console.ReadLine();
            string secondFilePath = filepath + secondfileName;
            if (File.Exists(FirstFilePath))
            {
                FileStream f1 = null;
                FileStream f2 = null;
                f1 = File.Open(FirstFilePath, FileMode.Append);
                f2 = File.Open(secondFilePath, FileMode.Open);
                //f1.Read()
                StreamReader sr = new StreamReader(f2);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                   StreamWriter sw = new StreamWriter(f1);              
                    sw.Write(line);
                    sw.Close();
                }
                sr.Close();
                Console.WriteLine("Successfully Done");
            }
            else
            {
                Console.WriteLine("File Not Found");
            }

        }

        public void CopyFile()
        {
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                Console.WriteLine("Enter Filename where you want to copy");
                string filecopy = Console.ReadLine();
                string newPath = filepath + filecopy;
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                    
                }
                File.Copy(Path, newPath);

                Console.WriteLine("Successfully copied...");
            }
        }
        public void DisplayContent()
        {
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
            }
        }
        public void WriteFile()
        {
             string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                Console.WriteLine("Write Content Here....");
                var content = Console.ReadLine();
                StreamWriter sw = new StreamWriter(Path);              
                    sw.Write(content);
                    sw.Close();
                Console.WriteLine("Successfully Added Content");
       
            }

        }
        public void DeleteFile()
        {
            string filepath = @"C:\Users\Shivam Dubey\Desktop\";
            Console.WriteLine("Enter FileName using .txt extension");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }
    }
}
