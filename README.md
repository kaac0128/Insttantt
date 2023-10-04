# Insttantt

Atravez de las api por medio de swagger se controla la creacion y administracion de flujos con sus campos y pasos de una forma
dinamica que permita al usuario crear el flujo de la forma que desee 

## Configuracion del Entorno

-[] .Net SDK y ASP .Net Core
-[] MongoDB
-[] SQLServer

1. Para iniciar la app completa se debe iniciar con el proyecto de Insttant.Api que se encuentra dentro de la carpeta src.
2. Si deseas realizar las pruebas unitarias se debe ejecutar el proyecto Insttant.Test que se encuentra dentro de la carpeta src. 
3. En la parte de SQLServer se guardan todos los datos que ver con la app en general como el flujo, los pasos y campos en la base de datos InsttanttFlow.
4. En la parte de MongoDB se guardan todos los logs generados por la aplicacion en la base de datos LogsInsttant en la collecion log.
5. No es necesario generar las bases de datos ya que al iniciar el proyecto este las crea con todas sus migraciones y al ejecutar cualquier api se genera la base de mongo.

## Visualizar app

En el puerto que este corriendo la app se debe agregar a la url /swagger/index.html en caso tal de que no se muestre automaticamente
para la visualizacion y pruebas de las apis.

## Repositorio

Para acceder al repositorio puede dirigirse a la url https://github.com/kaac0128/insttantt