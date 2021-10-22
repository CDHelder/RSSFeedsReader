using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business
{
    public class RSSService
    {
        private List<string> urls = new List<string> {"https://www.nu.nl/rss/Tech", "https://www.techrepublic.com/rssfeeds/articles/", "https://www.techvisor.nl/Rss/RssArtikelen/" };

        public string GetRSSData()
        {
            List<SyndicationItem> items = new List<SyndicationItem>();
            string allcontent = "";

            foreach (var url in urls)
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed syndicationFeed = SyndicationFeed.Load(reader);
                reader.Close();

                string content = "";
                foreach (var item in syndicationFeed.Items)
                {
                    Type itemType = item.GetType();
                    IList<PropertyInfo> props = new List<PropertyInfo>(itemType.GetProperties());
                    foreach (var prop in props)
                    {
                        //TODO: Strategy pattern voor welke properties weergeven worden
                        if (prop.GetValue(item) != null)
                            content += prop.Name.ToString() + ": " + prop.GetValue(item).ToString() + "\n";
                    }
                }
                allcontent += content + "\n~~~~~~~~~~~\n";
            }

            return allcontent;
        }
    }
}
