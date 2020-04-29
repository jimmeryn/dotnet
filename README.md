# Work time tracker

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

Make sure you've installed dotnet and that you have Oracle Explorer connected to your database.

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

Create new migration:

```sh
dotnet ef migrations add <migratin_name>
```

Apply it to database:

```sh
dotnet ef database update
```

### Run unitests

```sh
dotnet test
```
