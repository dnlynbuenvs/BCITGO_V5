# **📖 PROJECT FLOW CREATION GUIDE 📖** #

## 1️⃣ Install Packages
_______________________________________

### **1. Install the Required Packages for ASP.NET MVC Project**
- In **Visual Studio 2022**, go to:
  - **Tools** → **NuGet Package Manager** → **Manage NuGet Packages for Solution...**

❗Make sure that all packages should be the same version or lower version with `Microsoft.EntityFrameworkCore` 

### **2.  Required Packages for Your ASP.NET MVC Project**  

#### **✅ Essential for Database & Entity Framework**  
1.  `Microsoft.EntityFrameworkCore` **(v8.0.12)**  (For Entity Framework Core ORM)
2.  `Microsoft.EntityFrameworkCore.SqlServer` **(v8.0.12)** (For SQL Server)  
3.  `Microsoft.EntityFrameworkCore.Tools` **(v8.0.12)** (For Migrations)  


#### **✅ For ASP.NET Identity (Only if Using Authentication)**  
1.  `Microsoft.AspNetCore.Identity.EntityFrameworkCore` **(v8.0.12)** (For User Authentication & Identity Management) 
2. `Microsoft.AspNetCore.Identity.UI`**(v8.0.12)** (For Prebuilt Identity UI)



#### **✅ For MVC Views & UI Components**  
1.  `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` **(v8.0.00)** (For Razor View Updates Without Restarting)  
2.  `Microsoft.AspNetCore.Mvc.NewtonsoftJson` **(v8.0.00)** (For JSON Serialization Support)  



#### **✅ For Paging & Sorting (Required for Your Project)**  
1.  `X.PagedList.Mvc.Core` **(v10.5.7)** (For Pagination & Sorting in Tables)  

#### **✅ Additional Packages for Debugging & Scaffolding** 
1. `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`  **(v8.0.00)** (For Better EF Core Error Handling & Debugging)
2. `Microsoft.VisualStudio.Web.CodeGeneration.Design` **(v8.0.00)** (For Scaffolding Controllers, Models, & Views)
_______________________________________


## 2️⃣ Setup Database
_______________________________________
### **1.  Required Packages for Your ASP.NET MVC Project**  


