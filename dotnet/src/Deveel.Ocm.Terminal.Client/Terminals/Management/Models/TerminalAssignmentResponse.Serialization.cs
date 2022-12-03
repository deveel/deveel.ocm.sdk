// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    public partial class TerminalAssignmentResponse
    {
        internal static TerminalAssignmentResponse DeserializeTerminalAssignmentResponse(JsonElement element)
        {
            string responder = default;
            ResourceAssignmentResponseType responseType = default;
            DateTimeOffset timeStamp = default;
            Optional<string> notes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("responder"))
                {
                    responder = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("responseType"))
                {
                    responseType = new ResourceAssignmentResponseType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("timeStamp"))
                {
                    timeStamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("notes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        notes = null;
                        continue;
                    }
                    notes = property.Value.GetString();
                    continue;
                }
            }
            return new TerminalAssignmentResponse(responder, responseType, timeStamp, notes.Value);
        }
    }
}