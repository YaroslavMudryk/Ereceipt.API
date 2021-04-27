using System.IO;
namespace Ereceipt.API.Constants
{
    public class TokenConstants
    {
        public static string TokenFileName = "token.txt";
        public static string PathToSaveFiles = Directory.GetCurrentDirectory();
        public static string FullTokenPath = PathToSaveFiles + TokenFileName;
    }
}