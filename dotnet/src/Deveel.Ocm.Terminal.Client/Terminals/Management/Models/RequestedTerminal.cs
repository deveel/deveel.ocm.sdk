// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    /// <summary> The RequestedTerminal. </summary>
    public partial class RequestedTerminal
    {
        /// <summary> Initializes a new instance of RequestedTerminal. </summary>
        /// <param name="terminalId"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="terminalId"/> is null. </exception>
        internal RequestedTerminal(string terminalId)
        {
            Argument.AssertNotNull(terminalId, nameof(terminalId));

            TerminalId = terminalId;
        }

        /// <summary> Initializes a new instance of RequestedTerminal. </summary>
        /// <param name="terminalId"></param>
        /// <param name="type"></param>
        /// <param name="address"></param>
        internal RequestedTerminal(string terminalId, ServerTerminalType? type, string address)
        {
            TerminalId = terminalId;
            Type = type;
            Address = address;
        }

        /// <summary> Gets the terminal id. </summary>
        public string TerminalId { get; }
        /// <summary> Gets the type. </summary>
        public ServerTerminalType? Type { get; }
        /// <summary> Gets the address. </summary>
        public string Address { get; }
    }
}