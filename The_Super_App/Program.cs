// See https://aka.ms/new-console-template for more information
using Dapper;
using System.Data.SqlClient;
using The_Super_App.Models;

Console.WriteLine("Hello, The Super App");

var cs = @"Server=(localdb)\MSSQLLocalDB;Database=DapperDB;Trusted_Connection=True;;";

using var con = new SqlConnection(cs);
con.Open();

var version = con.Query<Person>("select * from Person").ToList();

version.ForEach(person => Console.WriteLine($"{person.Id}, {person.FirstName}"));
con.Close();