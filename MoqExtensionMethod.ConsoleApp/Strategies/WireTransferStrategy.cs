namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class WireTransferStrategy : IStrategy
    {
        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(WireTransferStrategy).Name} payment."); });
        }
    }
}
