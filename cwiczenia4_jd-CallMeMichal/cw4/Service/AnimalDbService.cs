using cw4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace cw4.Service
{
    public class AnimalDbService : IAnimalDbService
    {
        
        private const string _connectionString = "Data Source = db-mssql; Initial Catalog = 2019sbd; Integrated Security = True";
        public async Task<IList<Animal>> GetAnimalListAsync(string orderBy)
        {
            try
            {
                List<Animal> animal = new();

                await using SqlConnection sqlConnection = new(_connectionString);
                await using SqlCommand sqlCommand = new();

                string sql;

                if (!(orderBy == "IdAnimal"))
                {
                    if (string.IsNullOrWhiteSpace(orderBy))
                    {
                        sql = "SELECT * FROM Animal ORDER BY Name";
                    }

                    else
                    {
                        sql = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";


                    }

                }
                else
                {
                    throw new Exception("Invalid orderBy parameter, you cant use IdAnimal");
                }

                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;

                await sqlConnection.OpenAsync();

                await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                while (await sqlDataReader.ReadAsync())
                {
                    Animal animals = new()
                    {

                        Name = sqlDataReader["Name"].ToString(),
                        Description = sqlDataReader["Description"].ToString(),
                        Category = sqlDataReader["Category"].ToString(),
                        Area = sqlDataReader["Area"].ToString()

                    };
                    animal.Add(animals);
                }

                await sqlConnection.CloseAsync();

                return animal;
            }
            catch(Exception e)
            {
                return null;
            }
        }




        public async Task<bool> AddAnimalAsync(Animal animal)
        {
            try {
                await using SqlConnection sqlConnection = new(_connectionString);
                await using SqlCommand sqlCommand = new();
                string sql;
                sql = $"INSERT INTO Animal(Name, Description, Category, Area) VALUES('{animal.Name}', '{animal.Description}', '{animal.Category}', '{animal.Area}')";




                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;


                await sqlConnection.OpenAsync();
                await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                await sqlConnection.CloseAsync();
                return true;
                }catch(Exception ex)
            {
                return false;
            }


        }

        public async Task<bool> PutAnimalAsync(int id,[FromBody]Animal animal)
        {
            try {
                await using SqlConnection sqlConnection = new(_connectionString);
                await using SqlCommand sqlCommand = new();
                string sql;

                sql = $"UPDATE Animal SET Name = '{animal.Name}', Description ='{animal.Description}' ,Category='{animal.Category}',Area='{animal.Area}' WHERE IdAnimal={id}"; ;


                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;


                await sqlConnection.OpenAsync();
                await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                await sqlConnection.CloseAsync();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAnimalAsync(int id) 
        {
            try
            {
                await using SqlConnection sqlConnection = new(_connectionString);
                await using SqlCommand sqlCommand = new();
                string sql;

                sql = $"DELETE FROM Animal WHERE IdAnimal ={id} ";

                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;


                await sqlConnection.OpenAsync();
                await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                await sqlConnection.CloseAsync();
                return true;
            }
            catch (Exception e) {
                return false;    
            }


         }

       
    }
}
