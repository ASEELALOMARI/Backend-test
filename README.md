## Features

- **CRUD operations for Reviews**: Create, Read, Update, Delete
- **Exception handling**: Proper error handling for common issues such as NotFound
- **AutoMapper for DTO mapping**
- **Best practices for endpoint URLs**
- **Validation**: Data Annotation would be applied

## 1. Review Entity

Create an entity called `Review` which includes:
- `Id` (int): Primary key
- `Description` (string): Review description
- `Rating` (int): Rating score (1-5)