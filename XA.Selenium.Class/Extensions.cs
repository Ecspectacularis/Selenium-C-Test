using Newtonsoft.Json;
using System.IO;

namespace XA.Selenium
{
    public class Extensions
    {
        public Urls GetUrls()
        {
            string result;

            using (StreamReader reader = new StreamReader(@"C:\Users\CezaryW\Documents\Workspace\Selenium\XA.Selenium\XA.Selenium.Data\TestUrls.json"))
            {
                result = reader.ReadToEnd();
            }

            var c = JsonConvert.DeserializeObject<Urls>(result);

            return c;
        }
    }
}
