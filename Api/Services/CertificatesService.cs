using Api.Interfaces;

namespace Api.Services
{
    public class CertificatesService : ICertificatesService
    {
        private readonly ICertificatesRepository _repository;

        public CertificatesService(ICertificatesRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> RetrieveMaximumOverlappingCertificateValidityPeriodsCount(int ownerId)
        {
            var certificates = await _repository.GetCertificates();

            // TODO implement logic here to return maximum count of overlapping certificate validity periods for the given owner ID
            throw new NotImplementedException();
        }
    }
}
