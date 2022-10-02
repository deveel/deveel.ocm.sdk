// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for TerminalOperations.
    /// </summary>
    public static partial class TerminalOperationsExtensions
    {
            /// <summary>
            /// Requests a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static object Request(this ITerminalOperations operations, NewTerminalAssignmentRequest body)
            {
                return operations.RequestAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Requests a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> RequestAsync(this ITerminalOperations operations, NewTerminalAssignmentRequest body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RequestWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Requests a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> RequestWithHttpMessages(this ITerminalOperations operations, NewTerminalAssignmentRequest body, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.RequestWithHttpMessagesAsync(body, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Terminal Assignment Requests
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='page'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            public static object GetRequests(this ITerminalOperations operations, int? page = 1, int? size = 10, string type = default(string))
            {
                return operations.GetRequestsAsync(page, size, type).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Terminal Assignment Requests
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='page'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetRequestsAsync(this ITerminalOperations operations, int? page = 1, int? size = 10, string type = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetRequestsWithHttpMessagesAsync(page, size, type, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a page of Terminal Assignment Requests
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='page'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetRequestsWithHttpMessages(this ITerminalOperations operations, int? page = 1, int? size = 10, string type = default(string), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetRequestsWithHttpMessagesAsync(page, size, type, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static object Create(this ITerminalOperations operations, NewServerTerminal body = default(NewServerTerminal))
            {
                return operations.CreateAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> CreateAsync(this ITerminalOperations operations, NewServerTerminal body = default(NewServerTerminal), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> CreateWithHttpMessages(this ITerminalOperations operations, NewServerTerminal body = default(NewServerTerminal), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.CreateWithHttpMessagesAsync(body, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static object Get(this ITerminalOperations operations, string id)
            {
                return operations.GetAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetAsync(this ITerminalOperations operations, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetWithHttpMessages(this ITerminalOperations operations, string id, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(id, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Terminals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            public static object GetPage(this ITerminalOperations operations, int? number = 1, int? size = 10, string type = default(string))
            {
                return operations.GetPageAsync(number, size, type).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Terminals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetPageAsync(this ITerminalOperations operations, int? number = 1, int? size = 10, string type = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPageWithHttpMessagesAsync(number, size, type, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a page of Terminals
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetPageWithHttpMessages(this ITerminalOperations operations, int? number = 1, int? size = 10, string type = default(string), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetPageWithHttpMessagesAsync(number, size, type, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Looks up a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static object Lookup(this ITerminalOperations operations, TerminalLookup body)
            {
                return operations.LookupAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Looks up a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> LookupAsync(this ITerminalOperations operations, TerminalLookup body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.LookupWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Looks up a Terminal
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> LookupWithHttpMessages(this ITerminalOperations operations, TerminalLookup body, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.LookupWithHttpMessagesAsync(body, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Terminal Assignment Request
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static object GetRequest(this ITerminalOperations operations, string id)
            {
                return operations.GetRequestAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Terminal Assignment Request
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetRequestAsync(this ITerminalOperations operations, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetRequestWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a Terminal Assignment Request
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetRequestWithHttpMessages(this ITerminalOperations operations, string id, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetRequestWithHttpMessagesAsync(id, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}