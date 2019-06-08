using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabtAhval
{
    static class DataController
    {
        private const string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
        public static void Insert(Person _person)
        {
            string sql = null;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {

                sql = "INSERT INTO [Persons] ([NationalNumber],[FirstName],[LastName],[BirthDate],[DeathDate],[Father],[Mother],[Spouse]) " +
                    "values(@natNum,@first,@last,@birthDate,@deathDate,@father,@mother,@spouse)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@first", _person.FirstName);
                    cmd.Parameters.AddWithValue("@last", _person.LastName);
                    cmd.Parameters.AddWithValue("@natNum", _person.NationalNumber);
                    cmd.Parameters.AddWithValue("@birthDate", _person.BirthDate);
                    if (_person.DeathDate < new DateTime(1754, 1, 1))
                        cmd.Parameters.AddWithValue("@deathDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@deathDate", _person.DeathDate);

                    if (_person.Father != null)
                        cmd.Parameters.AddWithValue("@father", _person.Father.NationalNumber);
                    else
                        cmd.Parameters.AddWithValue("@father", DBNull.Value);

                    if (_person.Mother != null)
                        cmd.Parameters.AddWithValue("@mother", _person.Mother.NationalNumber);
                    else
                        cmd.Parameters.AddWithValue("@mother", DBNull.Value);

                    if (_person.Spouse != null)
                        cmd.Parameters.AddWithValue("@spouse", _person.Spouse.NationalNumber);
                    else
                        cmd.Parameters.AddWithValue("@spouse", DBNull.Value);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\tPerson inserted into database successfully.");
                }
                cnn.Close();
            }
        }

        public static void Delete(Person _person)
        {
            string sql = null;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "DELETE FROM [Persons] WHERE [NationalNumber] = @natNum";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@natNum", _person.NationalNumber);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\tPerson deleted from database successfully.");
                }
                cnn.Close();
            }
        }

        public static Person[] List(Person _person)
        {
            List<Person> result = new List<Person>();
            string sql = null;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "SELECT [NationalNumber],[FirstName],[LastName],[BirthDate] FROM [Persons] WHERE [NationalNumber] = @natNum";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@natNum", _person.NationalNumber);

                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Person temp = new Person(reader.GetString(0));
                            temp.FirstName = reader.GetString(1);
                            temp.LastName = reader.GetString(2);
                            temp.BirthDate = reader.GetDateTime(3);
                            result.Add(temp);
                        }
                    }
                }
                cnn.Close();
            }
            return result.ToArray();
        }

        public static void Update(Person _person)
        
            Console.WriteLine("we have to write the code for update");
        }

        internal static void AddErrorMessage()
        {
            Console.WriteLine("error using add");

        }
        internal static void DeleteErrorMessage()
        {
            Console.WriteLine("error using delete");

        }
        internal static void ListErrorMessage()
        {
            Console.WriteLine("error using list");

        }
        internal static void UpdateErrorMessage()
        {
            Console.WriteLine("error using update");

        }

    }
}
