# CRUD - Super héroes

### Presentacion

Me presento soy Kevin Adriel Choinet, actualmente cursando para Laboratorio II y este es el segundo parcial a partir de todos los conocimientos ya vistos a lo largo del cuatrimestre tratando de mejorar lo propuesto por el primer parcial.

### Resumen

A partir de la actualizacion desde la version anterior, el programa ahora cuenta con uso de conexion a base de datos, ligera mejora en fluidez al utilizar programacion multihilo y algunas mejoras adicionales para la mejor interaccion posible de parte del usuario.

Esta aplicación proporciona al usuario la gestion de una lista de super heroes conectada en paralelo a una base de datos. 

**Todos los datos que sean modificados se actualizaran de forma inmediata en su respectiva tabla.**

Dependiendo del perfil de usuario, la aplicacion permite agregar, modificar y eliminar heroes a los cuales se les proporciona su propia descripcion basada en los atributos que sean ingresados.

Es posible guardar y cargar una lista ya hecha como tambien eliminarla por completo y empezar desde cero.

### Funcionamiento del programa

#### Login

El programa cuenta con un login basado en los datos de usuario previamente proveidos y los cuales se encuentran en la misma carpeta que el proyecto.
Las opciones de creaciones de perfil, modificacion de correo y contraseña no se encuentran activadas por el momento.

![login](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/login.gif)

#### Agregar

Al agregar un nuevo heroe se le va a permitir al usuario ingresar todos los datos de este mismo para luego ser reflejados en la lista.
![main1](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/main1.gif)
![main2](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/main2.gif)

#### Modificar

Al momento de modificar un heroe se abrira una ventana parecida a la de agregar pero solo permitiendo cambiar datos basicos como el nombre, poder y nivel de poder base.
![main3](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/main3.gif)

#### Eliminar

La aplicacion cuenta con una eliminacion inmediata del heroe seleccionado la cual se ve reflejada tanto graficamente como en la base de datos.
![main3](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/main4.gif)

#### Otros

Entre otras cosas, el programa permite ordenamiento de la lista, guardado y carga de heroes en forma de .json como tambien la eliminacion completa de todos los heroes presentes en la coleccion.

### Diagrama de clases

#### (Abrir imagen y hacer zoom para mayor resolucion)

![Diagrama entidades](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/DiagramaEntidades.png)
![Diagrama form](https://github.com/KevvCho/Choinet.Kevin.SegundoParcial/blob/master/ResourcesImg/DiagramaLogin.png)



