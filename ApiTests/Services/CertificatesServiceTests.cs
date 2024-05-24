using Api.Interfaces;
using Api.Models;
using Api.Services;
using Moq;

namespace ApiTests.Services
{
    public class CertificatesServiceTests
    {
        [Test]
        [TestCase(1000)]
        [TestCase(2000)]
        public void RetrieveMaximumOverlappingCertificateValidityPeriodsCount_UnknownId_ThrowsKeyNotFoundException(int ownerId)
        {
            // Arrange
            var certificatesRepositoryMock = new Mock<ICertificatesRepository>();
            certificatesRepositoryMock.Setup(x => x.GetCertificates()).Returns(Task.FromResult(new List<Certificate>()));
            var certificatesService = new CertificatesService(certificatesRepositoryMock.Object);

            // Act
            async Task Act() => await certificatesService.RetrieveMaximumOverlappingCertificateValidityPeriodsCount(ownerId);

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(Act);
        }

        [Test]
        [TestCase(1, ExpectedResult = 5)] // Issue example case
        [TestCase(2, ExpectedResult = 5)] // Seconds case
        [TestCase(3, ExpectedResult = 5)] // Ticks case
        [TestCase(4, ExpectedResult = 1)] // No overlap case
        [TestCase(5, ExpectedResult = 1)] // Only one item case
        public async Task<int> RetrieveMaximumOverlappingCertificateValidityPeriodsCount_KnownId_ReturnsMaximumOverlappingCertificatesCount(int ownerId)
        {
            // Arrange
            var certificatesRepositoryMock = new Mock<ICertificatesRepository>();
            var certificates = new List<Certificate>()
            {
                new Certificate(1, new DateTime(2000,1,1), new DateTime(2000,1,4)),
                new Certificate(1, new DateTime(2000,1,1), new DateTime(2000,1,3)),
                new Certificate(1, new DateTime(2000,1,2), new DateTime(2000,1,4)),
                new Certificate(1, new DateTime(2000,1,3), new DateTime(2000,1,6)),
                new Certificate(1, new DateTime(2000,1,5), new DateTime(2000,1,7)),
                new Certificate(1, new DateTime(2000,1,3), new DateTime(2000,1,3)),
                new Certificate(2, new DateTime(2001,1,1,1,1,1), new DateTime(2004,4,4,4,4,4)),
                new Certificate(2, new DateTime(2001,1,1,1,1,2), new DateTime(2003,3,3,3,3,3)),
                new Certificate(2, new DateTime(2002,2,2,2,2,2), new DateTime(2004,4,4,4,4,5)),
                new Certificate(2, new DateTime(2003,3,3,3,3,2), new DateTime(2006,6,6,6,6,6)),
                new Certificate(2, new DateTime(2005,5,5,5,5,5), new DateTime(2007,7,7,7,7,7)),
                new Certificate(2, new DateTime(2003,3,3,3,3,1), new DateTime(2003,3,3,3,3,4)),
                new Certificate(3, new DateTime(1), new DateTime(4)),
                new Certificate(3, new DateTime(1), new DateTime(3)),
                new Certificate(3, new DateTime(2), new DateTime(4)),
                new Certificate(3, new DateTime(3), new DateTime(6)),
                new Certificate(3, new DateTime(5), new DateTime(7)),
                new Certificate(3, new DateTime(3), new DateTime(3)),
                new Certificate(4, new DateTime(2000,1,1), new DateTime(2000,2,2)),
                new Certificate(4, new DateTime(2000,3,3), new DateTime(2000,4,4)),
                new Certificate(5, new DateTime(2000,3,3), new DateTime(2000,4,4)),
            };
            certificatesRepositoryMock.Setup(x => x.GetCertificates()).Returns(Task.FromResult(certificates));
            var certificatesService = new CertificatesService(certificatesRepositoryMock.Object);

            // Act
            var count = await certificatesService.RetrieveMaximumOverlappingCertificateValidityPeriodsCount(ownerId);

            // Assert
            return count;
        }
    }
}