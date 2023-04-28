namespace MoqExtensionMethod.Tests.Contetext
{
    #region using

    using Moq;
    using NUnit.Framework;
    using MoqExtensionMethod.ConsoleApp;
    using Microsoft.Extensions.DependencyInjection;
    using MoqExtensionMethod.ConsoleApp.Strategies;

    #endregion

    public class ContextTests
    {
        #region Fields

        private MockRepository? _repositoryMock;
        private Mock<IServiceProvider>? _mockServiceProvider;
        private Mock<IServiceScope>? _mockServiceScope;
        private Mock<IServiceScopeFactory>? _mockServiceScopeFactory;


        #endregion

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new MockRepository(MockBehavior.Strict);

            _mockServiceProvider = _repositoryMock.Create<IServiceProvider>();
            _mockServiceScope = _repositoryMock.Create<IServiceScope>();
            _mockServiceScopeFactory = _repositoryMock.Create<IServiceScopeFactory>();

            // Adding services simulation.

            _mockServiceProvider.Setup(service => service.GetService(typeof(BizumStrategy)))
                .Returns(new BizumStrategy());

            _mockServiceProvider.Setup(service => service.GetService(typeof(CashStrategy)))
                .Returns(new CashStrategy());

            _mockServiceProvider.Setup(service => service.GetService(typeof(CreditCardStrategy)))
                .Returns(new CreditCardStrategy());

            _mockServiceProvider.Setup(service => service.GetService(typeof(DebitStrategy)))
                .Returns(new DebitStrategy());

            _mockServiceProvider.Setup(service => service.GetService(typeof(WireTransferStrategy)))
                .Returns(new WireTransferStrategy());

            // Mockig service scope.

            _mockServiceScope
                .Setup(x => x.ServiceProvider)
                .Returns(_mockServiceProvider.Object);

            // Mocking service factory.

            _mockServiceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(_mockServiceScope.Object);

            // Mocking serivice provider.
            _mockServiceProvider
                .Setup(x =>x.GetService(typeof(IServiceScopeFactory)))
                .Returns(_mockServiceScopeFactory.Object);
        }

        #region Private Methods

        private IStrategy GetStrategyResolver(string stategy)
        {
            if (_mockServiceProvider is null ||
                _mockServiceScope is null ||
                _mockServiceScopeFactory is null)
            {
                throw new NullReferenceException();
            }


            return _mockServiceProvider.Object.GetPaymentStrategy(stategy);
        }

        #endregion

        [TestCase(StrategyName.Bizum, ExpectedResult = typeof(BizumStrategy))]
        [TestCase(StrategyName.Cash, ExpectedResult = typeof(CashStrategy))]
        [TestCase(StrategyName.CreditCard, ExpectedResult = typeof(CreditCardStrategy))]
        [TestCase(StrategyName.Debit, ExpectedResult = typeof(DebitStrategy))]
        public Type WhenGetPaymentStrategyMethodIsCalledWithAnExistingStrategyThenReturnsStrategy(string strategyName)
        {
            // Arrange

            // Act
            var strategy = GetStrategyResolver(strategyName);

            // Assert
            Assert.That(strategy, Is.Not.Null);

            return strategy.GetType();
        }

        [TestCase(StrategyName.MonopoleyMoney, typeof(NotImplementedException))]
        public void WhenGetPaymentStrategyMethodIsCalledWithANonExistingStrategyThenReturnsAnException(
            string strategyName, Type exceptionType)
        {
            // Arrange

            // Act

            // Assert
            var exception = Assert.Throws(exceptionType, () => GetStrategyResolver(strategyName));

            Assert.That(exception.Message, Is.EqualTo($"Strategy {strategyName} has not been implemented."));
        }
    }
}
