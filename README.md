# SimpleMassTransitExample
This application was developed to briefly demonstrate the usage of the MassTransit library.

# How to Use
First, start the RabbitMQ server with the following command.
```
docker run -d --hostname rabbitmq-server -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
Then, to run the producer and consumer applications, use the following commands:
```
dotnet run --project SimpleMassTransitExample.Producer/ 
dotnet run --project SimpleMassTransitExample.Consumer/ 
```
Finally, open ```http://ip_address:port/swagger/index.html``` in your browser. Now, you can send events from the producer to the consumer.
