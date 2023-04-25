namespace MoqExtensionMethod.ConsoleApp
{
    #region using

    using Microsoft.Extensions.DependencyInjection;
    using MoqExtensionMethod.ConsoleApp.Strategies;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.BuildServiceProvider();
            serviceCollection.AddStrategies();

            var serviceProvider = serviceCollection.BuildServiceProvider();


            var paymement = serviceProvider.GetStrategy(StrategyName.Debit);

            await paymement.MakePayment();

            Console.WriteLine("Hello, World!");
        }
    }
}