# LibrarySystem

A library management system built with C#, Entity Framework Core, and Blazor.

## How to Run

1. Clone the repository
2. Open `LibrarySystem.sln` in Visual Studio
3. Set `LibrarySystem.Web` as startup project
4. Run the project with F5 or `dotnet run`
5. Open browser at `https://localhost:5037`

## Projects

- **LibrarySystem** - Core project with models, services and repositories
- **LibrarySystem.Web** - Blazor web application
- **LibrarySystemTests** - Unit tests

## Database Model

SQLite database with 3 tables:

### Books
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key |
| Title | string | Book title |
| ISBN | string | ISBN number |
| Author | string | Author name |
| PublishedYear | int | Year published |
| IsAvailable | bool | Available for loan |

### Members
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key |
| MemberId | string | Member ID (e.g. M001) |
| Name | string | Member name |
| Email | string | Email address |
| MemberSince | DateTime | Registration date |

### Loans
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key |
| BookId | int | Foreign key to Books |
| MemberId | int | Foreign key to Members |
| LoanDate | DateTime | Date borrowed |
| DueDate | DateTime | Due date |
| ReturnDate | DateTime? | Date returned (null if active) |

## Relationships

- One Book can have many Loans
- One Member can have many Loans

## Tests

30 unit tests covering:
- Book model (Matches, GetInfo)
- Loan model (IsOverdue, IsReturned)
- Library statistics
- Repository operations with Moq