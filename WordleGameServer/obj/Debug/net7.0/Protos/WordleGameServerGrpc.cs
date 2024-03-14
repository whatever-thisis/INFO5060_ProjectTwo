// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/WordleGameServer.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace WordleGameServer {
  /// <summary>
  /// Definition of the gRPC service for WordleGameServer.
  /// </summary>
  public static partial class WordleGameServer
  {
    static readonly string __ServiceName = "WordleGameServer";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WordleGameServer.GuessRequest> __Marshaller_GuessRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WordleGameServer.GuessRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WordleGameServer.GuessResponse> __Marshaller_GuessResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WordleGameServer.GuessResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WordleGameServer.Empty> __Marshaller_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WordleGameServer.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WordleGameServer.StatsResponse> __Marshaller_StatsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WordleGameServer.StatsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WordleGameServer.GuessRequest, global::WordleGameServer.GuessResponse> __Method_Play = new grpc::Method<global::WordleGameServer.GuessRequest, global::WordleGameServer.GuessResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Play",
        __Marshaller_GuessRequest,
        __Marshaller_GuessResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WordleGameServer.Empty, global::WordleGameServer.StatsResponse> __Method_GetStats = new grpc::Method<global::WordleGameServer.Empty, global::WordleGameServer.StatsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetStats",
        __Marshaller_Empty,
        __Marshaller_StatsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::WordleGameServer.WordleGameServerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of WordleGameServer</summary>
    [grpc::BindServiceMethod(typeof(WordleGameServer), "BindService")]
    public abstract partial class WordleGameServerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task Play(grpc::IAsyncStreamReader<global::WordleGameServer.GuessRequest> requestStream, grpc::IServerStreamWriter<global::WordleGameServer.GuessResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::WordleGameServer.StatsResponse> GetStats(global::WordleGameServer.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(WordleGameServerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Play, serviceImpl.Play)
          .AddMethod(__Method_GetStats, serviceImpl.GetStats).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WordleGameServerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Play, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::WordleGameServer.GuessRequest, global::WordleGameServer.GuessResponse>(serviceImpl.Play));
      serviceBinder.AddMethod(__Method_GetStats, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::WordleGameServer.Empty, global::WordleGameServer.StatsResponse>(serviceImpl.GetStats));
    }

  }
}
#endregion