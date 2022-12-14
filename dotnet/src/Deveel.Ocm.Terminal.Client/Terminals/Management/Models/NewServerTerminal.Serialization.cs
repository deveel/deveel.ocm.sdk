// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    public partial class NewServerTerminal : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Settings))
            {
                if (Settings != null)
                {
                    writer.WritePropertyName("settings");
                    writer.WriteStartObject();
                    foreach (var item in Settings)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteObjectValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("settings");
                }
            }
            if (Optional.IsCollectionDefined(Context))
            {
                if (Context != null)
                {
                    writer.WritePropertyName("context");
                    writer.WriteStartObject();
                    foreach (var item in Context)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteObjectValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("context");
                }
            }
            writer.WritePropertyName("provider");
            writer.WriteStringValue(Provider);
            writer.WritePropertyName("role");
            writer.WriteStringValue(Role.ToString());
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("address");
            writer.WriteStringValue(Address);
            writer.WriteEndObject();
        }
    }
}
