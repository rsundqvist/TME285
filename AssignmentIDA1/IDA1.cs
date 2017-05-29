using InternetDataAcquisitionLibrary;
using ObjectSerializerLibrary;
using SpeechSynthesisLibrary.FormantSynthesis;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.IO;
using System.Media;
using AudioLibrary;

namespace FancyInternetDataAcquisition
{
    public partial class IDA1 : Form
    {
        #region fields
        private bool ignoreKeywords = false;
        private readonly List<RSSDownloader> rssDownloaderList = new List<RSSDownloader>(); //One per feed
        private readonly List<string> rssList = new List<string>();
        private readonly List<DateTimeOffset> lastPublishDate = new List<DateTimeOffset>();
        private readonly DateTimeOffset DEFAULT_DATE_TIME_OFFSET = DateTimeOffset.MaxValue; //Not nullable
        private readonly List<string> keywordList = new List<string>();
        private readonly List<string> urlList = new List<string>();

        private SpeechSynthesizer _synthesizer;
        private const string SynthPath = "\\..\\..\\ss.xml";
        #endregion

        #region constructor
        public IDA1()
        {
            InitializeComponent();
            updateSetup();

            try
            {
                string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                LoadSynthesizer(applicationDirectory + SynthPath);
                speechStatusBox.Text = "Speech loaded.";
            }
            catch (Exception)
            {
            }
        }

        private void LoadSynthesizer(string path)
        {
            try
            {
                _synthesizer = (SpeechSynthesizer)ObjectXmlSerializer.ObtainSerializedObject(path, typeof(SpeechSynthesizer));
            }
            catch (Exception)
            {
                _synthesizer = null;
                MessageBox.Show("Failed to load speech synthesizer: " + SynthPath, "Failed to load VSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                speechStatusBox.Text = "Speech failed to load.";
            }
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
                rssDownloader.HardStop();
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
            lastPublishDate.Clear();
            listBox.Items.Clear();
            urlList.Clear();
            rssList.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                string rssFeed = lines[i].Trim();

                if (rssFeed.StartsWith("//"))
                    continue;

                string dateFormat = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";

                rssList.Add(rssFeed);
                RSSDownloader rssDownloader = new RSSDownloader(rssFeed);
                rssDownloader.SetCustomDateTimeFormat(dateFormat);
                rssDownloader.DownloadInterval = 30;
                rssDownloader.Start();
                rssDownloaderList.Add(rssDownloader);
                lastPublishDate.Add(DEFAULT_DATE_TIME_OFFSET);
            }
        }
        #endregion

        #region public
        public void updateSetup()
        {
            updateRSS();
            updateKeywords();
        }

        public void fetchFromFeeds()
        {
            bool alertNew = false;

            for (int i = 0; i < rssDownloaderList.Count; i++)
            {
                RSSDownloader rssDownloader = rssDownloaderList[i];
                List<SyndicationItem> syndicationItemList;

                if (lastPublishDate[i] == DEFAULT_DATE_TIME_OFFSET)
                    syndicationItemList = rssDownloader.TryGetAllItems();
                else
                    syndicationItemList = rssDownloader.TryGetItems(lastPublishDate[i]);

                if (syndicationItemList == null)
                {
                    //string url = rssDownloader.URL;
                    string url = rssList[i];
                    System.Console.WriteLine("Download failed: \"" + url +"\"");
                    continue;
                }

                // Update timestamp
                if (syndicationItemList.Count > 0)
                {
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
                    lastPublishDate[i] = getLatestPublishDate(syndicationItemList);
                }
            }

            if (alertNew && _synthesizer != null)
            {
                List<string> wordList = new List<string>(2);
                List<double> silenceList = new List<double>(2);

                wordList.Add("new");
                silenceList.Add(0.5);
                wordList.Add("alert");
                silenceList.Add(0.5);

                WAVSound sentence = _synthesizer.GenerateWordSequence(wordList, silenceList);

                SoundPlayer soundPlayer = new SoundPlayer();
                sentence.GenerateMemoryStream();
                sentence.WAVMemoryStream.Position = 0; // Manually rewind stream 
                soundPlayer.Stream = null; //TODO varför?
                soundPlayer.Stream = sentence.WAVMemoryStream;
                soundPlayer.Play();
            }
        }

        private DateTimeOffset getLatestPublishDate(List<SyndicationItem> syndicationItemList)
        {
            DateTimeOffset latest = syndicationItemList[0].PublishDate;

            for (int i = 1; i < syndicationItemList.Count; i++)
                if (latest.CompareTo(syndicationItemList[i].PublishDate) < 0)
                    latest = syndicationItemList[i].PublishDate;

            return latest;
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
