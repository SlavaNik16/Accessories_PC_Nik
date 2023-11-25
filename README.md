# Accessories_PC_Nik
Продажа комплектующих пк, а также их услуги

## Схема базы данных
```mermaid
erDiagram

    Persons {
        Guid Id
        string LastName
        string FirstName
        string Patronymic
        string Email
        string Phone
        Guid GroupId
    }
    
    Documents {
        Guid Id
        int Number
        int Series
        DateTime IssuedAt
        string IssuedBy
        Enum DocumentType
        Guid PersonId
    }
    
    Disciplines {
        Guid Id
        string Name
        string Description
    }
    
    Employees {
        Guid Id
        Enum EmployeeType
        int PersonId
    }

    Groups {
        Guid Id
        string Name
        string Description
        Guid EmployeeId
    }

     TimeTableItem {
        Guid Id
        DateTimeOffset StartDate
        DateTimeOffset EndDate
        Guid DisciplineId
        Guid GroupId
        int RoomNumber
        Guid TeacherId
    }
    Persons ||--o{ Documents: is
    Persons ||--o{ Employees: is
    Groups ||--o{ Persons: is
    Employees ||--o{ Groups: is
    Disciplines ||--o{ TimeTableItem: is
    Groups ||--o{ TimeTableItem: is
    Employees ||--o{ TimeTableItem: is

  BaseAuditEntity {
        Guid ID
        DateTimeOffset CreatedAt
        string CreatedBy
        DateTimeOffset UpdatedAt
        string UpdatedBy
        DateTimeOffset DeleteddAt
  }
   AccessKey {
        Guid Key
        Enum Types
   }
    Client {
        string Surname
        string Name
        string? Patronymic
        string Phone
        string Email
        decimal Balance
    }
    Component {
        Enum TypeComponents
        string? Description
        Enum MaterialType
        decimal Price
        int Count
    }
     Delivery  {
        DateTimeOffset From
        DateTimeOffset To
        decimal Price
    }
   
```
