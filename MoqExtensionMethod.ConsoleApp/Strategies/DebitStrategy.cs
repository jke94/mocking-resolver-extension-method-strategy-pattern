namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class DebitStrategy : IStrategy
    {
        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(DebitStrategy).Name} payment."); });
        }
    }
}
