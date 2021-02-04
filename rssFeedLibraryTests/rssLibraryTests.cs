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
        //Use real RSS Feeds. Until rss FEED test data is created
        Dictionary<string, string> rssTestFeeds = new Dictionary<string, string>() {
            { "Joe Rogan", "http://joeroganexp.joerogan.libsynpro.com/rss" },
            { "Code Switch", "https://feeds.npr.org/510312/podcast.xml" },
            { "The Daily", "https://feeds.simplecast.com/54nAGcIl" },
            { "Ben Sharpio", "https://feeds.megaphone.fm/WWO8086402096" },
            { "DateLine","https://podcastfeeds.nbcnews.com/HL4TzgYC" },
            { "1619","https://feeds.simplecast.com/6HzeyO6b" }
        };

        [TestMethod()]
        public void GetNonActiveFeedsTestMore5Days()
        {
            rssLibrary rl = new rssLibrary();
            Dictionary<string, string> rssNonActiveFeeds = rl.GetNonActiveFeeds(rssTestFeeds, 5);
            Assert.IsTrue(rssNonActiveFeeds.Count == 1, "Expected 1 rss Feeds with no published data more than 5 days");
            
        }

        [TestMethod()]
        public void GetNonActiveFeedsTestMore10Days()
        {
            rssLibrary rl = new rssLibrary();
            Dictionary<string, string> rssNonActiveFeeds = rl.GetNonActiveFeeds(rssTestFeeds, 10);
            Assert.IsTrue(rssNonActiveFeeds.Count == 2, "Expected 2 rss Feeds with no published data more than 10 days");
        }
    }
}