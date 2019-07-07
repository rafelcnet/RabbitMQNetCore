## Introduccion

Este ejemplo me pareció muy completo, lo elegí como segunda opción porque contiene los siguientes elementos:

* Contenedores debuggeables con VSTudio Code

* Utiliza ms-sql server en linux

* Incluye docker compose y multicontainer

* Utiliza Redis para caching y MassTransit como message bus que trabaja con rabbitmq

* Usa kitematic para poder administrar los contenedores desde la PC

## Autor

El ejemplo se basa en el siguiente blog:

https://fullstackmark.com/post/12/get-started-building-microservices-with-asp.net-core-and-docker-in-visual-studio-code 

## Uso

Tuve que realizar unos ajustes:

Utilicé  Netcore 2.2

Ya tenía el rabbitmq del ejemplo basic, no lo incluí en el yml y tuve que cambiar las conexiones a rabbit (usuario y password, y el host)

La referencia a redis viene mal, no la incluye en el repo del autor, así que la incluí donde fuera necesario

Para conectar con la ip del contenedor de RabbitMQ usé el comando:

docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}'  rcotest-rabbitmq

la segunda IP es la que se utiliza:  172.19.0.5 172.17.0.2

Ejecutando docker compose se pueden observar los contenedores ejecutándose:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq2.PNG)

Desde VisualStudio Code se puede iniciar la aplicacion y debuggear en los contenedores, hay que copiar los archivos launch.json y tasks.json (yo los adecue de acuerdo a mi proyecto) en el folder .vscode de la solución, en el repo ya se encuentran.

Una vez iniciando todas las aplicaciones en modo debug con VStudio Code, en la Consola de RabbitMQ se pueden observar las conexiones:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq1.PNG)

Con MS-SQLServer Management Studio es posible conectarse al contenedor de la BD y ejecutar queries, aquí la tabla Jobs:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq3.PNG)

La aplicaicón Web se ve así:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq4.PNG)

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq5.PNG)

Después de aplicar a un puesto la tabla correspondiente se actualiza:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq7.PNG)

Así se ven los mensajes cuando llegan a RabbitMQ:

![alt text](https://raw.githubusercontent.com/rafelcnet/RabbitMQNetCore/master/ApplicantsAndJobs/images/mq8.PNG)

Desafortunadamente no termina la ejecución correctamente, no se realiza la verificación de la aplicación y la página web presenta un error.

## Estatus 

Sigo revisando esa parte, otro problema que me he encontrado es que no siempre las API´s se conectan al contenedor de RabbitMQ, debo insisitr varias veces.

Actualizaré este archivo cuando resuelva los errores.


