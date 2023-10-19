# PROYECTO NOTI-APP
Mi aplicación de notificaciones para universidades es una herramienta diseñada para mejorar la comunicación y la interacción en entornos académicos. Con esta aplicación, he creado una forma efectiva de mantener a estudiantes, profesores y personal administrativo informados sobre eventos, plazos, cambios en horarios y cualquier información relevante. Puedes personalizar tus preferencias de notificación para recibir solo la información que necesitas. Además, la aplicación se integra sin problemas con los sistemas existentes de la universidad, proporcionando acceso a información en tiempo real. Mi objetivo al desarrollar esta aplicación es facilitar la vida académica y asegurarme de que todos estén al tanto de lo que está sucediendo en el campus.

# INSTRUCCIONES PARA EL BUEN FUNCIONAMIENTO

Lo primero que debes hacer luego de clonar el repo es en la consola poner el comando "dotnet restore", para eliminar los errores que apareceran.

## FUNCIONALIDAD DE LOS DTOS
### Auditoria:
`{
    "NombreUsuario" : "String",
    "DesAccion" : Int
}`

----------------------------------------------------------------
### Blockchain:
Necesitas tener elementos creados de:
1. Auditoria
2. Hilo Respuesta
3. Tipo Notificacion

`{
    "HashGenerado" : "String",
    "IdAuditoriaFk" : Int(IdAuditoria),
    "IdHiloRespuestaFk" : Int(IdHiloRespuesta),
    "IdNotificacionFk" : Int(IdNotificacion)
}`

----------------------------------------------------------------
### Estado Notificacion:
`{
    "NombreEstado" : "String"
}`

----------------------------------------------------------------
### Formato:
`{
    "NombreFormato" : "String"
}`

----------------------------------------------------------------
### Hilo Respuesta:
`{
    "NombreTipo" : "String"
}`

----------------------------------------------------------------
### Modulo Maestros:
`{
    "NombreModulo" : "String"
}`

----------------------------------------------------------------
### Modulo Notificicaciones:
Necesitas tener elementos creados de:
1. Tipo Notificacion
2. Radicado
3. Estado Notificacion
4. Hilo Respuesta
5. Formato
6. Requerimiento

`{
    "AsuntoNotificacion" : "String",
    "TextoNotificacion" : "String",
    "IdNotificacionFk" : Int(IdNotificacionFk),
    "IdEstadoNotificacionFk" : Int(IdEstadoNotificacionFk),
    "IdHiloRespuestaFk" : Int(IdHiloRespuestaFk),
    "IdFormatoFk" : Int(IdFormatoFk),
    "IdRequerimiento" : Int(IdRequerimiento)
}`

----------------------------------------------------------------
### Permisos Genericos:
`{
    "NombrePermiso" : "String"
}`

----------------------------------------------------------------
### Radicados:
`{
}`

----------------------------------------------------------------
### Rol:
`{
    "Nombre" : "String"
}`

----------------------------------------------------------------
### SubModulo:
`{
    "NombreSubmodulo" : "String"
}`

----------------------------------------------------------------
### Tipo Notificación:
`{
    "NombreTipo" : "String"
}`

----------------------------------------------------------------
### Tipo Requerimiento:
`{
    "Nombre" : "String"
}`

## Nombre de la base de datos:
![Alt text](/images/image.png)

----------------------------------------------------------------

## Reaccion a la base de datos:
- **GET:** 

La petición fue hecha correctamente.

![Alt text](/images/image-1.png)

- **GET ID:** 

El Id no se puede encontrar.

![Alt text](/images/image-2.png)

- **POST:** 

La petición para crear un dato es incorrecta.

![Alt text](/images/image-3.png)

- **PUT:** 

El Id no se puede encontrar.

![Alt text](/images/image-3.png)

- **DELETE:** 

El Id no se puede encontrar.

![Alt text](/images/image-2.png)

----------------------------------------------------------------
### Visualizacion grafica de la base de datos

![Alt text](/images/image-4.png)

----------------------------------------------------------------
### Contribuidores:

Normalización de la base de datos:

* Jholver Pardo
