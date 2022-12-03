// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    /// <summary> The NewServerTerminal. </summary>
    public partial class NewServerTerminal
    {
        /// <summary> Initializes a new instance of NewServerTerminal. </summary>
        /// <param name="provider"></param>
        /// <param name="role"></param>
        /// <param name="type"></param>
        /// <param name="address"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="provider"/> or <paramref name="address"/> is null. </exception>
        public NewServerTerminal(string provider, TerminalRoles role, ServerTerminalType type, string address)
        {
            Argument.AssertNotNull(provider, nameof(provider));
            Argument.AssertNotNull(address, nameof(address));

            Settings = new ChangeTrackingDictionary<string, object>();
            Provider = provider;
            Role = role;
            Type = type;
            Address = address;
        }

        /// <summary> Dictionary of &lt;any&gt;. </summary>
        public IDictionary<string, object> Settings { get; set; }
        /// <summary> Gets the provider. </summary>
        public string Provider { get; }
        /// <summary> Gets the role. </summary>
        public TerminalRoles Role { get; }
        /// <summary> Gets the type. </summary>
        public ServerTerminalType Type { get; }
        /// <summary> Gets the address. </summary>
        public string Address { get; }
    }
}