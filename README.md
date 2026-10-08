# Movie Register

Movie Register is a C# console application that manages movies and genres in a SQL Server database. It uses ADO.NET to connect to the database and lets the user list all movies with their genre, search for movies by genre, add new movies and delete movies. All database communication uses parameterized SQL queries and is handled in a separate repository class, kept apart from the user interface.

## Features
- List all movies with their genre
- Search movies by genre
- Add a new movie linked to an existing genre
- Delete a movie

## Technologies
- C# / .NET
- ADO.NET (Microsoft.Data.SqlClient)
- SQL Server

## Getting started
1. Run the SQL script in SSMS to create the database and test data.
2. Check the connection string in the repository class.
3. Run the application in Visual Studio.
