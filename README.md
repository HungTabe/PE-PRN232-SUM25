# PE-PRN232-SUM25


Prepare code : 

"ConnectionStrings": {

    "MyCnn": "Server=DESKTOP-OLU548T;Database=ViroCureFAL2024DB;uid=sa;pwd=saadmin;TrustServerCertificate=True;",
    
  }


4 CSDL

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.7

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.7

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.7

2 JSON

dotnet add package Microsoft.Extensions.Configuration --version 8.0.0

dotnet add package Microsoft.Extensions.Configuration.Json --version 8.0.0


private string GetConnectionString()

 {
 
     IConfiguration config = new ConfigurationBuilder()
     
          .SetBasePath(Directory.GetCurrentDirectory())
          
                 .AddJsonFile("appsettings.json", true, true)
                 
                 .Build();
                 
     var strConn = config["ConnectionStrings:MyCnn"];
     

     return strConn;
     
 }

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 
     => optionsBuilder.UseSqlServer(GetConnectionString());
