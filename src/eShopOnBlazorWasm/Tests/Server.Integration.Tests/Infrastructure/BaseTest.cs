namespace eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure
{
  using MediatR;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.Extensions.DependencyInjection;
  using System;
  using System.Net.Http;
  using System.Text.Json;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Server;
  using System.Net.Http.Headers;
  using System.Net.Mime;
  using System.Text;
  using System.Net.Http.Json;

  /// <summary>
  /// 
  /// </summary>
  /// <remarks>
  /// Based on Jimmy's SliceFixture
  /// https://github.com/jbogard/ContosoUniversityDotNetCore-Pages/blob/master/ContosoUniversity.IntegrationTests/SliceFixture.cs
  /// </remarks>
  public abstract class BaseTest
  {
    private readonly JsonSerializerOptions JsonSerializerOptions;
    private readonly IServiceScopeFactory ServiceScopeFactory;
    protected readonly HttpClient HttpClient;


    public BaseTest(WebApplicationFactory<Startup> aWebApplicationFactory, JsonSerializerOptions aJsonSerializerOptions)
    {
      ServiceScopeFactory = aWebApplicationFactory.Services.GetService<IServiceScopeFactory>();
      HttpClient = aWebApplicationFactory.CreateClient();
      JsonSerializerOptions = aJsonSerializerOptions;
    }

    protected async Task<T> ExecuteInScope<T>(Func<IServiceProvider, Task<T>> aAction)
    {
      using IServiceScope serviceScope = ServiceScopeFactory.CreateScope();
      return await aAction(serviceScope.ServiceProvider);
    }

    protected Task Send(IRequest aRequest)
    {
      return ExecuteInScope
      (
        aServiceProvider =>
        {
          IMediator mediator = aServiceProvider.GetService<IMediator>();

          return mediator.Send(aRequest);
        }
      );
    }

    protected Task<TResponse> Send<TResponse>(IRequest<TResponse> aRequest)
    {
      return ExecuteInScope
      (
        aServiceProvider =>
        {
          IMediator mediator = aServiceProvider.GetService<IMediator>();

          return mediator.Send(aRequest);
        }
      );
    }

    protected async Task<TResponse> PostJsonAsync<TRequest, TResponse>(string aUri, TRequest aRequest)
    {
      HttpResponseMessage httpResponseMessage =
      await HttpClient.PostAsJsonAsync<TRequest>
      (
        aUri,
        aRequest
      );
      
      string json = await httpResponseMessage.Content.ReadAsStringAsync();

      httpResponseMessage.EnsureSuccessStatusCode();

      TResponse response = JsonSerializer.Deserialize<TResponse>(json, JsonSerializerOptions);

      return response;
    }

    public virtual async Task Setup()
    {
      using IServiceScope serviceScope = ServiceScopeFactory.CreateScope();
      await Program.SeedDatabase(serviceScope);
    }
  }
}
