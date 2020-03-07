# netcorefacturas

# 1. Event Storming 
Problema 1: Facturación y Pagos
El problema consiste en diseñar y programar un pequeño módulo de facturación que contemple la creación de una factura con ítems dentro de la factura; adicionalmente se debe contemplar el pago de la factura. Se debe pensar que los ítems o artículos posibles de la factura se encuentran ya definidos. En el diseño inicial en las primeras clases se debe definir los estados posibles y las formas de pago posibles.


# 2. Herramientas Requeridas
Visual Studio 2019
GitHub(url)
Sql Server
PostMan(download)

# 3. Repositorio GitHub del Proyecto
El repositorio del Proyecto se encuentra en la siguiente dirección:
Repositorio de Tarea 2:
https://github.com/jbaguilarr/netcore_facturas_project
Repositorio de Tarea 3:
https://github.com/everth333/netcore_facturas_project


# 4. Script de Base de Datos
El Script de la Base de Datos en SQL Server se encuentra en la siguiente dirección:
https://docs.google.com/spreadsheets/d/1zgbm3gQ55Bowc2ua6PvlDXGoO5BvtgFsvLJ-s4Tfp2Y/edit?usp=sharing

# 5. Aplicación del Proyecto
Implementación de las Clases Entidades.
Implementación de Repository en todas las Entidades.
Implementación de Value Object en Clase Cliente con su Dirección.
Implementación de los Controllers-API.

# 6. Descripción Técnica de APIs
# Obtener Listado de Clientes desde Postman:
Método HTTP: GET
URL: http://localhost:63320/api/clientes
Autorización: No Auth
Headers: No
Body: None

Desde el Browser: http://localhost:63320/api/clientes

# Obtener Datos de un Cliente desde Postman:
Método HTTP: GET
URL: http://localhost:63320/api/clientes/1
Autorización: No Auth
Headers: No
Body: None

Desde el Browser: http://localhost:63320/api/clientes/1

# Insertar Datos de un Cliente desde Postman:
Método HTTP: POST
URL: http://localhost:63320/api/Clientes
Autorización: No Auth
Headers: Key:”Content-Type”    Value:  "application/json" 
Body: RAW : {		
	"Nombre": "Juan Carlos",	
	"Apellidos" : "Aguirre Rojas",	
	"FechaNaciemiento" : "1995/01/25",	
	"Email" : "juancarlos@gmail.com",	
	"Telefono" : "75415252",	
	"Direccion": {
		Barrio: "San jose",
		Calle: "More",
		Numero: 2125
		},
	"DateCreated": "2020/02/28",	
	"Dateupdated": "2020/02/28"	
}

# Modificar Datos de un Cliente desde Postman:
Método HTTP: PUT
URL: http://localhost:63320/api/Clientes
Autorización: No Auth
Headers: Key:”Content-Type”    Value:  "application/json" 
Body: RAW : {		
	"Id": 5,
	"Nombre": "Juan Carlitos",	
	"Apellidos" : "Aguirre Martinez",	
	"FechaNaciemiento" : "1995/01/25",	
	"Email" : "juancarlitos@gmail.com",	
	"Telefono" : "75415252",	
	"Direccion": {
		Barrio: "San jose 2",
		Calle: "More",
		Numero: 2125
		},
	"DateCreated": "2020/02/28",	
	"Dateupdated": "2020/02/28"	
}

# Eliminar los Datos de un Cliente desde Postman:
Método HTTP: DELETE
URL: http://localhost:63320/api/Clientes/5
Autorización: No Auth
Headers: No
Body: None

# 7. Listados usando APIs en Browser
Listado de Clientes: http://localhost:63320/api/Clientes
Listado de Productos: http://localhost:63320/api/Productos
Listado de Facturas: http://localhost:63320/api/Facturas
Listado de Detalle Facturas: http://localhost:63320/api/Detalles

# 8. Aplicación del Proyecto con Clean Architecture
# Estructura del Proyecto:

Implementación de la Carpeta Domain.
Entities
ValueObject

Implementación de la Carpeta Framework.
Interfaces

Implementación de la Carpeta Infraestructure.
Commands
Por cada Entidad
Comunication
Persistence
Configuration
Repositories
DBContext
UnitOfWork
Queries
Por cada Entidad

Implementación de la Carpeta WebAPI.
Controllers
Resources
Controllers en PLURAL (Clientes, Facturas, Productos y Detalles)
Migrations

# 9. URL de APIs con Clean Architecture

# CLIENTES:
http://localhost:63320/api/clientes
http://localhost:63320/api/clientes/1
# PRODUCTOS:
http://localhost:63320/api/productos
http://localhost:63320/api/productos/1
# FACTURAS:
http://localhost:63320/api/facturas
http://localhost:63320/api/facturas/1
# DETALLES:
http://localhost:63320/api/detalles
http://localhost:63320/api/detalles/1






