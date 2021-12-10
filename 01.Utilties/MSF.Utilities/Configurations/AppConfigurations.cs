namespace MSF.Utilities.Configurations
{
    public class AppConfigurations
    {
        public SwaggerOptions Swagger { get; set; } = new SwaggerOptions();

        public RegistrationServiceAssemblyName RegistrationServiceAssemblyName { get; set; } = new RegistrationServiceAssemblyName();

        public HangFireOptions HangFireOptions { get; set; } = new HangFireOptions();
    }

    public class SwaggerOptions
    {
        public bool Enabled { get; set; } = true;
        public SwaggerdocOptions SwaggerDoc { get; set; } = new SwaggerdocOptions();
    }

    public class SwaggerdocOptions
    {
        public string Version { get; set; } = "v1";
        public string Title { get; set; } = "My Application Title";
        public string Name { get; set; } = "v1";
        public string URL { get; set; } = "/swagger/v1/swagger.json";
    }

    public class HangFireOptions
    {
        public bool EnableHangfire { get; set; } = false;
        public bool UseHangfireDashboard { get; set; } = false;
        public string HangFireDashboardPath { get; set; } = "/hangfire";
        public string ConnectionString { get; set; }
    }

    public class RegistrationServiceAssemblyName
    {
        public string AutoMapperRegidtrationServiceAssembliesName { get; set; } = "";
        public string MediatRegidtrationServiceAssembliesName { get; set; } = "";
    }
}
