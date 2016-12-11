using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using MVCEveining.ViewModels;
using System.Data.SqlClient;

namespace MVCEveining.Models
{
    public class Repository
    {

        public string connectionString =
System.Configuration.ConfigurationManager.ConnectionStrings["evening"].ConnectionString;

        internal void Create(Person personClass)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Human
                                        (Name,Address,BirthDate)
                                         VALUES
                                        (@Name,@Address,@BirthDate)";

                command.Parameters.AddWithValue("@Name", personClass.Name);
                command.Parameters.AddWithValue("@Address", personClass.Address);
                command.Parameters.AddWithValue("@BirthDate", personClass.BirthDate);

                connection.Open();
                command.ExecuteNonQuery();

            }
        }




        public LoginForm Authenticate(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * 
                                        FROM users
                                        WHERE UserName =@UserName 
                                        and Password = @Password;

                                       ";

                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                var reader = command.ExecuteReader();
                LoginForm user = null;
                if (reader.Read())
                {
                    user = new LoginForm();
                    user.UserName = reader["UserName"] as string;
                    user.Password = reader["Password"] as string;
                }

                return user;
            }
        }


        internal void Update(Person update)
        {
            using (var conneciton = new SqlConnection(connectionString))
            using (var command = conneciton.CreateCommand())
            {
                command.CommandText = @"
                                        Update Persons
                                                SET Name = @Name,
                                                Address  = @Address,
                                                BirthDate =@BirthDate
                                            Where Id = @Id";
                command.Parameters.AddWithValue("@Id", update.Id);
                command.Parameters.AddWithValue("@Name", update.Name);
                command.Parameters.AddWithValue("@Address", update.Address);
                command.Parameters.AddWithValue("@BirthDate", update.BirthDate);
                conneciton.Open();
                command.ExecuteNonQuery();
            }
        }
        internal void Delete(Person person)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                                        Delete from Persons
                                         WHERE Id = @Id
                                         ";

                command.Parameters.AddWithValue("@Id", person.Id);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }



        public List<Person> GetList(string searchTerm)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                                        SELECT *
                                        FROM Persons
                                        where name like @name
                                         ";
                command.Parameters.AddWithValue("@name", searchTerm + "%%");
                connection.Open();
                var reader = command.ExecuteReader();
                var mylists = new List<Person>();
                while (reader.Read())
                {
                    var humanList = new Person();
                    humanList.Id = (int)reader["Id"];
                    humanList.Name = reader["Name"] as string;
                    humanList.Address = reader["Address"] as string;
                    humanList.BirthDate = (DateTime)reader["BirthDate"];
                    mylists.Add(humanList);
                }
                return mylists;
            }
        }



        public Person GetListForUpdate(string ID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                                        SELECT *
                                        FROM Persons
                                        WHERE Id =@Id
                                         ";
                command.Parameters.AddWithValue("@Id", ID);
                connection.Open();
                var reader = command.ExecuteReader();


                Person humanList = null;
                if (reader.Read())
                {
                    humanList = new Person();
                    humanList.Id = (int)reader["Id"];
                    humanList.Name = reader["Name"] as string;
                    humanList.Address = reader["Address"] as string;
                    humanList.BirthDate = (DateTime)reader["BirthDate"];

                }
                return humanList;
            }
        }

        //public List<Person> GetListJoin()
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    using (var command = connection.CreateCommand())
        //    {
        //        command.CommandText = @"
                                       
        //                                    SELECT Human.Id as HumanId,Human.Name HumanName,country.Country CountryName
        //                                    FROM Human  join country
        //                                    on Human.Id = country.HumanId
        //                                 ";
        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        var mylists = new List<Person>();
        //        while (reader.Read())
        //        {
        //            var humanList = new Person();
        //            humanList.HumanId = (int)reader["HumanId"];
        //            humanList.HumanName = reader["HumanName"] as string;
        //            humanList.CountryName = reader["CountryName"] as string;

        //            mylists.Add(humanList);
        //        }
        //        return mylists;
        //    }
        //}
    }
}