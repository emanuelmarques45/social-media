dotnet ef database update 0;
dotnet ef migrations remove;
dotnet ef migrations add init;
dotnet ef database update;

Invoke-Sqlcmd -InputFile .\populate.sql;