# PRUEBA TÉCNICA 

El proyecto fue generado con el template _ASPNET Core Web API_ ya que no necesitamos vistas. 

## Conexión a base de datos

Se creo la clase _ApplicationContext_ que hereda de la clase DbContext, asi se obtienen los métodos para el manejo de la información en la base de datos.  

## Migracion y Data Seed

Para crear una migración se ejecuta el comando:  

```console
Add-Migration CrearMarcaTable # Package Manager Console
Update-Database
``` 

Y para el Data Seeding se utilizó el método: _Model managed data_ ya que no se necesitaba ingresar información estructurada compleja.  
Se ingresaron 3 tipos de MarcaAuto con un Id y con el Name.

## API-REST

Se creo el controlador _MarcasAutosController_ el cual tiene un solo método _GET_ que devuelve todas las amrcas que se encuentren en la tabla.  
El controlador responde a la ruta /marcasautos/all.

## Pruebas Unitarias

Se creo un nuevo proyecto _TestProject_ el cual es parte del proyecto inicial _PruebaTecnicaInicial_. Se agrego la referencia del proyecto  
inicial para poder manejar los controladores y modelos ya creados.  

Las pruebas realizadas fueron:  
    - GetOk: Que el objeto de respuesta sea de tipo OkObjectResult  
    - GetEmpty: Cuando no existen marcas, el resultado debe ser una lista vacia  
    - GetNotEmpty: Cuando existe información en base, todos las filas deben ser devueltas  

## Docker Compose

Se genero el archivo _docker-compose.yml_ para levantar los servicios de _webservice_ y _postgresdb_. El servicio _webservice_ depende de _postgresdb_ para iniciar ya que se debe aplicar la migración una vez ya creada la base.  
Para levantar el proyecto se dede seguir lo siguiente:

- Entrar a la carpeta root del proyecto PruebaTecnicaInicial/
- Ejecutar el comando:
```console
 docker-compose up -d
```
 - Para revisar que los servicios se hayan levantado de forma correcta:
```console
 docker logs <nombre-contenedor>
```

## Pruebas postman

Para realizar pruebas en postman, se debe realizar una petición tipo GET a la ruta: http://localhost:8080/marcasautos/all

