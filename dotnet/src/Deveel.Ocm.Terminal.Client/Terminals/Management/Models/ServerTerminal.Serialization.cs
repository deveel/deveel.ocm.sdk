// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    public partial class ServerTerminal
    {
        internal static ServerTerminal DeserializeServerTerminal(JsonElement element)
        {
            ServerTerminalType type = default;
            string address = default;
            TerminalStatus status = default;
            Optional<DateTimeOffset> lastChanged = default;
            TerminalSource source = default;
            TerminalRoles role = default;
            Optional<string> sourceId = default;
            Optional<IReadOnlyDictionary<string, object>> settings = default;
            Optional<IReadOnlyDictionary<string, object>> context = default;
            string provider = default;
            Optional<string> id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = new ServerTerminalType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("address"))
                {
                    address = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = new TerminalStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("lastChanged"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    lastChanged = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("source"))
                {
                    source = new TerminalSource(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("role"))
                {
                    role = new TerminalRoles(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        sourceId = null;
                        continue;
                    }
                    sourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("settings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        settings = null;
                        continue;
                    }
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetObject());
                    }
                    settings = dictionary;
                    continue;
                }
                if (property.NameEquals("context"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        context = null;
                        continue;
                    }
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetObject());
                    }
                    context = dictionary;
                    continue;
                }
                if (property.NameEquals("provider"))
                {
                    provider = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        id = null;
                        continue;
                    }
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new ServerTerminal(type, address, status, Optional.ToNullable(lastChanged), source, role, sourceId.Value, Optional.ToDictionary(settings), Optional.ToDictionary(context), provider, id.Value);
        }
    }
}
