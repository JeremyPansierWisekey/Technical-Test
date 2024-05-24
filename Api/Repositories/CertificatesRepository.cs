using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class CertificatesRepository : ICertificatesRepository
    {
        private readonly List<Certificate> _certificates = new()
        {
            new Certificate(1, new DateTime(2000,1,1), new DateTime(2000,1,20)),
            new Certificate(1, new DateTime(2000,1,10), new DateTime(2000,1,21)),
            new Certificate(1, new DateTime(2000,2,10), new DateTime(2000,2,21)),
            new Certificate(2, new DateTime(2020,2,1), new DateTime(2020,6,1)),
            new Certificate(2, new DateTime(2020,3,1), new DateTime(2020,5,1)),
            new Certificate(2, new DateTime(2020,4,1), new DateTime(2020,7,1)),
            new Certificate(2, new DateTime(2020,1,1), new DateTime(2020,2,1)),
            new Certificate(2, new DateTime(2020,10,1), new DateTime(2020,11,1)),
        };

        public async Task<List<Certificate>> GetCertificates()
        {
            return _certificates;
        }
    }
}
