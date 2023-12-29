# MySQL and Entity Framework Core (Code-First)

A small Hello World sample project showing how to use MySQL with EF Core in a code-first approach.

The MySql database and tables will be automatically created to
match the C# classes in the project (that's referrect to as "code first" EF). For reference, I've checked in
a sample `Migrations` folder that contains automatically generated
code to create those tables, but you should use the commands below
to trivially generate your own custom database creation code.

Also, as a general note, if you are actively reading about MySQL and EF Core, you should note there are two MySQL to EF 
adapters, one from Oracle and one from the Pomelo Foundation. The syntax for the two is nearly the same but they
capitalize the `UseMySql()` method differently - `UseMySQL()` vs `UseMySql()`. That tripped me up more than I'd like to admit
when I was first trying to stitch together examples from different sources
to get this working.

## Setup

First, edit the connection string in `appsettings.json` to have the desired
database name, username, and password.

Then, to create the database and tables, run the following commands before running this project. 

This approach of creating the database and tables from C# classes is called "code-first". The
`dotnet ef` commands will create a folder called `Migrations`, populate it with C# code that
will create the database and tables that match the project, and then then run the
migrations to create the database and tables, all under the direction
of your connection string in `appsettings.json`. For reference, I've checked in
a sample Migrations folder, but you should use the commands below
to create your own.

```bash
dotnet tool install --global dotnet-ef
dotnet restore

rm -r ./Migrations

dotnet ef migrations add Initial -o Migrations -c SampleDbContext
dotnet ef database update -c SampleDbContext
```

## Thanks

These articles helped me get this working:

* [Web API With ASP.NET 6 And MySQL](https://www.c-sharpcorner.com/article/rest-api-with-asp-net-6-and-mysql/)
* [Entity Framework 7 Code First Using CLI](https://www.c-sharpcorner.com/article/entity-framework-7-code-first-using-cli/)
