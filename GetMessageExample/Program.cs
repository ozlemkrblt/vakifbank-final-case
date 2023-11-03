//ayrı bir projede, mesajı yakalayabiliriz :)
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://fnbyfelm:ev4qC9VQuazUUOxAMRM8t9BxsMXxYqXQ@chimpanzee.rmq.cloudamqp.com/fnbyfelm");
using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("messageQueue", true, false, false);

var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("messageQueue", true, consumer);

consumer.Received += Consumer_Received;
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
}