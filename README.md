# SimpleMassTransitExample
This application was developed to show usage of MassTransit library brefily.

# How to Use
First, run the RabbitMQ with following command.
```
docker run -d --hostname rabbitmq-server -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
Then, run the producer and consumer applications with following commands.
```
dotnet run --project SimpleMassTransitExample.Producer/ 
dotnet run --project SimpleMassTransitExample.Consumer/ 
```
Finallay, open ```http://ip_address:port/swagger/index.html``` from browser.
Now, you can send events from producer to consumer.



