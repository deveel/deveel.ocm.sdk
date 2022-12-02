// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    public partial class TerminalProvider
    {
        internal static TerminalProvider DeserializeTerminalProvider(JsonElement element)
        {
            string name = default;
            string code = default;
            Optional<IReadOnlyList<ServerTerminalType>> terminalTypes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("terminalTypes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        terminalTypes = null;
                        continue;
                    }
                    List<ServerTerminalType> array = new List<ServerTerminalType>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new ServerTerminalType(item.GetString()));
                    }
                    terminalTypes = array;
                    continue;
                }
            }
            return new TerminalProvider(name, code, Optional.ToList(terminalTypes));
        }
    }
}
