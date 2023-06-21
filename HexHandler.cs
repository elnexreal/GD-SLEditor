using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GD_SLEditor.Handling
{
    /// <summary>
    /// Handles the Hex modifications for the executable
    /// </summary>
    internal class HexHandler
    {
        public static void HexModify(string executable, string serverurl)
        {
            string baseUrl = "http://www.boomlings.com/database";

            // Reads the hex of the executable
            byte[] execBytes = File.ReadAllBytes(executable);
            string exHex = bytesToHex(execBytes);

            // Reads the hex of the server url provided
            byte[] urlBytes = Encoding.ASCII.GetBytes(serverurl);
            string urlHex = bytesToHex(urlBytes);

            // Converts boomlings URL to HEX
            string boomlingsHex = stringToHex(baseUrl);

            // Base64 encode everything
            string b64Url = stringToHex(base64encode(serverurl));
            string b64Boomlings = stringToHex(base64encode(baseUrl));

            // Replace the URL's
            string encodedHex = exHex.Replace(boomlingsHex, urlHex).Replace(b64Boomlings, b64Url);

            // Write the file
            File.WriteAllBytes(executable, StringToByteArray(encodedHex));

            // Debug
            //File.WriteAllText("C:/Users/elnexreal/Desktop/Deb/Gamehex.txt", exHex);
            //File.WriteAllText("C:/Users/elnexreal/Desktop/Deb/Urlhex.txt", urlHex);
        }

        // Converts HEX string into a Byte arraw to write in the exe
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        // Encodes any string given to it
        private static string base64encode(string url)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(url);
            return Convert.ToBase64String(bytes);
        }

        // Converts bytes to HEX strings
        private static string bytesToHex(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        // Convert string to hex
        private static string stringToHex(string input)
        {
            return BitConverter.ToString(Encoding.ASCII.GetBytes(input)).Replace("-", string.Empty);
        }
    }
}
