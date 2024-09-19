namespace FileManager.Server.Infrastructure;
public static class ServiceExtension
{
    public static IServiceCollection RegisterAdditionalServices(this IServiceCollection services, IConfiguration Configuration)
    {
        #region Logger Services

        // Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).Enrich.FromLogContext().CreateLogger();
        //
        // services.AddLogging(x =>
        // {
        //     x.ClearProviders();
        //     x.AddSerilog();
        // });
        //
        // services.AddHttpContextAccessor();
        // services.AddScoped<IAppLogger, AppLogger>();

        #endregion

        // services.AddEntityFrameworkSqlServer().AddDbContext<EProcContext>();
        // services.AddDbContextFactory<EProcContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FE_Proc")));
        // services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        // services.AddScoped<IMapper, Mapper>();

        // services.AddScoped(typeof(IEsadsRepo<>), typeof(EsadsRepo<>));
        // services.AddScoped<IESADSBiz, ESADSBiz>();
        // services.AddScoped<IExternalBiz, ExternalBiz>();
        // services.AddScoped<IGraphBiz, GraphBiz>();
        // services.AddScoped<IeInspectionBiz, eInspectionBiz>();

        services.AddControllers();

        // services.AddControllers()
        //     .AddNewtonsoftJson(options =>
        //         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
        //     )
        //     .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

        return services;
    }
}

