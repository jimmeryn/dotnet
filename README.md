# Work time tracker

App written in C#.Net with WPF using Oracle database. Providing my implementation of basic work time tracker used in most companies.

## Setup

### Clone the repo

```sh
git clone https://github.com/jimmeryn/dotnet.git
```

### Go to the repo

```sh
cd dotnet
```

## Development

### Dependencies and tools

Make sure you've installed dotnet and that you have Oracle Explorer connected to your Oracle database.

### Connect to database

Create file connection.txt with the following content:

```sh
DATABASE ID
DATABASE PASSWORD
HOST eg. localhost
PORT eg. 1521
SERVICE_NAME eg. xe
```

### Run application

```sh
dotnet run
```

### Adding migrations

ORM created with EntityFrameworkCore.
Create new migration:

```sh
dotnet ef migrations add <migration_name>
```

Apply it to database:

```sh
dotnet ef database update
```

### Unit tests

Unit tests were created with xUnit.
To run unit tests:

```sh
dotnet test
```

### Documentation

Documentation written in XML was generated with Docfx.
To see generated documentation navigate to

```sh
doc/\_site/doc/api/toc.html
```
