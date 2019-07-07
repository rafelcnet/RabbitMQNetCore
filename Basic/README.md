Basado en elBasado en el tutorial de RabbitMQ y NetCore:

https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html 

Para no instalar RabbitMQ utilicé mejor un contenedor, y las aplicaciones de consola, Send y Receive, del tutorial.

Para bajar y ejecutar el contenedor de RabbitMQ, así como inicializarlo, indicando usuario y password, usar la siguiente instrucción:

docker run -d --hostname rabbit-local --name rcotest-rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=rcotest -e RABBITMQ_DEFAULT_PASS=Test2019 rabbitmq:3-management

Usando la URL http://localhost:15672 se accede a la consola de administración de RabbitMQ del contenedor, usa el usuario y password indicados


Crear aplicaciones net core:

dotnet new console --name Send

mv Send/Program.cs Send/Send.cs

dotnet new console --name Receive

mv Receive/Program.cs Receive/Receive.cs


Agregar las librerías para RabbitMQ

cd Send

dotnet add package RabbitMQ.Client

dotnet restore

cd ../Receive

dotnet add package RabbitMQ.Client

dotnet restore

Las instrucciones completas y explicación del tutorial vienen en la liga anterior.

Se ejecuta cada aplicación de consola por separado, usando dotnet run o desde Visual Studio, desde la consola web se pueden monitorear los mensajes.
