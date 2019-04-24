using System.Linq;
using AlfaBank.Core.Data;
using AlfaBank.Core.Data.Interfaces;
using AlfaBank.Core.Models;
using AlfaBank.Services.Interfaces;
using Moq;
using Server.Test.Mocks;
using Server.Test.Mocks.Services;
using Server.Test.Utils;
using Xunit;

// ReSharper disable PossibleMultipleEnumeration
namespace Server.Test.Data
{
    public class TransactionBankRepositoryTest
    {
        private readonly Mock<ICardService> _cardServiceMock;
        private readonly Mock<ICardRepository> _cardRepositoryMock;

        private readonly TestDataGenerator _testDataGenerator;

        private readonly ITransactionRepository _transactionsRepository;
        private readonly Card _card;
        private readonly User _user;

        public TransactionBankRepositoryTest()
        {
            _cardServiceMock = new CardServiceMockFactory().Mock();
            _cardRepositoryMock = new Mock<ICardRepository>();
            var cardNumberGenerator = new CardNumberGeneratorMockFactory().MockObject();

            _testDataGenerator = new TestDataGenerator(_cardServiceMock.Object, cardNumberGenerator);

            _transactionsRepository = new TransactionRepository(_cardRepositoryMock.Object);

            var cards = _testDataGenerator.GenerateFakeCards();
            _card = cards.First();

            _user = TestDataGenerator.GenerateFakeUser(cards);
        }

        [Fact]
        public void GetTransactions_ExistCard_ReturnCorrectTransactionsList()
        {
            // Arrange
            _cardRepositoryMock.Setup(c => c.Get(_user, _card.CardNumber)).Returns(_card);

            // Act
            var transactions = _transactionsRepository.Get(_user, _card.CardNumber, 0, 10);

            // Assert
            _cardServiceMock.Verify(x => x.TryAddBonusOnOpen(It.IsAny<Card>()), Times.AtMost(3));

            Assert.Single(transactions);
            Assert.Null(transactions.First().CardFromNumber);
            Assert.Equal(_card.CardNumber, transactions.First().CardToNumber);
            Assert.Equal(10M, transactions.First().Sum);
        }

        [Fact]
        public void GetTransactions_NotExistCard_ReturnEmptyResult()
        {
            // Arrange
            var card = _testDataGenerator.GenerateFakeCard("4790878827491205");
            _cardRepositoryMock.Setup(c => c.Get(_user, _card.CardNumber)).Returns((Card) null);

            // Act
            var transactions = _transactionsRepository.Get(_user, card.CardNumber, 0, 10);

            // Assert
            _cardServiceMock.Verify(x => x.TryAddBonusOnOpen(It.IsAny<Card>()), Times.AtMost(4));

            Assert.Empty(transactions);
        }
    }
}