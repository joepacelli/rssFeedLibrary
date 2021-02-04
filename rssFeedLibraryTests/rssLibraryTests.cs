using Microsoft.VisualStudio.TestTools.UnitTesting;
using rssFeedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rssFeedLibrary.Tests
{
    [TestClass()]
    public class rssLibraryTests
    {
        //Use rss Feed data from repository
        // rssFeedtestData_1 - Last Published: 11/27/2020
        // rssFeedTestData_2 - Last Published: 2/3/2021
        // rssFeedTestData_3 - Last Published: 2/4/2021
        // rssFeedTestData_4 - Last Published: 2/4/2021
        // rssFeedTestData_5 - Last Published: 2/4/2021
        // rssFeedTestData_6 - Last Published: 10/12/2019
        Dictionary<string, List<string>> rssTestFeeds = new Dictionary<string, List<string>>() {
            { "Company 1", new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_1.xml" } },  
            { "Company 2",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_2.xml"} },
            { "Company 3",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_3.xml"} },
            { "Company 4",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_4.xml"} },
            { "Company 5",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_5.xml"} },
            { "Company 6",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_6.xml"} },
            { "Company 7",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_1.xml"} },
            { "Company 8",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_6.xml"} },
            { "Company 9",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_5.xml" , "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_6.xml" } },
            { "Company 10",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_1.xml" , "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_6.xml" } },
            { "Company 11",new List<string>() { "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_1.xml" , "https://raw.githubusercontent.com/joepacelli/rssFeedLibrary/main/rssFeedTestData_2.xml" } }
        };

        /// <summary>
        /// This should test for no publish rss Feed in past 30 days
        /// The following companies should meet this criteria
        /// Company 1
        /// Company 6
        /// Company 7
        /// Company 8
        /// company 9 - 1 feed
        /// Company 10 - 2 feeds
        /// Company 11 - 1 feed
        /// </summary>
        [TestMethod()]
        public void GetNonActiveFeedsTestMore30Days()
        {
            rssLibrary rl = new rssLibrary();
            Dictionary<string, List<string>> rssNonActiveFeeds = rl.GetNonActiveFeeds(rssTestFeeds, 30);
            int totalFeeds = 0;
            foreach (KeyValuePair<string, List<string>> rssFeeds in rssNonActiveFeeds)
            {
                totalFeeds = totalFeeds + rssFeeds.Value.Count();
            }
            Assert.IsTrue(totalFeeds == 8, "Expected 8 rss Feeds with no published data more than 30 days");
            
        }

        /// <summary>
        /// This should test for no publish rss Feed in past 90 days
        /// The following companies should meet this criteria
        /// Company 6
        /// Company 8
        /// company 9 - 1 feed
        /// Company 10 - 1 feed
        /// </summary>
        [TestMethod()]
        public void GetNonActiveFeedsTestMore90Days()
        {
            rssLibrary rl = new rssLibrary();
            Dictionary<string, List<string>> rssNonActiveFeeds = rl.GetNonActiveFeeds(rssTestFeeds, 90);
            int totalFeeds = 0;
            foreach (KeyValuePair<string, List<string>> rssFeeds in rssNonActiveFeeds)
            {
                totalFeeds = totalFeeds + rssFeeds.Value.Count();
            }
            Assert.IsTrue(totalFeeds == 4, "Expected 4 rss Feeds with no published data more than 90 days");
        }
    }
}