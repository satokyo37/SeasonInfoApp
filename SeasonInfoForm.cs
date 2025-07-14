using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeasonInfoApp {
    public partial class SeasonInfoForm : Form
    {
        private static readonly string OpenAIApiKey = ConfigurationManager.AppSettings["OpenAI_API_KEY"];
        private static readonly HttpClient httpClient = new HttpClient();

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
        }

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            textBox1.Text = "生成中・・・";

            string country = comboBoxCountry.SelectedItem?.ToString();
            string monthStr = comboBoxMonth.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(monthStr))
            {
                textBox1.Text = "";
                MessageBox.Show("国名と月を選択してください。");
                return;
            }

            int month = int.Parse(monthStr.Replace("月", ""));

            string prompt = GeneratePrompt(country, month);

            string gptAnswer = await CallOpenAI(prompt);

            string imageQuery = $"{country} {month} travel, city, street, culture, tourist attractions, festival, local people";

            ImageGalleryForm galleryForm = new ImageGalleryForm(imageQuery);
            galleryForm.Show();

            textBox1.Text = gptAnswer.Replace("\n", Environment.NewLine);
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
                httpClient.DefaultRequestHeaders.Remove("Authorization");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {OpenAIApiKey}");

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

                var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
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
    }
}
