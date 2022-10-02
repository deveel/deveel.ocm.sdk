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
    /// Extension methods for Route.
    /// </summary>
    public static partial class RouteExtensions
    {
            /// <summary>
            /// Creates a new Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static object Create(this IRoute operations, NewMessageRoute body)
            {
                return operations.CreateAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a new Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> CreateAsync(this IRoute operations, NewMessageRoute body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a new Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> CreateWithHttpMessages(this IRoute operations, NewMessageRoute body, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.CreateWithHttpMessagesAsync(body, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static object Get(this IRoute operations, string id)
            {
                return operations.GetAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetAsync(this IRoute operations, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a Route of Incoming Messages
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetWithHttpMessages(this IRoute operations, string id, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(id, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a given Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static ProblemDetails Delete(this IRoute operations, string id)
            {
                return operations.DeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a given Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProblemDetails> DeleteAsync(this IRoute operations, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a given Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<ProblemDetails> DeleteWithHttpMessages(this IRoute operations, string id, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.DeleteWithHttpMessagesAsync(id, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the Status of a Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='routeId'>
            /// </param>
            public static object SetStatus(this IRoute operations, MessageRouteStatusUpdate body, string routeId)
            {
                return operations.SetStatusAsync(body, routeId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the Status of a Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='routeId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> SetStatusAsync(this IRoute operations, MessageRouteStatusUpdate body, string routeId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetStatusWithHttpMessagesAsync(body, routeId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the Status of a Message Route
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='routeId'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> SetStatusWithHttpMessages(this IRoute operations, MessageRouteStatusUpdate body, string routeId, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.SetStatusWithHttpMessagesAsync(body, routeId, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Message Routes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            public static object GetPage(this IRoute operations, int? number = 1, int? size = 10)
            {
                return operations.GetPageAsync(number, size).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a page of Message Routes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetPageAsync(this IRoute operations, int? number = 1, int? size = 10, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPageWithHttpMessagesAsync(number, size, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a page of Message Routes
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<object> GetPageWithHttpMessages(this IRoute operations, int? number = 1, int? size = 10, Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetPageWithHttpMessagesAsync(number, size, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}