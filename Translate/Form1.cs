using System;
using System.Windows.Forms;
using Google.Cloud.Translation.V2;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;


namespace Translate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var credential = GoogleCredential.FromFile(@"PATH to API credentials");
            var storage = StorageClient.Create(credential);
            // Make an authenticated API request.
            var buckets = storage.ListBuckets("name of API credentials file");
            foreach (var bucket in buckets)
            {
                Console.WriteLine(bucket.Name);
            }
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"Path to API credentials");
            
            TranslationClient client = TranslationClient.Create();
            TranslationResult result = client.TranslateText(textBox1.Text, comboBox2.Text);
            //                                     ^ text to be translated     ^ Language the text needs to be translated into
            textBox2.Text = result.TranslatedText;
            comboBox1.Text = result.DetectedSourceLanguage;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text = textBox3.Text;
        }
    }
}
