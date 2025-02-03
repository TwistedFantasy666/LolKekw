using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task fklo(string asd)
        {
            var words = new Dictionary<string, string>()
            {{"Телеграм", "telegram"},
                {"Telegram", "telegram"},
                {"ВК", "vkontakte"},
                {"Вк","vkontakte" },
                {"Vk","vkontakte" },
                {"VK", "vkontakte"},
                {"VKontakte", "vkontakte"},
                {"Vkontakte", "vkontakte"},
                {"Вконтакте","vkontakte"},
                {"ВKонтакте","vkontakte"},
                {"Discord","discord"},
                {"Дискорд" , "discord"},
                {"YouTube","youtube"},
                {"Youtube","youtube"},
                {"Ютуб","youtube"},
                {"WhatsApp","whatsapp"},
                {"Whatsapp","whatsapp"},
                {"Ватсапп","whatsapp"},
                {"Вацапп","whatsapp"},
                {"Instagram","instagram"},
                {"Инстраграм","instagram"},
                {"Mail.ru","mail-ru"},
                {"Майл.ру","mail-ru"},
                {"Майл ру","mail-ru"},
                {"Одноклассники","odnoklassniki"},
                {"Viber","viber"},
                {"Вайбер","viber"},
                {"Sberbank","sberbank"},
                {"Сбербанк онлайн","sberbank"},
                {"Сбербанк Онлайн","sberbank"},
                {"Сбербанк","sberbank"},
                {"Sberbank online","sberbank"},
                {"Sberbank Online","sberbank"},
                {"Steam","steam"},
                {"Стим","steam"},
                {"TikTok","tiktok"},
                {"Тикток","tiktok"},
                {"ТикТок","tiktok"},
                {"Tiktok","tiktok"},
                {"Госуслуги","gosuslugi"},
                {"Gosuslugi","gosuslugi"},
                {"Т-Банк","tbank"},
                {"T-Bank","tbank"},
                {"Т Банк","tbank"},
            };

            if (!words.TryGetValue(asd, out var sai))
            {
                chart1.Visible = false;
                label3.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
                label2.Text = "Не найдено";
            }
            else
            {
                string url = ($"https://downdetector.su/{sai}");
                label2.Text = url;
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ParseHtml(responseBody);
                }
                else
                {
                    Console.WriteLine($"Ошибка: {response.StatusCode}");
                }
            }
        }
        void ParseHtml(string html)
        { 
        //Капэц
        string asa = "";
        string ass = "";
        string assa = "";
        string h2 = "";
        string lol = "";
        label3.Text = "";
            label1.Text = "";
            chart1.Text = "";
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        document.LoadHtml(html);
            var carNodes = document.DocumentNode.SelectNodes("//span[@class = 'region']"); // Замените XPath на подходящий
        var Nodes = document.DocumentNode.SelectNodes("//label[span]");
        var caNodes = document.DocumentNode.SelectNodes("//span[@class = 'cause']");
        var H2 = document.DocumentNode.SelectSingleNode("/html/body/section[2]/h2").InnerText;
        Series series = new Series();
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisY.Maximum = 70;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            foreach (var ser in chart1.Series)
            {
                series.Points.Clear();
            }
            if (carNodes != null)
            {
                chart1.Visible = true;
                label3.Visible = true;
                label1.Visible = true;
                label4.Visible = true;
                foreach (var Node in H2)
                {
                    label4.Text = H2;
                }
                foreach (var Node in Nodes)
                {
                asa = Node.InnerText;
                label1.Text += asa + "\n";

                }
                label1.Text += "\n";
                for(int i = 0; i < 5; i++)
                {
                    var Node = carNodes[i];
                    var Node1 = Nodes[i];
                    ass = Node.InnerText;
                    ass.TrimEnd('%');
                    string newline = ass.TrimEnd('%');
                    bool s = int.TryParse(newline, out int res);
                    series = chart1.Series.Add(Node1.InnerText);
                    chart1.Series[Node1.InnerText].Points.Add(res);
                }
                foreach (var Node in carNodes)
                {
                  ass = Node.InnerText;
                  label3.Text += ass + "\n";
                }
                label1.Text += "\n";
                foreach (var Node in caNodes)
                {
                    assa = Node.InnerText;
                    label3.Text += assa;
                }

            }
            else
            {
                chart1.Visible = false;
                label4.Visible = false;
                label1.Visible = false;
                label3.Visible = false;
                label2.Text = "Ничего не найдено";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            await fklo(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
