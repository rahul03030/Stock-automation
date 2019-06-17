using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Selenium_App
{
    class Program
    {
        static void Main(string[] args)
        {

            // Read and show each line from the file.
            Dictionary<string, string> urls = new Dictionary<string, string>();
            string line = "";
            using (StreamReader sr = new StreamReader("Data.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("https:"))
                    {
                        urls.Add(line.Split('/')[6], line);
                    }
                }
            }

            var prevClose = "//*[@id=\"b_prevclose\"]/strong";
            var open = "//*[@id=\"b_open\"]/strong";
            var bid = "//*[@id=\"b_bidprice_qty\"]/strong";
            var offer = "//*[@id=\"b_offerprice_qty\"]/strong";
            var TodayLow = "//*[@id=\"b_low_sh\"]/span";
            var TodayHigh = "//*[@id=\"b_high_sh\"]";
            var Low52 = "//*[@id=\"b_52low\"]/span";
            var High52 = "//*[@id=\"b_52high\"]/span";
            var lowBand = "//*[@id=\"b_low_price_limit\"]";
            var highBand = "//*[@id=\"b_high_price_limit\"]";
            var currentPrice = "//*[@id=\"Bse_Prc_tick\"]/strong";
            var percentChange = "//*[@id=\"b_changetext\"]/text()";

            var TotalBuyQuantity = "//*[@id=\"b_total_buy_qty\"]";
            var TotalSellQuantity = "//*[@id=\"b_total_sell_qty\"]";

            var prevCloseN = "//*[@id=\"n_prevclose\"]/strong";
            var openN = "//*[@id=\"n_open\"]/strong";
            var bidN = "//*[@id=\"n_bidprice_qty\"]/strong";
            var offerN = "//*[@id=\"n_offerprice_qty\"]/strong";
            var NTodayLow = "//*[@id=\"n_low_sh\"]/span";
            var NTodayHigh = "//*[@id=\"n_high_sh\"]";
            var NLow52 = "//*[@id=\"n_52low\"]/span";
            var NHigh52 = "//*[@id=\"n_52high\"]/span";
            var NlowBand = "//*[@id=\"n_low_price_limit\"]";
            var NhighBand = "//*[@id=\"n_high_price_limit\"]";
            var NcurrentPrice = "//*[@id=\"Nse_Prc_tick\"]/strong";
            var NpercentChange = "//*[@id=\"n_changetext\"]/text()";

            string format = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}";

            string formatN = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}";


            var reportFile = new List<string>();
            reportFile.Add(string.Format(format, "Stock", "YesterdayClose", "Open", "Bid", "Offer", "Price", "percentChange", "Low", "High", "52Low", "52High", "BandLow", "BandHigh", "BuyQuantity", "Selld Quantity"));


            foreach (var item in urls)
            {
                try
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");

                    IWebDriver driver = new ChromeDriver(chromeOptions);
                    string url = item.Value;
                    driver.Navigate().GoToUrl(url);


                    reportFile.Add(string.Format(format, item.Key, IsElementPresent(By.XPath(prevClose), driver), IsElementPresent(By.XPath(open), driver), IsElementPresent(By.XPath(bid), driver), IsElementPresent(By.XPath(offer), driver), IsElementPresent(By.XPath(currentPrice), driver), IsElementPresent(By.XPath(percentChange), driver), IsElementPresent(By.XPath(TodayLow), driver), IsElementPresent(By.XPath(TodayHigh), driver), IsElementPresent(By.XPath(Low52), driver), IsElementPresent(By.XPath(High52), driver), IsElementPresent(By.XPath(lowBand), driver), IsElementPresent(By.XPath(highBand), driver), IsElementPresent(By.XPath(TotalBuyQuantity), driver), IsElementPresent(By.XPath(TotalSellQuantity), driver)));
                    reportFile.Add(string.Format(formatN, item.Key, IsElementPresent(By.XPath(prevCloseN), driver), IsElementPresent(By.XPath(openN), driver), IsElementPresent(By.XPath(bidN), driver), IsElementPresent(By.XPath(offerN), driver), IsElementPresent(By.XPath(NcurrentPrice), driver), IsElementPresent(By.XPath(NpercentChange), driver), IsElementPresent(By.XPath(NTodayLow), driver), IsElementPresent(By.XPath(NTodayHigh), driver), IsElementPresent(By.XPath(NLow52), driver), IsElementPresent(By.XPath(NHigh52), driver), IsElementPresent(By.XPath(NlowBand), driver), IsElementPresent(By.XPath(NhighBand), driver)));




                    driver.Close();
                    Console.Clear();

                    Console.WriteLine("SIte" + item.Key + "Processed-------------------------------------------------");


                }
                catch (Exception)
                {

                }

            }

            using (StreamWriter sw = new StreamWriter(DateTime.Now.ToString("dd_MM HH_mm Gainer") + ".csv", false))
            {
                foreach (string s in reportFile)
                {
                    sw.WriteLine(s);
                }
            }

            //line = LowFile();

            Console.WriteLine("Automation completed, do check your report.");

           // Console.ReadKey();













        }

        private static string LowFile()
        {
            // Read and show each line from the file.
            Dictionary<string, string> urls = new Dictionary<string, string>();
            string line = "";
            using (StreamReader sr = new StreamReader("Data2.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("https:"))
                    {
                        urls.Add(line.Split('/')[6], line);
                    }
                }
            }

            var prevClose = "//*[@id=\"b_prevclose\"]/strong";
            var open = "//*[@id=\"b_open\"]/strong";
            var bid = "//*[@id=\"b_bidprice_qty\"]/strong";
            var offer = "//*[@id=\"b_offerprice_qty\"]/strong";
            var TodayLow = "//*[@id=\"b_low_sh\"]/span";
            var TodayHigh = "//*[@id=\"b_high_sh\"]";
            var Low52 = "//*[@id=\"b_52low\"]/span";
            var High52 = "//*[@id=\"b_52high\"]/span";
            var lowBand = "//*[@id=\"b_low_price_limit\"]";
            var highBand = "//*[@id=\"b_high_price_limit\"]";
            var currentPrice = "//*[@id=\"Bse_Prc_tick\"]/strong";
            var percentChange = "//*[@id=\"b_changetext\"]/text()";

            var TotalBuyQuantity = "//*[@id=\"b_total_buy_qty\"]";
            var TotalSellQuantity = "//*[@id=\"b_total_sell_qty\"]";

            var prevCloseN = "//*[@id=\"n_prevclose\"]/strong";
            var openN = "//*[@id=\"n_open\"]/strong";
            var bidN = "//*[@id=\"n_bidprice_qty\"]/strong";
            var offerN = "//*[@id=\"n_offerprice_qty\"]/strong";
            var NTodayLow = "//*[@id=\"n_low_sh\"]/span";
            var NTodayHigh = "//*[@id=\"n_high_sh\"]";
            var NLow52 = "//*[@id=\"n_52low\"]/span";
            var NHigh52 = "//*[@id=\"n_52high\"]/span";
            var NlowBand = "//*[@id=\"n_low_price_limit\"]";
            var NhighBand = "//*[@id=\"n_high_price_limit\"]";
            var NcurrentPrice = "//*[@id=\"Nse_Prc_tick\"]/strong";
            var NpercentChange = "//*[@id=\"n_changetext\"]/text()";

            string format = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}";

            string formatN = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}";


            var reportFile = new List<string>();
            reportFile.Add(string.Format(format, "Stock", "YesterdayClose", "Open", "Bid", "Offer", "Price", "percentChange", "Low", "High", "52Low", "52High", "BandLow", "BandHigh", "BuyQuantity", "Selld Quantity"));


            foreach (var item in urls)
            {
                try
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");

                    IWebDriver driver = new ChromeDriver(chromeOptions);
                    string url = item.Value;
                    driver.Navigate().GoToUrl(url);


                    reportFile.Add(string.Format(format, item.Key, IsElementPresent(By.XPath(prevClose), driver), IsElementPresent(By.XPath(open), driver), IsElementPresent(By.XPath(bid), driver), IsElementPresent(By.XPath(offer), driver), IsElementPresent(By.XPath(currentPrice), driver), IsElementPresent(By.XPath(percentChange), driver), IsElementPresent(By.XPath(TodayLow), driver), IsElementPresent(By.XPath(TodayHigh), driver), IsElementPresent(By.XPath(Low52), driver), IsElementPresent(By.XPath(High52), driver), IsElementPresent(By.XPath(lowBand), driver), IsElementPresent(By.XPath(highBand), driver), IsElementPresent(By.XPath(TotalBuyQuantity), driver), IsElementPresent(By.XPath(TotalSellQuantity), driver)));
                    reportFile.Add(string.Format(formatN, item.Key, IsElementPresent(By.XPath(prevCloseN), driver), IsElementPresent(By.XPath(openN), driver), IsElementPresent(By.XPath(bidN), driver), IsElementPresent(By.XPath(offerN), driver), IsElementPresent(By.XPath(NcurrentPrice), driver), IsElementPresent(By.XPath(NpercentChange), driver), IsElementPresent(By.XPath(NTodayLow), driver), IsElementPresent(By.XPath(NTodayHigh), driver), IsElementPresent(By.XPath(NLow52), driver), IsElementPresent(By.XPath(NHigh52), driver), IsElementPresent(By.XPath(NlowBand), driver), IsElementPresent(By.XPath(NhighBand), driver)));




                    driver.Close();
                    Console.Clear();

                    Console.WriteLine("SIte" + item.Key + "Processed-------------------------------------------------");


                }
                catch (Exception)
                {

                }

            }

            using (StreamWriter sw = new StreamWriter(DateTime.Now.ToString("dd_MM HH_mm Loser") + ".csv", false))
            {
                foreach (string s in reportFile)
                {
                    sw.WriteLine(s);
                }
            }

            return line;
        }

        private static string IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                var item = driver.FindElement(by);


                return "\"" + item.Text + "\"";
            }
            catch (NoSuchElementException)
            {
                return "";
            }
        }
    }
}
