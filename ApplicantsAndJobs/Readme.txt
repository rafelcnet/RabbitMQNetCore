contenedores debuggeables con VSTudio Code
ms-sql server linux
docker compose y multicontainer
redis para caching
MassTransit como message bus que trabaja con rabbitmq
kitematic


dotnet new sln ApplicantsAndJobs
md Services
add web api for Applicants, Jobs, IDentity
add dockerfile.debug
md Database
add dockerfile

lo migre a netcore 2.2
ya tenia el rabbitmq del ejemplo basic, no lo inclui en el yml
cambie las conexiones a rabbit
######no inclui el mvc en contenedor ni en el yaml
la referencia a redis viene mal., no se incluye

docker-compose up -d

conectar con la ip del contenedor:
 docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}'  rcotest-rabbitmq
la segunda 172.19.0.5 172.17.0.2


docker network create -d bridge my_bridge


connect both app and rabbitmq containers to same network 
   docker network connect my_bridge <container name>

