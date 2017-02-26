using InternetDataAcquisitionLibrary;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

namespace FancyInternetDataAcquisition
{
    public partial class IDA1 : Form
    {
        #region fields
        private DateTimeOffset lastPublishDate; //Shared
        private DateTimeOffset newLastPublishDate; // Extra stupid shit because this thing isnt nullable.
        private bool lastPublishDateSet = false;
        private bool ignoreKeywords = false;
        private readonly List<RSSDownloader> rssDownloaderList = new List<RSSDownloader>(); //One per feed
        private readonly List<string> keywordList = new List<string>();
        private readonly List<string> urlList = new List<string>();
        #endregion

        #region constructor
        public IDA1()
        {
            InitializeComponent();
            updateSetup();
        }
        #endregion

        #region private
        private bool checkAgainstKeywordList(string str)
        {
            foreach (string keyword in keywordList)
                if (str.Contains(keyword))
                    return true;

            return false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            fetchFromFeeds();
        }

        private void stop()
        {
            foreach (RSSDownloader rssDownloader in rssDownloaderList)
                rssDownloader?.HardStop();
        }

        private void updateKeywords()
        {
            string[] lines = keywordsTextbox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            keywordList.Clear();

            foreach (string keyword in lines)
                keywordList.Add(keyword);
        }

        private void updateRSS()
        {
            string[] lines = rssTextbox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            rssDownloaderList.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                string rssFeed = lines[i].Trim();

                if (rssFeed.StartsWith("//"))
                    continue;

                string dateFormat = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";

                RSSDownloader rssDownloader = new RSSDownloader(rssFeed);
                rssDownloader.SetCustomDateTimeFormat(dateFormat);
                rssDownloader.DownloadInterval = 30;
                rssDownloader.Start();
                rssDownloaderList.Add(rssDownloader);
            }
        }
        #endregion

        #region public
        public void updateSetup()
        {
            updateRSS();
            updateKeywords();
            lastPublishDateSet = false;
        }

        public void fetchFromFeeds()
        {
            bool alertNew = false;
            bool newLastPublishDateSet = false;

            for (int i = 0; i < rssDownloaderList.Count; i++)
            {
                RSSDownloader rssDownloader = rssDownloaderList[i];
                List<SyndicationItem> syndicationItemList;

                if (lastPublishDateSet == false && newLastPublishDateSet == false)
                    syndicationItemList = rssDownloader.TryGetAllItems();
                else
                    syndicationItemList = rssDownloader.TryGetItems(lastPublishDate);

                if (syndicationItemList == null)
                {
                    //string url = rssDownloader.URL;
                    System.Console.WriteLine("Download failed.");
                    continue;
                }

                // Update timestamp
                if (syndicationItemList.Count > 0)
                {
                    newLastPublishDateSet = true;
                    DateTimeOffset currentItemDate = syndicationItemList[0].PublishDate;

                    if (currentItemDate.CompareTo(newLastPublishDate) > 0)
                        newLastPublishDate = syndicationItemList[0].PublishDate;
                }

                foreach (SyndicationItem si in syndicationItemList)
                {
                    if (ignoreKeywords || checkAgainstKeywordList(si.Title.Text))
                    {
                        string dateTag = si.PublishDate.ToString("yyyy-MM-dd HH:mm:ss");
                        string itemText = dateTag + ": " + si.Title.Text;
                        listBox.Items.Add(itemText);
                        urlList.Add(si.Id);
                        alertNew = true;
                    }
                }
            }

            if (newLastPublishDateSet)
                lastPublishDate = newLastPublishDate;

            lastPublishDateSet = newLastPublishDateSet;

            if (alertNew)
                return; //TODO: voice alert
        }

        #endregion

        private void viewFullStory(object sender, MouseEventArgs e)
        {
            string url = urlList[listBox.SelectedIndex];

            try
            {
                //Default browser - preferred
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                //Internet explorer/edge/whatever - backup
                Browser browser = new Browser();
                browser.load(url);
            }
        }

        private void tabDeselect(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == setupTab) //Leaving setup tab
                updateSetup();
            else if (e.TabPage == newsTab) //Leaving news tab
                stop();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ignoreKeywords = ((CheckBox)sender).Checked;
        }
    }
}
