using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdEventsWiped
  {

  
  public static IAsyncSubscription Subscribe(
    LoggingInterface logger,
IEncodedConnection connection,
V0RustServersServerIdEventsWipedOnRequest onRequest,
String server_id
  )
  {
    EventHandler<EncodedMessageEventArgs> handler = (sender, args) =>
    {
      logger.Debug("Got message for channel subscription: " + $"v0.rust.servers.{server_id}.events.wiped");
      var deserializedMessage = JsonDeserializerSupport(logger, (byte[])args.ReceivedObject);

      var unmodifiedChannel = "v0.rust.servers.{server_id}.events.wiped";
  var channel = args.Subject;
  var serverIdSplit = unmodifiedChannel.Split(new string[] { "{server_id}" }, StringSplitOptions.None);
  String[] splits = {
    serverIdSplit[0],
serverIdSplit[1]
  };
  channel = channel.Substring(splits[0].Length);
var serverIdEnd = channel.IndexOf(splits[1]);
var serverIdParam = $"{channel.Substring(0, serverIdEnd)}";
      
      onRequest(null,
serverIdParam);
    };
    logger.Debug("Subscribing to: " + $"v0.rust.servers.{server_id}.events.wiped");
    return connection.SubscribeAsync($"v0.rust.servers.{server_id}.events.wiped",handler);
  }

  }
}