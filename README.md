# Prototype-Web-Application
E-commerce website demo
Student Name: Eze Philip
Student Number: 17393140

			DESCRIPTION

It is a prototype web application developed using Visual Studio 2017, for a fast-growing local e-commerce store called ACME INC.






			IMPORTANT NOTICE

1. All Iservices within the MyShop.Core.Contracts are Interfaces

2. Add public access modifier to all class libraries (Projects)

3. The use of word "Customer" in the models, Entity framework etc. is a misnomer. it cover both the admin employee and the customer  that use the website. When building on your machine, you can change it to "User"

4. When Inputing the product info, ensure that the price is a whole number. Avoid adding a decimal value, as it would most likely not be accepted.





		

			HOW TO BUILD



NUGET PACKAGES:

1. Unity.mvc (Installed for MyShop.WebUI) ---- latest version

2. Bootstrap v3.3.7 (Installed for MyShop Solution)

3. Entity Framework (Installed for MyShop.DataAccess.SQL and MyShop.WebUI) ---- latest version





ESSENTIAL DEPENDENCIES/REFERENCES:

1. System.Web
This is used to assist the MyShop.Services to read Cookies with the aid of HttpContext
Right-click on MyShop.Services, click "add" reference, click on "Assemblies"
and select "System.Web"






DATABASE CONNECTION:

1. Connect to your local server using the text phrase localhost
ex. "localhost\SQLEXPRESS"

2. Go to the Web.Config and implement the connection string
ex. <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=MyShop;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>

3. Copy this connection string and implement it within the App.Config of MyShop.DataAccess.SQL

4. special classes that are responsible for connecting to the dB and creating/updating the database. This requires special commands that are executed in unique command window called the "package manager console".
Open up the PMC, connect it to the correct project(MyShop.DataAccess.SQL). Then right-click on MyShop.WebUI to set as Startup project. 

		MIGRATIONS
type "Enable-Migrations" into the Console and press enter.

Migration are special class that when executed will tell entity framework how to create our tables. Type "Add-Migration" to create the first migration and call it 'initial'

Finally we have entity framewaork create our database based on the initial script
Type "Update-Database"

Repeat the same process to create new Migrations with their unique names and then update the database with the migration data

PLS NOTE: 

----- A Migrations folder is created on DataAccess project with a configuration.cs file
----- The configuration.cs is where we can manually add data on a database.



5. In order to decide Admin and Customer roles, I Implemented OpenID a popular solution in the industry.
First, Go to https://docs.microsoft.com/en-us/dotnet/api/system.security.claims.claimtypes.role?view=netcore-3.1
and copy the ClaimType URI.
Then following the pic as guide right-click on dbo.AspNetUserClaims on your Database table list. Find your way to the Query Editor and and insert  the claimType URI into the ClaimType VALUES. 
Type 'Admin' into the claimValue VALUES. Then get the UserID by Rightclicking on the dbo.AspNetUsers tables, and then select "Edit Top 200 Rows".




ABOUT UNITY

Unity.mvc allows us to make use of a DI container to inject concrete classes in place of the interface.
To achieve this, we use the "UnityConfig.cs" class , which is under the App_Start Folder on the MyShop.WebUI project.
There, You can create a container, by which we will register the concrete classes against the interface. The container will be called to resolve these dependencies when required.





			
			TEST DATA

ADMIN:

Username --- tryphilo@hotmail.com
Pasword --- 12345Abcd*@!



CUSTOMER:

Username --- thatonovember@gmail.com
Pasword --- 6789Efgh*@!


PRODUCT TYPES:

Milk
Bread
CornFlakes
Rice


PRODUCT:

1. Name: Tastic Rice , Description: a type of bagged rice , Price: 125,00 , Category: Rice

2. Name: Kellogs CornFlakes , Description: A type of Corn flakes , Price: 51,00 , Category: CornFlakes

3.  Name: Clover Cream Milk , Description: a type of carton milk , Price: 79,00, Category: Milk

4. Name: Albany sliced bread, Description: a type of sliced bread , Price: 18,00, Category: Bread



IN_ADDITION: I have attached copies of product images to this document.
