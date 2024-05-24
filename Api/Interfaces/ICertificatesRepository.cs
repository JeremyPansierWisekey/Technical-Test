using Api.Models;

namespace Api.Interfaces
{
    public interface ICertificatesRepository
    {
        Task<List<Certificate>> GetCertificates();
    }
}
