# Test de Alcoholemia App

Aplicación para digitalizar los procesos de almacenamiento de pruebas en los controles de  alcoholemia, dando soporte a los examinadores.

Es posible utilizar roles para los usuarios, por defecto:

* Administrador
* Administrativo
* Examinador/Base

## Arquitectura

La arquitectura consta de un frontend en Angular, backend en .NET y BBDD en PostreSQL, aunque es posible cambiar el origen de los datos sin afectar a la aplicación.

## Frontend

El frontend en angular esta subdividido en modulos, que son:

* Login: Se encarga de las tareas de login y logout de usuarios, asi como todo lo relacionado al perfil del usuario que inició sesión. para la autenticación se utiliza JWT. 
* Usuario: Encargado de los ABMs de usuarios y sus tipos (roles).
* Equipo: No implementado.
* Prueba: No implementado.
* Reporte: No implementado.


## Diagrama de clases

    La imagen no está actualizada y es a modo de referencia