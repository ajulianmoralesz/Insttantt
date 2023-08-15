
# Insttantt Prueba Tecnica

Portafolio de apis creadas para la creación y ejecución de flujos dinámicos.




## Authors

- [@ajulianmoralesz/](https://github.com/ajulianmoralesz)


## Tecnologias

* net6
* Sql Server

## Arquitectura y Patrones de diseño

* Clean
* CQRS
* Mediator

## Paradigmas y Conceptos 

* Repositorio Unico
* Separación de responsabilidades
* Paralelismo

## Librerias Externas Utilizadas

* FluentValidations
* Mediatr
* Automapper

## Modelo Entidad Relacion

![ER](https://github.com/ajulianmoralesz/Insttantt/blob/main/Documentation/relationalModel.png?raw=true)

## Modelo de Arquitectura

![ARQ](https://github.com/ajulianmoralesz/Insttantt/blob/main/Documentation/Architecture.png?raw=true)




## Instalación

* Clonar el repositorio
* Compilar el proyecto


* Si se requiere cargar las migraciones con sus respectivos seeder ejecutar el siguiente comando en la consola del package manager.

```bash
  Update-Database -Verbose -Project Insttantt.DataAccess -StartupProject Insttantt.Api
```
    