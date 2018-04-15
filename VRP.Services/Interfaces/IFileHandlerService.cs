using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VRP.Dtos;

namespace VRP.Services.Interfaces {
    public interface IFileHandlerService {
        Task<FileEntryModel> Upload(IFormFile file);
    }
}
