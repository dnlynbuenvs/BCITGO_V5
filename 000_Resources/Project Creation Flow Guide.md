# **📖 PROJECT FLOW CREATION GUIDE 📖** #

## 1️⃣ Install Packages
_______________________________________

### **1. Install the Required Packages for ASP.NET MVC Project**
- In **Visual Studio 2022**, go to:
  - **Tools** → **NuGet Package Manager** → **Manage NuGet Packages for Solution...**

❗Make sure that all packages should be the same version or lower version with `Microsoft.EntityFrameworkCore` 

### **2.  Required Packages for Your ASP.NET MVC Project**  

#### **✅ Essential for Database & Entity Framework**  
-  `Microsoft.EntityFrameworkCore` **(v8.0.12)**  (For Entity Framework Core ORM)
-  `Microsoft.EntityFrameworkCore.SqlServer` **(v8.0.12)** (For SQL Server)  
-  `Microsoft.EntityFrameworkCore.Tools` **(v8.0.12)** (For Migrations)  


#### **✅ For ASP.NET Identity (Only if Using Authentication)**  
-  `Microsoft.AspNetCore.Identity.EntityFrameworkCore` **(v8.0.12)** (For User Authentication & Identity Management) 
- `Microsoft.AspNetCore.Identity.UI`**(v8.0.12)** (For Prebuilt Identity UI)



#### **✅ For MVC Views & UI Components**  
-  `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` **(v8.0.00)** (For Razor View Updates Without Restarting)  
-  `Microsoft.AspNetCore.Mvc.NewtonsoftJson` **(v8.0.00)** (For JSON Serialization Support)  



#### **✅ For Paging & Sorting (Required for Your Project)**  
1.  `X.PagedList.Mvc.Core` **(v10.5.7)** (For Pagination & Sorting in Tables)  

#### **✅ Additional Packages for Debugging & Scaffolding** 
1. `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`  **(v8.0.00)** (For Better EF Core Error Handling & Debugging)
2. `Microsoft.VisualStudio.Web.CodeGeneration.Design` **(v8.0.00)** (For Scaffolding Controllers, Models, & Views)
_______________________________________


## 2️⃣ Setup Connection String
_______________________________________
### 1. Modify `appsettings.json` to Add the Connection String ####

At the top of:
```csharp
{
  "Logging": {
```

add the code below:
```csharp
{

  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BCITGODB;User ID=Dannie Password=dannie;Trusted_Connection=True;Encrypt=False"

  },
```

## 3️⃣ Setup ApplicationDbContext
_______________________________________
### This manages the connection to the database and provides access to the tables (models) in the database for performing operations like adding, updating, or retrieving data. ####


1.  Create `data` folder and create `ApplicationDbContext` class inside.
2. Setup > check my code for reference

## 4️⃣Create DbInitializer
_______________________________________
### DbInitializer is for seeding data (if you need to add initial records or test data to your tables) ####

1. Under `data` folder, create `DbInitializert` class inside.
2. Setup > check my code for reference

## 5️⃣ Define the Model Classes 
_______________________________________
### This represents the structure of your database tables and allows you to interact with the database using Entity Framework Core for data manipulation. ####

1. Under `models` folder, create class for each table. *(see sample below)*

<img src="./images/1_ClassSample.png" alt="Model Classes" width="250"/>











