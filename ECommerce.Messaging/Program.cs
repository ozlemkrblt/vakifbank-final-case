
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://fnbyfelm:ev4qC9VQuazUUOxAMRM8t9BxsMXxYqXQ@chimpanzee.rmq.cloudamqp.com/fnbyfelm");
using var connection  = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("messageQueue",true,false,false);
var message = "Try message";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(String.Empty, "messageQueue", null, body);

Console.WriteLine();    
Console.ReadLine();

