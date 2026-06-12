# Unit Converter API

## Overview

Unit Converter API is a RESTful ASP.NET Core Web API that converts values between different units of measurement.

The solution currently supports:

* Length conversions
* Weight conversions
* Temperature conversions

The application was designed to be extensible so that additional conversion categories can be added with minimal changes to existing code.

---

## Supported Units

### Length

| Unit       | Symbol |
| ---------- | ------ |
| Meter      | m      |
| Centimeter | cm     |
| Kilometer  | km     |

### Weight

| Unit     | Symbol |
| -------- | ------ |
| Kilogram | kg     |
| Gram     | g      |
| Pound    | lb     |

### Temperature

| Unit       | Symbol |
| ---------- | ------ |
| Celsius    | c      |
| Fahrenheit | f      |
| Kelvin     | k      |

---

## Solution Structure

```text
dotnet/
│
├── UnitConverter.sln
│
├── unit-converter/
│   ├── Controllers/
│   ├── Converters/
│   ├── Domain/
│   ├── Exceptions/
│   ├── Models/
│   ├── Registry/
│   ├── Services/
│   ├── Dockerfile
│   └── docker-compose.yml
│
└── unit-converter.Tests/
```

---

## Architecture

The application follows a layered architecture:

```text
HTTP Request
      ↓
Controller
      ↓
ConversionService
      ↓
UnitConverterFactory
      ↓
Converter Implementation
      ↓
UnitRegistry
```

### Responsibilities

#### Controller

Responsible for:

* Receiving HTTP requests
* Model validation
* Returning HTTP responses

The controller does not contain conversion logic.

#### Conversion Service

Responsible for:

* Coordinating the conversion workflow
* Validating category compatibility
* Delegating conversion to the appropriate converter

#### Unit Registry

Acts as the central source of truth for all supported units.

Each unit definition contains:

* Name
* Symbol
* Category
* Conversion factor

#### Converters

Each converter contains category-specific conversion logic.

Current implementations:

* LinearUnitConverter
* TemperatureConverter

#### Unit Converter Factory

Responsible for selecting the appropriate converter implementation based on the unit category.

---

## API Endpoint

### Convert Units

```http
POST /api/conversion
```

### Request

```json
{
  "value": 100,
  "fromUnit": "cm",
  "toUnit": "m"
}
```

### Response

```json
{
  "originalValue": 100,
  "fromUnit": "cm",
  "toUnit": "m",
  "convertedValue": 1
}
```

---

## Error Handling

The application uses a global exception handler to provide consistent API responses.

Example:

```json
{
  "message": "Unknown unit 'xyz'"
}
```

Examples of handled errors:

* Unknown units
* Incompatible unit categories
* Validation errors

---

## Running Locally

### Prerequisites

* .NET 10 SDK

### Clone Repository

```bash
git clone <repository-url>
```

### Navigate to Solution Root

### Run Application

```bash
dotnet run --project unit-converter
```

The API will be available at:

```text
http://localhost:5158
```

---

## Swagger Documentation

Once the application is running:

```text
http://localhost:5158/swagger
```

Swagger can be used to:

* Explore endpoints
* Execute requests
* Inspect request and response schemas

---

## Running Tests

From the solution root:

```bash
dotnet test
```

---

## Running with Docker

### Build and Run

Navigate to:

```bash
cd unit-converter
```

Then run:

```bash
docker compose up --build
```

The API will be available at:

```text
http://localhost:5158
```

Swagger:

```text
http://localhost:5158/swagger
```

---

## Design Decisions

### Unit Registry

A registry was introduced to centralize unit definitions and avoid scattering unit information throughout the codebase.

Benefits:

* Single source of truth
* Easier maintenance
* Simplified addition of new units

---

### Converter Abstraction

Different categories can require different conversion strategies.

For example:

* Length and weight use linear conversions
* Temperature uses formula-based conversions

The converter abstraction allows each category to encapsulate its own conversion logic.

---

### Factory Pattern

A factory is used to resolve the appropriate converter implementation.

Benefits:

* Removes category-specific logic from the service layer
* Keeps the service focused on orchestration
* Simplifies future extension

---

### Global Exception Handling

Exception handling is centralized using ASP.NET Core middleware.

Benefits:

* Consistent error responses
* Reduced duplication
* Cleaner controller and service code

---

## Trade-offs

### Symbol-Based Lookup

Units are currently identified by their symbol (e.g. `m`, `kg`, `c`).

This keeps the API simple but assumes symbols are globally unique.

If the system expands significantly, a future improvement would be introducing category-aware identifiers to avoid potential symbol collisions.

---

### Factory Updates for New Categories

Adding a new conversion category currently requires:

* Adding the category
* Implementing a converter
* Registering the converter in the factory

This was chosen as a simple and explicit approach for the current scope of the project.

---

## Future Improvements

* Additional unit categories (Volume, Area, Speed, Pressure)
* API versioning
* CI/CD pipeline
* Container registry deployment
* More comprehensive automated tests
* Custom validation attributes for unit symbols
