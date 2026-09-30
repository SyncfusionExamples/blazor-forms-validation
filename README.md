# Blazor Forms and Form Validation

## Overview

This sample demonstrates how to build a student registration form in a Blazor WebAssembly application and validate user input before submission. The application combines standard Blazor form validation using data annotations with custom business-rule validation that addresses requirements not covered by built-in validation attributes.

The sample is useful for developers who need to implement reliable form validation workflows, provide clear validation feedback, and enforce application-specific business rules in Blazor applications. It also demonstrates a hosted Blazor WebAssembly solution structure that separates client, server, and shared code for maintainability.

## Key Features

- Implements a student registration form using Blazor's `EditForm` component.
- Uses `DataAnnotationsValidator` to enable validation based on .NET Data Annotations.
- Demonstrates field-level validation with `ValidationMessage` components for individual form fields.
- Validates required fields such as first name, last name, email, username, password, confirm password, and gender.
- Uses the `EmailAddress` attribute to validate email input format.
- Uses the `Compare` attribute to ensure password and confirm password values match.
- Uses a `RegularExpression` attribute to enforce password complexity requirements, including uppercase, lowercase, numeric characters, and minimum length.
- Implements a custom `UserNameValidation` attribute to prevent usernames containing restricted words such as "admin".
- Demonstrates custom validation logic through the `CustomFormValidator` component.
- Uses `ValidationMessageStore` and `EditContext` to add and manage validation errors programmatically.
- Clears validation messages automatically when validation is requested or form fields are modified.
- Sends registration data to a backend API using `HttpClient.PostAsJsonAsync`.
- Performs server-side business validation through `StudentController`.
- Checks username availability on the server and returns model validation errors when duplicate usernames are detected.
- Displays server-side validation errors within the Blazor form without requiring page refreshes.
- Logs successful registrations and validation failures using ASP.NET Core logging.
- Shows successful registration feedback using a Bootstrap success alert.
- Includes a Weather Forecast sample page demonstrating data retrieval using `HttpClient.GetFromJsonAsync`.
- Uses shared models and validation classes through a common Shared project for code reuse across Client and Server applications.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open `BlazorFormsValidation.sln`.
3. Restore all NuGet packages.
4. Ensure the server project is configured as the startup project if required by your environment.
5. Build the solution.
6. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Navigate to the repository root folder.
3. Execute the following commands:

```bash
dotnet restore
dotnet run --project Server/BlazorFormsValidation.Server.csproj
```

4. Open the local URL displayed in the terminal after the application starts.

## Project Structure

`Client/Pages/Registration.razor` - Student registration UI built with Blazor `EditForm`, input components, validation messages, and form submission handling.

`Client/Pages/Registration.razor.cs` - Code-behind component that manages registration state, submits form data, processes server responses, displays validation errors, and logs registration results.

`Client/Pages/FetchData.razor` - Demonstrates retrieving weather forecast data from the server using `HttpClient` and rendering the results in a table.

`Client/Shared/CustomFormValidator.cs` - Custom Blazor validation component that uses `ValidationMessageStore` to display and manage server-side validation errors.

`Client/Shared/SurveyPrompt.razor` - Reusable sample component demonstrating parameterized content rendering.

`Server/Controllers/StudentController.cs` - ASP.NET Core API controller that performs server-side business validation and checks username availability.

`Server/Controllers/WeatherForecastController.cs` - API endpoint that generates and returns sample weather forecast data.

`Shared/Models/StudentRegistration.cs` - Shared registration model containing validation rules defined using Data Annotation attributes.

`Shared/Models/UserNameValidation.cs` - Custom validation attribute that prevents usernames containing restricted keywords.

`Shared/WeatherForecast.cs` - Shared weather forecast model used by both Client and Server projects.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For guidance on Blazor form validation, refer to the official Syncfusion Blog: https://www.syncfusion.com/blogs/post/blazor-forms-and-form-validation

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.