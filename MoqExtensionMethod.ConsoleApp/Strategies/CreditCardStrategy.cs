namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class CreditCardStrategy : IStrategy
    {
        public CreditCardStrategy()
        {
        
        }

        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(CreditCardStrategy).Name} payment."); });
        }
    }
}
