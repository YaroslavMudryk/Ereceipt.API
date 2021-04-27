using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Storage
{
    public interface IStorage
    {
        Task DownloadAsync(string content);
        Task<string> UploadAsync(); 
    }
}