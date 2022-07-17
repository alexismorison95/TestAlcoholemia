# Test de Alcoholemia App

Aplicación para digitalizar los procesos de almacenamiento de pruebas en los controles de  alcoholemia, dando soporte a los examinadores.

Es posible utilizar roles para los usuarios, por defecto:

* Administrador
* Administrativo
* Examinador/Base


## Arquitectura

La arquitectura consta de un frontend en Angular, backend en .NET y BBDD en PostreSQL, aunque es posible cambiar el origen de los datos sin afectar a la aplicación.

![diagrama](https://github.com/alexismorison95/TestAlcoholemia/blob/main/img/architecture_diagram.png?raw=true)


## Frontend

El frontend en angular esta subdividido en modulos, que son:

* Login: Se encarga de las tareas de login y logout de usuarios, asi como todo lo relacionado al perfil del usuario que inició sesión. para la autenticación se utiliza JWT. 
* Usuario: Encargado de los ABMs de usuarios y sus tipos (roles).
* Equipo: No implementado.
* Prueba: No implementado.
* Reporte: No implementado.


## Backend

La API en .NET 6 utiliza arquitectura limpia y las mejores practicas de desarrollo, para hacer más facil el agregar funcionabilidad y hacer éste backend independiente del fronted y la bbdd.

Las capas son las siguientes:

* API: Donde se ejecuta la app y se encuentran los controladores.
* Application: Donde se encuentran los servicios y los DTOs.
* Core: En esta capa se pueden encontrar las entidades y las interfaces para los repositorios.
* Infraestructure: Esta capa posee el contexto de la bbdd y los repositorios que implementan la lógica para realizar las operaciones necesarias.


## Base de datos

La BBDD actual es en PostgreSQL, pero se podría implementar con cualquier otra base de datos relacional, como por ejemplo SQL Server.

![diagrama](https://github.com/alexismorison95/TestAlcoholemia/blob/main/img/class_diagram.jpg?raw=true)

    La imagen no está actualizada y es a modo de referencia