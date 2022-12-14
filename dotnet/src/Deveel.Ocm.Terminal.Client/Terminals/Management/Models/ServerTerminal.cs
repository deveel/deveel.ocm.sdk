// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Deveel.Messaging.Terminals.Management.Models
{
    /// <summary> The ServerTerminal. </summary>
    public partial class ServerTerminal
    {
        /// <summary> Initializes a new instance of ServerTerminal. </summary>
        /// <param name="type"></param>
        /// <param name="address"></param>
        /// <param name="status"></param>
        /// <param name="source"></param>
        /// <param name="role"></param>
        /// <param name="provider"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="address"/> or <paramref name="provider"/> is null. </exception>
        internal ServerTerminal(ServerTerminalType type, string address, TerminalStatus status, TerminalSource source, TerminalRoles role, string provider)
        {
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNull(provider, nameof(provider));

            Type = type;
            Address = address;
            Status = status;
            Source = source;
            Role = role;
            Settings = new ChangeTrackingDictionary<string, object>();
            Context = new ChangeTrackingDictionary<string, object>();
            Provider = provider;
        }

        /// <summary> Initializes a new instance of ServerTerminal. </summary>
        /// <param name="type"></param>
        /// <param name="address"></param>
        /// <param name="status"></param>
        /// <param name="lastChanged"></param>
        /// <param name="source"></param>
        /// <param name="role"></param>
        /// <param name="sourceId"></param>
        /// <param name="settings"> Dictionary of &lt;any&gt;. </param>
        /// <param name="context"> Dictionary of &lt;any&gt;. </param>
        /// <param name="provider"></param>
        /// <param name="id"></param>
        internal ServerTerminal(ServerTerminalType type, string address, TerminalStatus status, DateTimeOffset? lastChanged, TerminalSource source, TerminalRoles role, string sourceId, IReadOnlyDictionary<string, object> settings, IReadOnlyDictionary<string, object> context, string provider, string id)
        {
            Type = type;
            Address = address;
            Status = status;
            LastChanged = lastChanged;
            Source = source;
            Role = role;
            SourceId = sourceId;
            Settings = settings;
            Context = context;
            Provider = provider;
            Id = id;
        }

        /// <summary> Gets the type. </summary>
        public ServerTerminalType Type { get; }
        /// <summary> Gets the address. </summary>
        public string Address { get; }
        /// <summary> Gets the status. </summary>
        public TerminalStatus Status { get; }
        /// <summary> Gets the last changed. </summary>
        public DateTimeOffset? LastChanged { get; }
        /// <summary> Gets the source. </summary>
        public TerminalSource Source { get; }
        /// <summary> Gets the role. </summary>
        public TerminalRoles Role { get; }
        /// <summary> Gets the source id. </summary>
        public string SourceId { get; }
        /// <summary> Dictionary of &lt;any&gt;. </summary>
        public IReadOnlyDictionary<string, object> Settings { get; }
        /// <summary> Dictionary of &lt;any&gt;. </summary>
        public IReadOnlyDictionary<string, object> Context { get; }
        /// <summary> Gets the provider. </summary>
        public string Provider { get; }
        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
