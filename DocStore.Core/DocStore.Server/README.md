﻿# Instructions to install the server

### Install postgres

- Open PostgresDockerCompose
- Customize ports and passwords using the docker-compose file
- docker-compose up -d

### Using PGAdmin create app user and database

For demo purpose, this code example will use the following parameters

- database: app_db
- application user: app_user
- password: password123$

Make sure to change these passwords for your production environments.

### Configure application server

- Open DocStore.Core/DocStore.Server/appsettings.json
- You will need to configure the connection string for the application database and password.

### Run the server

- Open terminal at DocStore.Core/DocStore.Server/
- Execute the following
    - dotnet build
    - dotnet run



