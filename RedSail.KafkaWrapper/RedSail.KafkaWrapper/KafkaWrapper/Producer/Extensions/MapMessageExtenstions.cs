﻿using Confluent.Kafka;
using System.Text.Json;

namespace RedSail.KafkaWrapper.Producer
{
    public static class MapMessageExtensions
    {
        public static Message<string, string> ToJson<TKey, TValue>(this Message<TKey, TValue> message)
        {
            return new Message<string, string>
            {
                Headers = message.Headers,
                Key = JsonSerializer.Serialize(message.Key),
                Timestamp = message.Timestamp,
                Value = JsonSerializer.Serialize(message.Value),
            };
        }

        public static Message<Null, string> ToJson<TValue>(this Message<Null, TValue> message)
        {
            return new Message<Null, string>
            {
                Headers = message.Headers,
                Timestamp = message.Timestamp,
                Value = JsonSerializer.Serialize(message.Value),
            };
        }
    }
}
