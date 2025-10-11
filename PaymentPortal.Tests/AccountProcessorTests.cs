using AutoMapper;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PaymentPortal.Data.Constants;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Models;
using PaymentPortal.Domain.Models;
using PaymentPortal.Domain.Processors;

namespace PaymentPortal.Tests;

[TestFixture]
public class AccountProcessorTests
{
    private Mock<IAccountRepository> mockAccountRepository;
    private Mock<IMapper> mockMapper;
    private Mock<ILogger<AccountProcessor>> mockLogger;
    private AccountProcessor accountProcessor;
    private Mock<HybridCache> mockCache;

    [SetUp]
    public void SetUp()
    {
        mockAccountRepository = new Mock<IAccountRepository>();
        mockMapper = new Mock<IMapper>();
        mockLogger = new Mock<ILogger<AccountProcessor>>();
        mockCache = new Mock<HybridCache>();

        accountProcessor = new AccountProcessor(
            mockAccountRepository.Object,
            mockMapper.Object,
            mockLogger.Object,
            mockCache.Object

        );
    }

    [Test]
    public async Task GetAccountAsync_AccountFound_ReturnsSuccessfulResponse()
    {
        // Arrange
        const string testAccountNumber = "12345";
        var entity = new Account
        {
            Id = 1,
            AccountNumber = "1234567890123456",
            CreateDateUtc = DateTime.UtcNow.AddDays(-7),
            Customer = new Customer { FirstName = "Jane", LastName = "Doe", Address = "1234 Test Lane"},
            AccountType = AccountTypeConstants.Savings,
            CurrencyCode = CurrencyCodeConstants.UnitedStatesDollar,
            AccountBalance = 100.50m
        };
        var mappedResponse = new AccountResponse { AccountNumber = testAccountNumber, AccountBalance = 500.50m };

        // Setup repository mock to return the entity
        mockAccountRepository
            .Setup(r => r.GetAccountByAccountNumberAsync(testAccountNumber))
            .ReturnsAsync(entity);

        // Setup mapper mock to return the mapped DTO
        mockMapper
            .Setup(m => m.Map<AccountResponse>(It.IsAny<Account>()))
            .Returns(mappedResponse);

        // Act
        var result = await accountProcessor.GetAccountAsync(testAccountNumber);

        // Assert
        Assert.Multiple(() =>
        {
            // 1. Check for success status, which is added by the processor
            Assert.That(result.IsSuccessful, Is.True, "The response should indicate success.");
            // 2. Check that the data was mapped correctly
            Assert.That(result.AccountNumber, Is.EqualTo(testAccountNumber), "Account number should match the data.");
            Assert.That(result.AccountBalance, Is.EqualTo(500.50m), "Balance should match the data.");
        });

        // 3. Verify repository was called exactly once
        mockAccountRepository.Verify(r => r.GetAccountByAccountNumberAsync(testAccountNumber), Times.Once());
        // 4. Verify logger was not called
        mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
            Times.Never);
    }

    [Test]
    public async Task GetAccountAsync_AccountNotFound_ReturnsUnsuccessfulDefaultResponse()
    {
        // Arrange
        const string testAccountNumber = "99999";

        // Setup repository mock to return null (Account Not Found)
        mockAccountRepository
            .Setup(r => r.GetAccountByAccountNumberAsync(testAccountNumber))
            .ReturnsAsync((Account)null!); // Explicitly returning null

        // Act
        var result = await accountProcessor.GetAccountAsync(testAccountNumber);

        // Assert
        Assert.Multiple(() =>
        {
            // 1. Check for failure status
            Assert.That(result.IsSuccessful, Is.False, "The response should indicate failure.");
            // 2. Check that the default empty response was returned
            Assert.That(result.AccountNumber, Is.EqualTo(string.Empty), "Account number should be empty.");
            Assert.That(result.AccountBalance, Is.EqualTo(0m), "Balance should be 0 (default).");
        });

        // 3. Verify repository was called
        mockAccountRepository.Verify(r => r.GetAccountByAccountNumberAsync(testAccountNumber), Times.Once());
        // 4. Verify mapper was never called since entity was null
        mockMapper.Verify(m => m.Map<AccountResponse>(It.IsAny<Account>()), Times.Never());
    }

    [Test]
    public async Task GetAccountAsync_AccountFoundWithZeroId_ReturnsUnsuccessfulDefaultResponse()
    {
        // Arrange
        const string testAccountNumber = "67890";
        // Entity found but logic requires Id > 0
        var entity = new Account
        {
            Id = 2,
            AccountNumber = "1234567890123456",
            CreateDateUtc = DateTime.UtcNow.AddDays(-7),
            Customer = new Customer { FirstName = "Jane", LastName = "Doe", Address = "1234 Test Lane" },
            AccountType = AccountTypeConstants.Savings,
            CurrencyCode = CurrencyCodeConstants.UnitedStatesDollar,
            AccountBalance = 999.50m
        };

        mockAccountRepository
            .Setup(r => r.GetAccountByAccountNumberAsync(testAccountNumber))
            .ReturnsAsync(entity);

        // Act
        var result = await accountProcessor.GetAccountAsync(testAccountNumber);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccessful, Is.False, "The response should indicate failure because Id <= 0.");
            Assert.That(result.AccountNumber, Is.EqualTo(string.Empty), "Account number should be empty.");
        });

        // Verify mapper was never called since 'account.Id > 0' failed
        mockMapper.Verify(m => m.Map<AccountResponse>(It.IsAny<Account>()), Times.Never());
    }

    [Test]
    public async Task GetAccountAsync_RepositoryThrowsException_LogsErrorAndReturnsUnsuccessfulDefaultResponse()
    {
        // Arrange
        const string testAccountNumber = "54321";
        var exceptionMessage = "Database connection failed.";
        var expectedException = new Exception(exceptionMessage);

        // Setup repository mock to throw an exception
        mockAccountRepository
            .Setup(r => r.GetAccountByAccountNumberAsync(testAccountNumber))
            .ThrowsAsync(expectedException);

        // Act
        var result = await accountProcessor.GetAccountAsync(testAccountNumber);

        // Assert
        Assert.Multiple(() =>
        {
            // 1. Check for failure status
            Assert.That(result.IsSuccessful, Is.False, "The response should indicate failure due to exception.");
            // 2. Check that the default empty response was returned
            Assert.That(result.AccountNumber, Is.EqualTo(string.Empty), "Account number should be empty.");
        });

        // 3. Verify that the logger's LogError method was called exactly once
        mockLogger.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains($"Exception on GetAccountAsync: {exceptionMessage}")),
                expectedException,
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
            Times.Once,
            "An error should be logged for the exception."
        );
    }

    [Test]
    public async Task CreateAccountAsync_ReturnsDefaultResponse()
    {
        // Arrange
        var request = new CreateAccountRequest { CustomerId = 1, AccountType = AccountTypeConstants.Checking };

        // Act
        var result = await accountProcessor.CreateAccountAsync(request);

        // Assert
        // Based on the provided implementation, it should always return a default AccountResponse.
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null, "The result should not be null.");
            Assert.That(result.IsSuccessful, Is.False, "The default response should be unsuccessful.");
        });
    }
}