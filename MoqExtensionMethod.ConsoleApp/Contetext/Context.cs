using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExtensionMethod.ConsoleApp.Contetext
{
    public interface IContext
    {
        public void SetStrategy(IStrategy? strategy);

        public Task MakePaymentAgnostic();
    }

    public class Context : IContext
    {
        #region Fields

        private IStrategy? _strategy;

        #endregion

        public void SetStrategy(IStrategy? strategy)
        {
            _strategy = strategy;
        }

        public async Task MakePaymentAgnostic()
        {
            if(_strategy == null)
            {
                throw new InvalidOperationException("Strategy has not been selected.");
            }

            await _strategy.MakePayment();
        }
    }
}
