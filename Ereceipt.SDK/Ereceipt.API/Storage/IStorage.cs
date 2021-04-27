using Ereceipt.API.Constants;
using System;
using System.Collections.Generic;
using System.IO;
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

    public class FileStorage : IStorage
    {
        public async Task DownloadAsync(string content)
        {
            using var sw = new StreamWriter(TokenConstants.FullTokenPath);
            await sw.WriteLineAsync(content);
        }

        public async Task<string> UploadAsync()
        {
            using var sr = new StreamReader(TokenConstants.FullTokenPath);
            return await sr.ReadLineAsync();
        }
    }
}