using Dapper;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace XA.Selenium
{
    public class DataBase
    {
        public void CumulusGuid(string queryString)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(
                "User ID = CumulusTest;" +
                "Password = #l*2f4E7h8C*;" +
                "Data Source = bazarek1.net.cludo.pl\\CLUDOTRZY;" +
                "Initial Catalog = Cumulus;" +
                "Connection Timeout = 30");

                myConnection.Open();

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(queryString, myConnection);
                myReader = myCommand.ExecuteReader();
                string guidValue = "";

                while (myReader.Read())
                {
                    guidValue = myReader[0].ToString();
                }


                myConnection.Close();
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void AzureWebHook(string queryString)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(
                "User ID = Cumulus;" +
                "Password = %samMx4%Bu1P;" +
                "Data Source = cludo-helpio.database.windows.net;" +
                "Initial Catalog = Cumulus;" +
                "Connection Timeout = 30");

                myConnection.Open();

                var hookResponse = myConnection.Query<string>(queryString).FirstOrDefault();

                Thread.Sleep(10000);

                // START COMPARING
                try
                {
                    Regex regexWASI = new Regex("");
                    Match matchWASI = regexWASI.Match("");
                    Regex regexASI = new Regex("");
                    Match matchASI = regexASI.Match("");
                }
                catch
                {
                    Assert.Fail();
                }

                try
                {
                    Regex regexWSI = new Regex("");
                    Match matchWSI = regexWSI.Match("");
                    Regex regexSI = new Regex("");
                    Match matchSI = regexSI.Match("");
                }
                catch
                {
                    Assert.Fail();
                }

                try
                {
                    Regex regexWACI = new Regex("");
                    Match matchWACI = regexWACI.Match("");
                    Regex regexCI = new Regex("");
                    Match matchCI = regexCI.Match("");
                }
                catch
                {
                    Assert.Fail();
                }
                // END COMPARING

                myConnection.Close();
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void ReadNewCumulusEntry(string queryString)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(
                "User ID = CumulusTest;" +
                "Password = #l*2f4E7h8C*;" +
                "Data Source = bazarek1.net.cludo.pl\\CLUDOTRZY;" +
                "Initial Catalog = Cumulus;" +
                "Connection Timeout = 30");

                myConnection.Open();

                var response = myConnection.Query<string>(queryString).FirstOrDefault();

                // START COMPARE
                try
                {
                    Regex regexASI = new Regex("");
                    Match matchASI = regexASI.Match("");
                }
                catch
                {
                    Assert.Fail();
                }
                // END COMPARE

                myConnection.Close();
            }
            catch
            {
                Assert.Fail();

            }
        }
    }
}
