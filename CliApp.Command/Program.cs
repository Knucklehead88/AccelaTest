using CliApp.Core.Repository;
using CommandDotNet;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using CommandDotNet.IoC.SimpleInjector;
using Microsoft.Extensions.DependencyInjection;

namespace CliApp.Command
{
    class Program
    {
        static int Main(string[] args)
        {

            var container = new SimpleInjector.Container();
            container.Register<AppDbContext>();
            container.Register<IRepository, EfRepository>();
            container.Register<PersonsCli>();

            return new AppRunner<PersonsCli>()
                                            .UseErrorHandler((ctx, ex) =>
                                            {
                                                ctx.Console.Error.WriteLine(ex.Message);
                                                return 1;
                                            }) // catches all exceptions and displays their message
                            .UseSimpleInjector(container)
                            .UseTypoSuggestions()
                            .Run(args);
        }
    }
}
