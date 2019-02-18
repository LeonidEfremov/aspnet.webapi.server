using System;
using System.Globalization;
using System.Reflection;
using App.Metrics;
using App.Metrics.AspNetCore.Endpoints;
using App.Metrics.AspNetCore.Health.Endpoints;
using App.Metrics.Formatters.Ascii;
using App.Metrics.Formatters.Json;
using App.Metrics.Health;
using App.Metrics.Health.Formatters.Json;
using AspNet.WebApi.Server.Filters;
using AspNet.WebApi.Server.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.WebApi;

namespace AspNet.WebApi.Server
{
    /// <summary>Service Startup class.</summary>
    public abstract class Startup
    {
        private const string ServiceNameTemplate = "{0}.v{1}";

        private readonly IConfiguration _configuration;
        private readonly Assembly _assembly;
        private readonly AssemblyName _assemblyName;

        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        protected Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _assembly = GetType().Assembly;
            _assemblyName = _assembly.GetName();
            ApiInfo = GetApiInfo(_assembly);
        }

        /// <summary>Gets Current API info.</summary>
        protected internal ApiInfo ApiInfo { get; }

        /// <summary>Add services to the container.</summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        public virtual void ConfigureServices(IServiceCollection services) => services
            .AddSingleton(ApiInfo)
            .AddHttpContextAccessor()
            .AddResponseCompression(ConfigureResponseCompression)
            .AddResponseCaching(ConfigureResponseCaching)
            .AddCors(ConfigureCors)
            .AddOpenApiDocument(ConfigureSwaggerDocument)
            .AddMetrics(ConfigureMetrics)
            .AddMetricsEndpoints(ConfigureMetricsEndpoints, _configuration)
            .AddHealth(ConfigureHealth)
            .AddHealthEndpoints(ConfigureHealthEndpoints, _configuration)
            .AddMvcCore(ConfigureMvc)
            .AddApiExplorer()
            .AddDataAnnotations()
            .AddJsonFormatters(ConfigureJsonSerializer);

        /// <summary>Configure the HTTP request pipeline.</summary>
        /// <param name="app"><see cref="IApplicationBuilder"/>.</param>
        public virtual void Configure(IApplicationBuilder app) => app
            .UseCors(ConfigureCorsPolicy)
            .UseResponseCompression()
            .UseResponseCaching()
            .UseMvc(ConfigureRoutes)
            .UseHealthAllEndpoints()
            .UseMetricsAllEndpoints()
            .UseMetricsAllMiddleware()
            .UseSwagger(ConfigureSwagger)
            .UseReDoc(ConfigureReDoc)
            .UseSwaggerUi3(ConfigureSwaggerUi3)
            .UseWelcomePage(ConfigureWelcomePage());

        /// <summary>Setup Welcome page.</summary>
        /// <returns><see cref="WelcomePageOptions"/>.</returns>
        protected virtual WelcomePageOptions ConfigureWelcomePage() => new WelcomePageOptions { Path = "/" };

        /// <summary>Setup CORS policies.</summary>
        /// <param name="builder"><see cref="CorsPolicyBuilder"/>.</param>
        protected virtual void ConfigureCorsPolicy(CorsPolicyBuilder builder) => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .DisallowCredentials()
            .Build();

        /// <summary>Setup MVC.</summary>
        /// <param name="options"><see cref="MvcOptions"/>.</param>
        protected virtual void ConfigureMvc(MvcOptions options)
        {
            var filters = options.Filters;

            filters.Add<BadRequestAsyncFilter>();
            filters.Add<NullResultFilter>();
            filters.Add<ExceptionAsyncFilter>();
        }

        /// <summary>Setup JsonSerializer settings.</summary>
        /// <param name="settings"><see cref="JsonSerializerSettings" />.</param>
        protected virtual void ConfigureJsonSerializer(JsonSerializerSettings settings)
        {
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.DateParseHandling = DateParseHandling.DateTime;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.CheckAdditionalContent = true;
            settings.Formatting = Formatting.None;
            settings.Converters.Add(new StringEnumConverter());
            settings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            settings.NullValueHandling = NullValueHandling.Ignore;
        }

        /// <summary>Configure Metrics.</summary>
        /// <param name="builder"><see cref="IMetricsBuilder" />.</param>
        protected virtual void ConfigureMetrics(IMetricsBuilder builder)
        {
            builder.OutputEnvInfo.Using<EnvInfoTextOutputFormatter>();
            builder.OutputMetrics.Using<MetricsJsonOutputFormatter>();
            builder.OutputMetrics.Using<MetricsTextOutputFormatter>();
        }

        /// <summary>Configure Health.</summary>
        /// <param name="builder"><see cref="IHealthBuilder" />.</param>
        protected virtual void ConfigureHealth(IHealthBuilder builder)
        {
            builder.OutputHealth.Using<HealthStatusJsonOutputFormatter>();
        }

        /// <summary>Configure MetricsEndpoints.</summary>
        /// <param name="options"><see cref="MetricEndpointsOptions"/></param>
        protected virtual void ConfigureMetricsEndpoints(MetricEndpointsOptions options) { }

        /// <summary>Configure HealthEndpoints.</summary>
        /// <param name="options"><see cref="HealthEndpointsOptions"/></param>
        protected virtual void ConfigureHealthEndpoints(HealthEndpointsOptions options) { }

        /// <summary>Configure CORS.</summary>
        /// <param name="options"><see cref="CorsOptions" />.</param>
        protected virtual void ConfigureCors(CorsOptions options) { }

        /// <summary>Configure Routes.</summary>
        /// <param name="builder"><see cref="IRouteBuilder" />.</param>
        protected virtual void ConfigureRoutes(IRouteBuilder builder) { }

        /// <summary>Configure ResponseCaching.</summary>
        /// <param name="options"><see cref="ResponseCachingOptions" />.</param>
        protected virtual void ConfigureResponseCaching(ResponseCachingOptions options) { }

        /// <summary>Configure ResponseCompression.</summary>
        /// <param name="options"><see cref="ResponseCompressionOptions" />.</param>
        protected virtual void ConfigureResponseCompression(ResponseCompressionOptions options) { }

        /// <summary>Configure ReDoc.</summary>
        /// <param name="settings"><see cref="SwaggerReDocSettings{WebApiToSwaggerGeneratorSettings}"/></param>
        protected virtual void ConfigureReDoc(SwaggerReDocSettings<WebApiToSwaggerGeneratorSettings> settings)
        {
            settings.Path = "/redoc";
        }

        /// <summary>Configure SwaggerUI API Interface.</summary>
        /// <param name="settings"><see cref="SwaggerDocumentMiddlewareSettings"/>.</param>
        protected virtual void ConfigureSwagger(SwaggerDocumentMiddlewareSettings settings) { }

        /// <summary>Configure SwaggerUi3.</summary>
        /// <param name="settings"><see cref="SwaggerUi3Settings{WebApiToSwaggerGeneratorSettings}"/></param>
        protected virtual void ConfigureSwaggerUi3(SwaggerUi3Settings<WebApiToSwaggerGeneratorSettings> settings)
        {
            settings.Path = "/swagger";
            settings.DefaultModelsExpandDepth = -1;
            settings.EnableTryItOut = true;
        }

        /// <summary>Configure SwaggerDocument.</summary>
        /// <param name="settings"><see cref="SwaggerDocumentSettings"/></param>
        /// <param name="services"><see cref="IServiceProvider"/></param>
        protected virtual void ConfigureSwaggerDocument(SwaggerDocumentSettings settings, IServiceProvider services)
        {
            var informationalVersion = _assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;

            settings.Version = informationalVersion;
            settings.Description = ApiInfo.Description;
            settings.Title = ApiInfo.DisplayName;
            settings.PostProcess = PostProcess;
            settings.SchemaType = SchemaType.OpenApi3;
        }

        /// <summary>PostProcess Swagger Document.</summary>
        /// <param name="document"><see cref="SwaggerDocument"/></param>
        protected virtual void PostProcess(SwaggerDocument document) { }

        private ApiInfo GetApiInfo(Assembly assembly)
        {
            var name = _assemblyName.Name;
            var version = _assemblyName.Version;
            var product = assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
            var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

            return new ApiInfo
            {
                AssemblyName = name,
                ServiceName = string.Format(CultureInfo.InvariantCulture, ServiceNameTemplate, name, version.Major),
                Description = description,
                ApiVersion = $"{version.Major}.{version.Minor}",
                DisplayName = product,
                Version = version
            };
        }
    }
}