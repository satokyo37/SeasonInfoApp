using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeasonInfoApp {
    public partial class SeasonInfoForm : Form
    {
        private static readonly string OpenAIApiKey = ConfigurationManager.AppSettings["OpenAI_API_KEY"];
        private static readonly string UnsplashApiKey = ConfigurationManager.AppSettings["UNSPLASH_API_KEY"];

        private static readonly HttpClient openAIClient = new HttpClient();
        private static readonly HttpClient unsplashClient = new HttpClient();

        private readonly string[] countries = new string[]
        {
            "アイスランド", "アイルランド", "アゼルバイジャン", "アフガニスタン", "アメリカ", "アラブ首長国連邦", "アルジェリア", "アルゼンチン", "アルバニア", "アルメニア", "アンゴラ", "アンティグア・バーブーダ", "アンドラ", "イエメン", "イスラエル", "イタリア", "イラク", "イラン", "インド", "インドネシア", "ウガンダ", "ウクライナ", "ウズベキスタン", "ウルグアイ", "エクアドル", "エジプト", "エストニア", "エスワティニ", "エチオピア", "エリトリア", "エルサルバドル", "オーストラリア", "オーストリア", "オマーン", "オランダ", "ガーナ", "ガーボヴェルデ", "ガイアナ", "カザフスタン", "カタール", "カナダ", "ガボン", "カメルーン", "ガンビア", "カンボジア", "北マケドニア", "ギニアビサウ", "ギニア", "キプロス", "キューバ", "ギリシャ", "キリバス", "キルギス", "グアテマラ", "クウェート", "クック諸島", "イギリス", "グレナダ", "クロアチア", "ケニア", "コートジボワール", "コスタリカ", "コモロ", "コロンビア", "コンゴ共和国", "コンゴ民主共和国", "サウジアラビア", "サモア", "サントメ・プリンシペ", "ザンビア", "サンマリノ", "シエラレオネ", "ジブチ", "ジャマイカ", "ジョージア", "シリア", "シンガポール", "ジンバブエ", "スイス", "スウェーデン", "スーダン", "スペイン", "スリナム", "スリランカ", "スロバキア", "スロベニア", "セーシェル", "赤道ギニア", "セネガル", "セルビア", "セントクリストファー・ネーヴィス", "セントビンセントおよびグレナディーン諸島", "セントルシア", "ソマリア", "ソロモン", "タイ", "韓国", "タジキスタン", "タンザニア", "チェコ", "チャド", "中央アフリカ", "中国", "チュニジア", "チリ", "ツバル", "デンマーク", "ドイツ", "トーゴ", "ドミニカ共和国", "ドミニカ国", "トリニダード・トバゴ", "トルクメニスタン", "トルコ", "トンガ", "ナイジェリア", "ナウル", "ナミビア", "ニウエ", "ニカラグア", "ニジェール", "日本", "ニュージーランド", "ネパール", "ノルウェー", "バーレーン", "ハイチ", "パキスタン", "バチカン", "パナマ", "バヌアツ", "バハマ", "パプアニューギニア", "パラオ", "パラグアイ", "バルバドス", "ハンガリー", "バングラデシュ", "東ティモール", "フィジー", "フィリピン", "フィンランド", "ブータン", "ブラジル", "フランス", "ブルガリア", "ブルキナファソ", "ブルネイ", "ブルンジ", "ベトナム", "ベナン", "ベネズエラ", "ベラルーシ", "ベリーズ", "ペルー", "ベルギー", "ポーランド", "ボスニア・ヘルツェゴヴィナ", "ボツワナ", "ボリビア", "ポルトガル", "ホンジュラス", "マーシャル諸島", "マダガスカル", "マラウイ", "マリ", "マルタ", "マレーシア", "ミクロネシア", "南アフリカ", "南スーダン", "ミャンマー", "メキシコ", "モーリシャス", "モーリタニア", "モザンビーク", "モナコ", "モルディブ", "モルドバ", "モロッコ", "モンゴル", "モンテネグロ", "ヨルダン", "ラオス", "ラトビア", "リトアニア", "リビア", "リヒテンシュタイン", "リベリア", "ルーマニア", "ルクセンブルク", "ルワンダ", "レソト", "レバノン", "ロシア"
        };

        public SeasonInfoForm()
        {
            InitializeComponent();
        }

        private void SeasonInfoForm_Load(object sender, EventArgs e)
        {
            comboBoxCountry.Items.AddRange(countries);
            comboBoxMonth.Items.AddRange(Enumerable.Range(1, 12).Select(m => m + "月").ToArray());

            comboBoxCountry.SelectedItem = comboBoxCountry.Items[0];
            comboBoxMonth.SelectedItem = comboBoxMonth.Items[0];

            if (!openAIClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                openAIClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", OpenAIApiKey);
            }

            labelCountry.BackColor = Color.Transparent;
            labelCountry.Parent = pictureBoxBackground;

            labelMonth.BackColor = Color.Transparent;
            labelMonth.Parent = pictureBoxBackground;

            flowLayoutPanelImages.BackColor = Color.Transparent;
            flowLayoutPanelImages.Parent = pictureBoxBackground;

            labelUnsplash.BackColor = Color.Transparent;
            labelUnsplash.Parent = pictureBoxBackground;
        }

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            buttonConfirm.Text = "実行中・・・";
            buttonConfirm.BackColor = Color.LightGray;
            buttonConfirm.ForeColor = Color.Black;
            buttonConfirm.Enabled = false;

            string country = comboBoxCountry.SelectedItem?.ToString();
            string monthStr = comboBoxMonth.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(monthStr))
            {
                MessageBox.Show("国名と月を選択してください。");
                return;
            }

            int month = int.Parse(monthStr.Replace("月", ""));

            try
            {
                string prompt = GeneratePrompt(country, month);
                string gptAnswer = await CallOpenAI(prompt);
                textBoxOutput.Text = gptAnswer.Replace("\n", Environment.NewLine);

                string imageQuery = $"{country} {month} travel, city, street, culture, tourist attractions, festival, local people";
                await LoadImagesToFlowPanel(imageQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonConfirm.Text = "実行";
                buttonConfirm.Enabled = true;
            }
        }

        private string GeneratePrompt(string country, int month)
        {
            if (country == "日本")
            {
                return $"日本の{month}は、どのような季節ですか？" +
                       "以下の6つの観点に沿って説明してください。ただし、各項目の番号や見出し（【○○】）は表示せず、自然な文章として書いてください。それぞれの観点ごとに「・」を使った箇条書きにしてください：" +
                       "【季節の種類】（例：冬、夏など）" +
                       "【平均気温】" +
                       "【天候の特徴】" +
                       "【自然の様子】" +
                       "【文化的イベントや祝日】" +
                       "【服装の目安】";
            }
            else
            {
                return $"{country}の{month}月は、どのような季節ですか？" +
                       "以下の7つの観点に沿って説明してください。ただし、各項目の番号や見出し（【○○】）は表示せず、自然な文章として書いてください。それぞれの観点ごとに「・」を使った箇条書きにしてください：" +
                       "【季節の種類】（例：冬、夏など）" +
                       "【平均気温】" +
                       "【天候の特徴】" +
                       "【自然の様子】" +
                       "【文化的イベントや祝日】" +
                       "【服装の目安】" +
                       "【日本で例えると何月頃か（あれば）】" +
                       "日本人がイメージしやすいように、やさしく丁寧に教えてください。";
            }
        }

        private async Task<string> CallOpenAI(string prompt)
        {
            try
            {
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[] {
                        new { role = "user", content = prompt }
                    },
                    temperature = 0.7,
                    max_tokens = 1000
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await openAIClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                string responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);
                return result.choices[0].message.content.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ChatGPT APIの呼び出し中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "エラーが発生しました。もう一度お試しください。";
            }
        }

        private async Task LoadImagesToFlowPanel(string imageQuery)
        {
            try
            {
                if (string.IsNullOrEmpty(UnsplashApiKey))
                {
                    MessageBox.Show("Unsplash APIキーが設定されていません。App.config を確認してください。");
                    return;
                }

                string apiUrl = $"https://api.unsplash.com/search/photos?query={Uri.EscapeDataString(imageQuery)}&per_page=6&client_id={UnsplashApiKey}";

                var response = await unsplashClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseString);
                flowLayoutPanelImages.Controls.Clear();

                foreach (var photo in result.results)
                {
                    string imageUrl = photo.urls.small.ToString();
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(160, 100);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;

                    using (var imgStream = await unsplashClient.GetStreamAsync(imageUrl))
                    {
                        pic.Image = Image.FromStream(imgStream);
                    }

                    flowLayoutPanelImages.Controls.Add(pic);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("画像の取得中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
