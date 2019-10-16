using Newtonsoft.Json;
using System.IO;

namespace XA.Selenium
{
    public class Extensions
    {
        public Urls GetUrls()
        {
            string result;

            using (StreamReader reader = new StreamReader("path")
            {
                result = reader.ReadToEnd();
            }

            var c = JsonConvert.DeserializeObject<Urls>(result);

            return c;
        }
    }
}
