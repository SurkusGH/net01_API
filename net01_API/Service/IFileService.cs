using System.Collections.Generic;

namespace net01_API.Service
{
    public interface IFileService
    {
        List<string> ReadFile(string path);
        void WriteToFile(string path, string content);
    }
}
