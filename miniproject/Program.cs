using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace miniproject // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=.;Initial Catalog=MProject;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                //Console.WriteLine("Connection estabished successfully");
                Console.WriteLine("Selamat Datang Di Aplikasi Pendataan Peserta Magang Kantor Wisnu Sejahtera");
                string answer;
                do
                {

                    Console.WriteLine("Pilih\n1.Buat Baru\n2.Lihat Data\n3.Update Data\n4.Hapus Data");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:

                            //insert
                            Console.WriteLine("Masukan Nama Peserta: ");
                            string userName = Console.ReadLine();

                            Console.WriteLine("Masukan Umur: ");
                            int userAge = int.Parse(Console.ReadLine());
                            string insertQuery = "INSERT INTO DETAILS(user_name, user_age) VALUES ('" + userName + "'," + userAge + ")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Selamat! Data Berhasil Terinput ");
                            //Retrieve=> R
                            break;

                        case 2:
                            //Display

                            string displayQuery = "SELECT * FROM Details";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());

                            }
                            dataReader.Close();
                            break;

                        case 3:
                            //update
                            int u_id;
                            int u_age;
                            Console.WriteLine("Masukan Id User Yang Akan Di Update");
                            u_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the age the user to you would like to update");
                            u_age = int.Parse(Console.ReadLine());
                            string updateQuery = "UPDATE Details SET user_age = " + u_age + "WHERE user_id = " + u_id + "";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Selamat! Data Anda Berhasil Terupdate ");
                            break;

                        case 4:

                            //delete
                            int d_id;
                            Console.WriteLine("Masukan Id User Yang Akan Di Hapus");
                            d_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "DELETE FROM Details WHERE user_id = " + d_id;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Selamat! Data Anda Berhasil Terhapus");
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;

                    }
                    Console.WriteLine("Apakah anda ingin lanjut?Y/N");
                    answer = Console.ReadLine();

                } while (answer != "No");
                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}