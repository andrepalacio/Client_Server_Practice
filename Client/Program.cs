using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

var hostName = Dns.GetHostName();
IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
IPAddress ipAddress = ipHostInfo.AddressList[0];
IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11000);

using Socket client = new (ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

await client.ConnectAsync(ipEndPoint);
while (true)
{
  Console.WriteLine("Ingrese un mensaje: ");
  var message = Console.ReadLine();
  var byteMessage = Encoding.UTF8.GetBytes(message+"<|EOM|>");
  await client.SendAsync(byteMessage, SocketFlags.None);

  var buffer = new byte[1024];
  var byteReceived = await client.ReceiveAsync(buffer, SocketFlags.None);
  var response = Encoding.UTF8.GetString(buffer, 0, byteReceived);
  if (response == "<|ACK|>") {
    Console.WriteLine($"Mensaje enviado correctamente {response}");
    break;
  }
}

client.Shutdown(SocketShutdown.Both);