# FullStack

## Pre-Requisitos

Añadir cadena de conexion a la BD en el archivo appsettings.json (FullStack/RestBackend/RestBackend.Api/appsettings.json)

Es necesario aplicar las migraciones de Entity Framework en BD usando el siguiente comando:
```
dotnet ef --startup-project ./RestBackend.Api/RestBackend.Api.csproj -p ./RestBackend.Data/RestBackend.Data.csproj database update
```
(Requiere Entity Framework Tools) 
```
Mas info: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
```

Tambien para el proyecto Angular se requiere instalar los paquetes de NPM:
```
npm install
```

## Inicializacion

Iniciar FullStack/RestBackend/RestBackend.Api y la app en Angular.

## Data Model
![alt text](https://github.com/edwin0602/fullstack-dale-/blob/main/DataModel.PNG?raw=true)
