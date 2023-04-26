namespace MoqExtensionMethod.ConsoleApp.Strategies
{
    public class BizumStrategy : IStrategy
    {
        public BizumStrategy()
        {
            
        }

        public async Task MakePayment()
        {
            await Task.Run(() => { Console.WriteLine($"Doing a {typeof(BizumStrategy).Name} payment.");});
        }
    }
}
