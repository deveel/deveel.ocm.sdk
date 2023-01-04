using Azure;

using Deveel.Messaging.Commands;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class OcmClientExtensions {
		public static async Task<TResult> ExecuteAsync<TCommand, TResult>(this IOcmClient client, TCommand command, CancellationToken cancellationToken)
			where TCommand : class, IClientCommand<TResult> {
			try {
				var handler = client.Services.GetRequiredService<IClientCommandHandler<TCommand, TResult>>();
				if (handler == null)
					throw new OcmClientException($"The command {typeof(TCommand)} is not handled");

				return await handler.HandleAsync(command, cancellationToken);
			} catch (RequestFailedException ex) when(ex.Status == 403) {
				throw new ServiceAuthorizationException("The client is not authorized to perform the request", ex);
			} catch(RequestFailedException ex) when (ex.Status == 401) {
				throw new ServiceAuthenticationException("The client is not authenticated", ex);
			} catch(RequestFailedException ex) when(ex.Status == 400) {
				throw new RequestValidationException("The request is invalid: see the inner exception for details", ex);
			} catch(OcmClientException) {
				throw;
			} catch(Exception ex) {
				throw new OcmClientException("Unknown error on the client", ex);
			}
		}

		public static async Task ExecuteAsync<TCommand>(this IOcmClient client, TCommand command, CancellationToken cancellationToken)
			where TCommand : class, IClientCommand {
			try {
				var handler = client.Services.GetRequiredService<IClientCommandHandler<TCommand>>();
				if (handler == null)
					throw new OcmClientException($"The command {typeof(TCommand)} is not handled");

				await handler.HandleAsync(command, cancellationToken);
			} catch (RequestFailedException ex) when (ex.Status == 403) {
				throw new ServiceAuthorizationException("The client is not authorized to perform the request", ex);
			} catch (RequestFailedException ex) when (ex.Status == 401) {
				throw new ServiceAuthenticationException("The client is not authenticated", ex);
			} catch (RequestFailedException ex) when (ex.Status == 400) {
				throw new RequestValidationException("The request is invalid: see the inner exception for details", ex);
			} catch (OcmClientException) {
				throw;
			} catch (Exception ex) {
				throw new OcmClientException("Unknown error on the client", ex);
			}
		}
	}
}
