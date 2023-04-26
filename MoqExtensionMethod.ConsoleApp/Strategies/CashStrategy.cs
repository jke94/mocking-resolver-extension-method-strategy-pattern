namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class CashStrategy : IStrategy
    {
        public CashStrategy()
        {
            
        }

        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(CashStrategy).Name} payment."); });
        }
    }
}
