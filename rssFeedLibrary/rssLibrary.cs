using System;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Linq;

namespace rssFeedLibrary
{

    public class rssLibrary
    {
        /// <summary>
        /// This function takes a dictionary list of Company/rssFeeds and number of days
        /// If will take the Todays Date and subtract this many days and see if any of these rss Feeds has made a publication since this dates 
        /// </summary>
        /// <param name="companyRssFeeds"></param>
        /// <param name="numDays"></param>
        /// <returns>Dictionary of companys and rssFeeds </returns>
        public Dictionary<string, string> GetNonActiveFeeds(Dictionary<string, string> companyRssFeeds, int numDays)
        {
            Dictionary<string, string> nonActiveFeeds = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> rssFeed in companyRssFeeds)
            {
                XmlReader rssFeedReader = XmlReader.Create(rssFeed.Value.ToString());
                SyndicationFeed rssFeedData = SyndicationFeed.Load(rssFeedReader);
                var items = rssFeedData.Items.Where(i => i.PublishDate >= DateTimeOffset.Now.AddDays(-numDays));
                if (items.Count() == 0)
                {
                    nonActiveFeeds.Add(rssFeed.Key, rssFeed.Value); //
                }
            }

            return nonActiveFeeds;
        }

    }
}
