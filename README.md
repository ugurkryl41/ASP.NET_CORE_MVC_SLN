# ASP.NET CORE MVC

## Project Description
### This project is a web application developed with ASP.NET Core MVC and built using various modern software technologies and architectures. Below, the main components and structures used in the project are explained in detail.

## Technologies Used
* ASP.NET Core MVC: This project is built on ASP.NET Core using the Model-View-Controller (MVC) pattern.
* Entity Framework Core: Entity Framework Core is used for database operations.
* AutoMapper: AutoMapper is used for object mapping and data transformations.
* Bootstrap: The Bootstrap library is used to build the user interface.


## Architectures and Structures
* Layered Architecture: The project is structured according to the principles of layered architecture.
* Presentation Layer: Contains the user interface and MVC controllers.
* Business Logic Layer: Contains the business rules and application logic.
* Data Access Layer: Contains the data access layer, implemented using Entity Framework Core.

## Features and Structures
* Dependency Injection: Dependency injection (DI) is used in the project.
* Tag Helpers: ASP.NET Core MVC Tag Helpers are used to extend HTML elements and Razor components.
* Middleware: Custom middleware components are used to process HTTP requests and responses.
* Automatic Mapping: AutoMapper is used to perform transformations between data models.

## Database Migrations 
* Code-First Migrations: Entity Framework Core is used to manage the database schema with a Code-First approach.

## User Management
* Session Management: User session management and authentication processes are implemented.
* Role-Based Authorization: User roles and authorization processes are managed.

## User Interface
* Responsive Design: A responsive and user-friendly interface design has been implemented using Bootstrap.

## Design Patterns 
* Repository Pattern: The Repository pattern is used in the data access layer to abstract data access operations. This centralizes database operations.
* Unit of Work: Ensures that operations across multiple units are managed consistently as a whole. This pattern is especially used in database operations.
* Dependency Injection (DI): The Dependency Injection pattern is used to manage dependencies, making components more testable and manageable.
* Factory Pattern: Factory patterns are used to abstract the object creation process. This makes object creation more flexible and modular.

# Software Methodologies and Design Principles
## SOLID Principles
* Single Responsibility Principle (SRP): Each class should have only one responsibility. For example, the ServiceExtension.cs file is responsible solely for adding services to the DI container.
* Open/Closed Principle (OCP): Classes should be open for extension but closed for modification. In the project, interfaces and abstract classes are used to extend functionality without changing existing code.
* Liskov Substitution Principle (LSP): Derived classes should be able to replace their base classes. This principle is particularly considered when working with data models and transformations with AutoMapper.
* Interface Segregation Principle (ISP): Specific interfaces are defined for each functionality, ensuring that users are not forced to implement unnecessary methods.
* Dependency Inversion Principle (DIP): High-level modules should not depend on low-level modules. Dependencies are managed through abstractions.

## Clean Code
* Readability: The code is written to be easily readable and understandable. Meaningful variable names and clearly defined methods are used.
* Reusability: The code is written in reusable components, which enhances the maintainability and scalability of the project.
* Testability: Dependency injection and abstractions are used to make unit testing easier.

## DRY (Don't Repeat Yourself)
* Repetition of code or logic is avoided. For instance, data transformations are centrally managed using AutoMapper, making development faster and with fewer errors.

## KISS (Keep It Simple, Stupid)
* The code is kept as simple and understandable as possible. Simple and effective solutions are preferred over complex structures. This reduces maintenance costs and helps new developers quickly understand the project.

## YAGNI (You Aren't Gonna Need It)
* Unnecessary features are avoided. Only components necessary to meet the current project requirements are included, speeding up development and keeping the codebase clean.  
