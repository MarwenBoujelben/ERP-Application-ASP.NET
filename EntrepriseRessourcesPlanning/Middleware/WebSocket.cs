using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;

public class WebSocketManager
{
    private static List<IWebSocketConnection> _clients = new List<IWebSocketConnection>();

    public static void StartServer(string serverUrl)
    {
        var server = new WebSocketServer(serverUrl);

        server.Start(socket =>
        {
            socket.OnOpen = () =>
            {
                _clients.Add(socket);
            };

            socket.OnClose = () =>
            {
                _clients.Remove(socket);
            };
        });
    }

    public static void BroadcastNotification(string notification)
    {
        foreach (var client in _clients.ToList())
        {
            if (client.IsAvailable)
            {
                client.Send(notification);
            }
            else
            {
                _clients.Remove(client);
            }
        }
    }
}
