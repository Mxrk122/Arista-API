
# Arista prueba técnica API

Este repositorio contiena la parte 2 del ejercicio.

## ¿Cómo desplegar?
1. Clonar el repositorio 

## Depliegue

1. Clonar el repositorio
2. Ejecutar:

```bash
  dotnet watch run
```
(watch permite actualizar al detectar cambios en el código)


## Información de desarrollo

Utilicé el modelo incluido en una  web api creada por defecto con .Net. Al ejecutarse se puede acceder a swagger con información de las rutas disponibles. La de su interés es la ruta:
```bash
  
localhost:5183/api/miinfo/mi-info

```

La cual recibe el body generado en el ejercicio 1, añade la latitud y longitud y finalmente devuelve una respuesta con estos campos al usuario que está utilizando el ejercicio 1.

En el código se encuentran comentarios sobre el funcionamiento. Pero podría resumirlo en que: 
1. Se desarrolló un controlador para miinfo.
2. Se declaró un modelo Cliente incluyendo latitud y longitud
3. El controlador para miinfo envía una instancia dle modelo Cliente en respuesta a la petición POST.