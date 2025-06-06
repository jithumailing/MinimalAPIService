using System.Reflection;
public static class EndpointExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpoints = Assembly.GetExecutingAssembly()
                        .DefinedTypes.Where(t => typeof(IEndpointDefinition)
                        .IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IEndpointDefinition>();

        foreach (var endpoint in endpoints)
            endpoint.RegisterEndpoints(app);
    }
}