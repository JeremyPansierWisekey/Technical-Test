namespace Api.Interfaces
{
    public interface ICertificatesService
    {
        public Task<int> RetrieveMaximumOverlappingCertificateValidityPeriodsCount(int ownerId);
    }
}
