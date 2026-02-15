# Library System

A console-based library management system.

## Run
```bash
dotnet run --project LibrarySystem
```

## Test
```bash
dotnet test
```

## Features

- Manage books, members, and loans
- Search and sort books
- View statistics

## Design

- Composition: Library uses BookCatalog, MemberRegistry, LoanManager
- Interface: ISearchable for search functionality