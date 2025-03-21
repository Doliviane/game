// See https://aka.ms/new-console-template for more information

using System;
using Microsoft.Data.Sqlite;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
         using var connection = new SqliteConnection("Data Source=maBase.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS utilisateurs (id INTEGER PRIMARY KEY, nom TEXT)";
        command.ExecuteNonQuery();

        command.CommandText = "INSERT INTO utilisateurs (nom) VALUES ('Alice')";
        command.ExecuteNonQuery();

        command.CommandText = "SELECT * FROM utilisateurs";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"ID : {reader.GetInt32(0)}, Nom : {reader.GetString(1)}");
        }
      Console.WriteLine("Hello World!");  
      
    }
  }
}