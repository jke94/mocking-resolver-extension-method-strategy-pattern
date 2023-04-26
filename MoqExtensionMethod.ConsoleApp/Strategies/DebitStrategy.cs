namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class DebitStrategy : IStrategy
    {
        public DebitStrategy()
        {
            
        }

        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(DebitStrategy).Name} payment."); });
        }
    }
}
