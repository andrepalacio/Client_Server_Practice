using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

var hostName = Dns.GetHostName();
IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
IPAddress ipAddress = ipHostInfo.AddressList[0];
Console.WriteLine($"Servidor en {ipAddress.ToString()}");
IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11000);

using Socket server = new (ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

server.Bind(ipEndPoint);
server.Listen();

var handler = await server.AcceptAsync();
while (true)
{
  var buffer = new byte[1024];
  var byteReceived = await handler.ReceiveAsync(buffer, SocketFlags.None);
  var message = Encoding.UTF8.GetString(buffer, 0, byteReceived);

  var eom = "<|EOM|>";
  if (message.Contains(eom))
  {
    Console.WriteLine($"Mensaje recibido: {message.Replace(eom, "")}");

    var response = Encoding.UTF8.GetBytes("<|ACK|>");
    await handler.SendAsync(response, SocketFlags.None);
    Console.WriteLine($"Servidor envía acuse de recibido");
    break;
  }
  
}