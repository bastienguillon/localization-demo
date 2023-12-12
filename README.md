# Localization demo

## Database schema

### Tables

```mermaid
erDiagram
    Products {
        int Id PK
        number UsdPrice
        text Category
    }

    ProductTranslations {
        int ProductId PK,FK
        text Culturecode PK
        bit IsDefault
        text Name
        text Description 
    }

    Products ||--o{ ProductTranslations : "Has one or more"
```

### Views

```mermaid
erDiagram
    AvailableCultures {
        text CultureCode
    }
    LocalizedProducts {
        int Id
        text Culturecode
        number UsdPrice
        text Category
        text Name
        text Description
    }
```
