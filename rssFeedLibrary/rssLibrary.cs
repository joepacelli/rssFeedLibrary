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
        public Dictionary<string, List<string>> GetNonActiveFeeds(Dictionary<string, List<string>> companyRssFeeds, int numDays)
        {
            Dictionary<string, List<string>> companyRssFeedsNoRecentPublication = new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string, List<string>> companyRssFeed in companyRssFeeds)
            {
                string company = companyRssFeed.Key;
                List<string> rssFeeds = companyRssFeed.Value;
                List<string> nonActiveFeeds = new List<string>();
                bool nonActiveFeedsExist = false;
                foreach (string rssFeed in rssFeeds)
                {
                    XmlReader rssFeedReader = XmlReader.Create(rssFeed);
                    SyndicationFeed rssFeedData = SyndicationFeed.Load(rssFeedReader);
                    SyndicationItem item = rssFeedData.Items.First();
                    if ((DateTime.Now - item.PublishDate.Date).TotalDays > numDays)
                    {
                        nonActiveFeeds.Add(rssFeed);
                        nonActiveFeedsExist = true;
                    }
                }
                if (nonActiveFeedsExist)
                {
                    companyRssFeedsNoRecentPublication.Add(company, nonActiveFeeds); //
                }
            }

            return companyRssFeedsNoRecentPublication;
        }

    }
}
