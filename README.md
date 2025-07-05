# Inventory Management System

## Introduction
This project is built to demonstrate the architecture, coding practices, and skills associated with building a **RESTful API**. The system is a **Simple Inventory Management App** implemented using **ASP.NET Core, Entity Framework Core, and MySQL**. It allows users to:
- View a list of available products.
- Add new products.
- Update product information.
- Delete products.

The Repository implements unit tests for all critical layers (Service and Controller) and ensures >80% code coverage. Validation for DTOs and error handling are also implemented.

---

## Application Information

### **Tech Stack**
- **Programming Language**: C# (.NET 6)
- **Framework**: ASP.NET Core Web API
- **Database**: MySQL (via EF Core)
- **Unit Testing**: xUnit and Moq for unit testing
 **Tools for Quality**:
  - Code style checks: `StyleCop.Analyzers`
  - Code coverage: `coverlet`

  ## Feedback for Inventory App

### Was it easy to complete the task using AI?
It was manageable with ChatGPT's assistance. ChatGPT provided detailed explanations and guided the architecture to completion smoothly. The integration of various layers was clear and systematic.

### How long did the task take you to complete?
Including initial setup, debugging, and testing, the task took approximately **5 hours**. Most of the time was spent on debugging specific errors and setting up proper connections.

### Was the code ready to run after generation? What did you have to change to make it usable?
The generated code was solid and helped establish a solid foundation for the project. However, minor adjustments were required:
- Fixing input validation errors.
- Correcting field mappings between DTOs and models.
- Debugging issues related to JSON formatting.

### Which challenges did you face during the completion of the task?
Key challenges included:
- Learning how to configure EF Core migrations and MySQL connections properly.
- Handling validation errors caused by incorrect JSON input formatting.
- Debugging folder or file mismanagement in GitHub repository structure.

### Which specific prompts you learned as a good practice to complete the task?
Key learning points:
- Be precise about architecture and folder structure in prompts.
- Break tasks into smaller parts (e.g., entities, repository, service, controller layers).
- When debugging errors, ask specific questions to avoid ambiguity.