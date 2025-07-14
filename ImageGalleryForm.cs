using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeasonInfoApp
{
    public partial class ImageGalleryForm : Form
    {
        private readonly string imageQuery;
        private static readonly string UnsplashApiKey = ConfigurationManager.AppSettings["UNSPLASH_API_KEY"];


        public ImageGalleryForm(string query)
        {
            InitializeComponent();
            imageQuery = query;

            Load += async (s, e) => await LoadImagesAsync();
        }

        private async Task LoadImagesAsync()
        {
            using (var client = new HttpClient())
            {
                var url = $"https://api.unsplash.com/search/photos?page=1&query={Uri.EscapeDataString(imageQuery)}&per_page=6&client_id={UnsplashApiKey}";

                try
                {
                    var json = await client.GetStringAsync(url);
                    dynamic data = JsonConvert.DeserializeObject(json);

                    foreach (var result in data.results)
                    {
                        string imageUrl = result.urls.small.ToString();
                        var pictureBox = new PictureBox
                        {
                            Width = 200,
                            Height = 150,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Margin = new Padding(10)
                        };

                        using (var imageStream = await client.GetStreamAsync(imageUrl))
                        {
                            pictureBox.Image = Image.FromStream(imageStream);
                        }

                        flowLayoutPanel1.Controls.Add(pictureBox);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("画像の読み込みに失敗しました: " + ex.Message);
                }
            }
        }
    }
}
