# Blog

This is a sample blog web site using Blazor and .Net 8. 

The application follows SOLID principles and uses domain driven design architecture.

# Setup

Clone the repository from https://github.com/cristianmagurean-pacifica/Blog.git

Open the project from Visual Studio

Use appsettings.json from Blog.WebApi to update the connection string to the database

Launch the project in debug mode or go to Solution Explorer, select FPriceAPI and use contextual menu Publish to publish the Web API

# Technologies

Blazor, HTML, CSS

.NET 8

Web API

.EF Core with code first

SQL Server database

XUnit, Moq - for unit testing

# How to run the application locally (from within Visual Studio)

Configure startup projects to use multiple startup projects:  Bog.WebApi and Blog.WebClient

Launch the project in Debug mode and use Swagger to test the back-end or use the front-end to test the application