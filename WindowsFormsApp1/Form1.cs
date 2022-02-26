using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        int Index,Index2;

        List<string> listBayrak = new List<string>();
        List<string> listDizlis = new List<string>();
        List<int> numberSort = new List<int>();



        public String html;
        public Uri url;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;

            button1.Visible = false;

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = false;

        }


        Bitmap Resim(string Url)
        {
            WebRequest rs = WebRequest.Create(Url);
            return (Bitmap)Bitmap.FromStream(rs.GetResponse().GetResponseStream());
        }
        

        public void Mainn()
        {
            VeriAl3("https://tr.wikipedia.org/wiki/Dosya:4-2-4_formation.svg", "//*[@id='file']/a/img", "src", listDizlis); // 4-2-4

            VeriAl3("https://tr.wikipedia.org/wiki/Dosya:3-2-2-3_formation.svg", "//*[@id='file']/a/img", "src", listDizlis); // 4-2-3-1

            VeriAl3("https://tr.wikipedia.org/wiki/Dosya:Association_football_4-5-1_formation.svg", "//*[@id='file']/a/img", "src", listDizlis); //4-5-1

            for (int i = 1, k = 2, m = 1, t = 1; i < 31; i++, k++)
            {

                if (i == 4) { k = 1; m = 2; }
                else if (i == 8) { k = 1; m = 3; }
                else if (i == 12) { k = 1; m = 1; t = 2; }
                else if (i == 16) { k = 1; m = 2; }
                else if (i == 20) { k = 1; m = 3; }
                else if (i == 24) { k = 1; m = 4; }
                else if (i == 28) { k = 1; m = 5; }

                VeriAl("https://tr.wikipedia.org/wiki/Ülke_bayrakları_listesi", "//*[@id='mw-content-text']/div[1]/table[" + t + "]/tbody/tr[" + m + "]/td[" + k + "]/a[1]", comboBox1);
                VeriAl2("https://tr.wikipedia.org/wiki/Ülke_bayrakları_listesi", "//*[@id='mw-content-text']/div[1]/table[" + t + "]/tbody/tr[" + m + "]/td[" + k + "]/a[2]/img", "src", listBayrak);
               
                progressBar1.Value += 1;


            }

            if(progressBar1.Value < 31)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;

                comboBox1.Visible = true;
                comboBox2.Visible = true;

                button1.Visible = true;

                progressBar1.Visible = false;
                label5.Visible = false;
                button2.Visible = false;
            }
        }



        public void VeriAl(String Url, String xPath, ComboBox CikanSonuc)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { }
            }
            catch (ArgumentNullException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }


            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                comboBox1.Items.Add(doc.DocumentNode.SelectSingleNode(xPath).InnerText);
                
            }
            catch (NullReferenceException) { if (MessageBox.Show("ERROR XPATH", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

        }
        public void VeriAl1(String Url, String xPath, ComboBox CikanSonuc)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { }
            }
            catch (ArgumentNullException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }


            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                comboBox2.Items.Add(doc.DocumentNode.SelectSingleNode(xPath).InnerText);
            }
            catch (NullReferenceException) { if (MessageBox.Show("ERROR XPATH", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

        }
        public void VeriAl2(String Url, String xPath, String dip, List<string> CikanSonuc)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { }
            }
            catch (ArgumentNullException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }


            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                listBayrak.Add(doc.DocumentNode.SelectSingleNode(xPath).Attributes[dip].Value);
            }
            catch (NullReferenceException) { if (MessageBox.Show("ERROR XPATH", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

        }
        public void VeriAl3(String Url, String xPath, String dip, List<string> CikanSonuc)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { }
            }
            catch (ArgumentNullException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }


            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException) { if (MessageBox.Show("ERROR Url", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            try
            {
                listDizlis.Add(doc.DocumentNode.SelectSingleNode(xPath).Attributes[dip].Value);
            }
            catch (NullReferenceException) { if (MessageBox.Show("ERROR XPATH", "Haa", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { } }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Index2 = comboBox1.SelectedIndex;
        }






        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Index = comboBox2.SelectedIndex;

            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;

            if (comboBox2.SelectedIndex == 0)
            {
                button3.Text = "CF";
                button4.Text = "CF";
                button5.Text = "LW";
                button6.Text = "RW";
                button7.Text = "Halfback";
                button8.Text = "Halfback";
                button9.Text = "FB";
                button10.Text = "FB";
                button11.Text = "CB";
                button12.Text = "CB";
                button13.Text = "Keeper";

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                button3.Text = "CF";
                button4.Text = "LW";
                button5.Text = "RW";
                button6.Text = "IF";
                button7.Text = "IF";
                button8.Text = "Halfback";
                button9.Text = "Halfback";
                button10.Text = "FB";
                button11.Text = "FB";
                button12.Text = "FB";
                button13.Text = "Keeper";

            }
            else if (comboBox2.SelectedIndex == 2)
            {
                button3.Text = "CF";
                button4.Text = "SM";
                button5.Text = "SM";
                button6.Text = "CM";
                button7.Text = "CM";
                button8.Text = "CM";
                button9.Text = "FB";
                button10.Text = "FB";
                button11.Text = "CB";
                button12.Text = "CB";
                button13.Text = "Keeper";

            }
        }


        private void Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Mainn();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0
                && textBox5.Text.Length != 0 && textBox6.Text.Length != 0 && textBox7.Text.Length != 0 && textBox8.Text.Length != 0 && textBox9.Text.Length != 0 && textBox10.Text.Length != 0 && textBox11.Text.Length != 0
                && textBox12.Text.Length != 0 && textBox13.Text.Length != 0 && textBox14.Text.Length != 0 && textBox15.Text.Length != 0 && textBox16.Text.Length != 0 && textBox17.Text.Length != 0 && textBox18.Text.Length != 0
                && textBox19.Text.Length != 0 && textBox20.Text.Length != 0 && textBox22.Text.Length != 0 && textBox23.Text.Length != 0)
            {

                numberSort.Add(int.Parse(textBox1.Text));
                numberSort.Add(int.Parse(textBox2.Text));
                numberSort.Add(int.Parse(textBox3.Text));
                numberSort.Add(int.Parse(textBox4.Text));
                numberSort.Add(int.Parse(textBox5.Text));
                numberSort.Add(int.Parse(textBox6.Text));
                numberSort.Add(int.Parse(textBox7.Text));
                numberSort.Add(int.Parse(textBox8.Text));
                numberSort.Add(int.Parse(textBox9.Text));
                numberSort.Add(int.Parse(textBox10.Text));
                numberSort.Add(int.Parse(textBox11.Text));

                numberSort.Sort();



                string num = "";
                var dict = new Dictionary<int, int>();

                foreach (var value in numberSort)
                {
                    if (dict.ContainsKey(value)) dict[value]++;
                    else dict[value] = 1;
                }

                foreach (var pair in dict)
                {
                    if (pair.Value != 1)
                    {
                        num += pair.Key + " ";
                        label6.Visible = true;
                        label6.Text = $"{num} There is recurrence !";
                    }

                }

                if(num == "")
                {
                    Form2 form2 = new Form2();

                    form2.pictureBox1.Image = Resim($@"https:{listDizlis[Index]}");
                    form2.pictureBox2.Image = Resim($@"https:{listBayrak[Index2]}");
                    
                    
                    if(Index == 0)
                    {
                        form2.label1.Text = textBox12.Text;
                        form2.label1.Location = new Point(181, 44);

                        form2.label2.Text = textBox13.Text;
                        form2.label2.Location = new Point(322, 44);

                        form2.label3.Text = textBox14.Text;
                        form2.label3.Location = new Point(59, 73);

                        form2.label4.Text = textBox15.Text;
                        form2.label4.Location = new Point(443, 73);

                        form2.label5.Text = textBox16.Text;
                        form2.label5.Location = new Point(179, 284);

                        form2.label6.Text = textBox17.Text;
                        form2.label6.Location = new Point(330, 284);

                        form2.label7.Text = textBox18.Text;
                        form2.label7.Location = new Point(64, 427);

                        form2.label8.Text = textBox19.Text;
                        form2.label8.Location = new Point(439, 427);

                        form2.label9.Text = textBox20.Text;
                        form2.label9.Location = new Point(183, 445);

                        form2.label10.Text = textBox22.Text;
                        form2.label10.Location = new Point(183, 445);

                        form2.label11.Text = textBox23.Text;
                        form2.label11.Location = new Point(328, 445);

                        /////
                        
                        form2.label12.Text = textBox1.Text;
                        form2.label12.Location = new Point(178, 93);
                        form2.label12.BackColor = Color.Red;

                        form2.label13.Text = textBox2.Text;
                        form2.label13.Location = new Point(322, 93);
                        form2.label13.BackColor = Color.Red;

                        form2.label14.Text = textBox3.Text;
                        form2.label14.Location = new Point(59, 118);
                        form2.label14.BackColor = Color.Red;

                        form2.label15.Text = textBox4.Text;
                        form2.label15.Location = new Point(443, 118);
                        form2.label15.BackColor = Color.Red;

                        form2.label16.Text = textBox5.Text;
                        form2.label16.Location = new Point(178, 329);
                        form2.label16.BackColor = Color.Yellow;

                        form2.label17.Text = textBox6.Text;
                        form2.label17.Location = new Point(328, 329);
                        form2.label17.BackColor = Color.Yellow;

                        form2.label18.Text = textBox7.Text;
                        form2.label18.Location = new Point(61, 477);
                        form2.label18.BackColor = Color.Blue;

                        form2.label19.Text = textBox8.Text;
                        form2.label19.Location = new Point(439, 477);
                        form2.label19.BackColor = Color.Blue;

                        form2.label20.Text = textBox9.Text;
                        form2.label20.Location = new Point(180, 492);
                        form2.label20.BackColor = Color.Blue;

                        form2.label21.Text = textBox10.Text;
                        form2.label21.Location = new Point(327, 492);
                        form2.label21.BackColor = Color.Blue;

                        form2.label22.Text = textBox11.Text;
                        form2.label22.Location = new Point(252, 586);
                        form2.label22.BackColor = Color.Gray;



                    }
                    else if (Index == 1)
                    {

                        form2.label1.Text = textBox12.Text;
                        form2.label1.Location = new Point(249, 21);

                        form2.label2.Text = textBox13.Text;
                        form2.label2.Location = new Point(52, 33);

                        form2.label3.Text = textBox14.Text;
                        form2.label3.Location = new Point(445, 33);

                        form2.label4.Text = textBox15.Text;
                        form2.label4.Location = new Point(152, 155);

                        form2.label5.Text = textBox16.Text;
                        form2.label5.Location = new Point(350, 155);

                        form2.label6.Text = textBox17.Text;
                        form2.label6.Location = new Point(177, 317);

                        form2.label7.Text = textBox18.Text;
                        form2.label7.Location = new Point(330, 317);

                        form2.label8.Text = textBox19.Text;
                        form2.label8.Location = new Point(101, 445);

                        form2.label9.Text = textBox20.Text;
                        form2.label9.Location = new Point(255, 445);

                        form2.label10.Text = textBox22.Text;
                        form2.label10.Location = new Point(404, 445);

                        form2.label11.Text = textBox23.Text;
                        form2.label11.Location = new Point(252, 623);

                        /////

                        form2.label12.Text = textBox1.Text;
                        form2.label12.Location = new Point(249, 66);
                        form2.label12.BackColor = Color.Red;

                        form2.label13.Text = textBox2.Text;
                        form2.label13.Location = new Point(52, 83);
                        form2.label13.BackColor = Color.Red;

                        form2.label14.Text = textBox3.Text;
                        form2.label14.Location = new Point(445, 83);
                        form2.label14.BackColor = Color.Red;

                        form2.label15.Text = textBox4.Text;
                        form2.label15.Location = new Point(152, 204);
                        form2.label15.BackColor = Color.Red;

                        form2.label16.Text = textBox5.Text;
                        form2.label16.Location = new Point(350, 204);
                        form2.label16.BackColor = Color.Red;

                        form2.label17.Text = textBox6.Text;
                        form2.label17.Location = new Point(177, 365);
                        form2.label17.BackColor = Color.Yellow;

                        form2.label18.Text = textBox7.Text;
                        form2.label18.Location = new Point(327, 365);
                        form2.label18.BackColor = Color.Yellow;

                        form2.label19.Text = textBox8.Text;
                        form2.label19.Location = new Point(98, 492);
                        form2.label19.BackColor = Color.Blue;

                        form2.label20.Text = textBox9.Text;
                        form2.label20.Location = new Point(252, 492);
                        form2.label20.BackColor = Color.Blue;

                        form2.label21.Text = textBox10.Text;
                        form2.label21.Location = new Point(404, 492);
                        form2.label21.BackColor = Color.Blue;

                        form2.label22.Text = textBox11.Text;
                        form2.label22.Location = new Point(252, 586);
                        form2.label22.BackColor = Color.Gray;

                    }
                    else if (Index == 2)
                    {
                        form2.label1.Text = textBox12.Text;
                        form2.label1.Location = new Point(258, 30);

                        form2.label2.Text = textBox13.Text;
                        form2.label2.Location = new Point(69, 173);

                        form2.label3.Text = textBox14.Text;
                        form2.label3.Location = new Point(442, 163);

                        form2.label4.Text = textBox15.Text;
                        form2.label4.Location = new Point(155, 268);

                        form2.label5.Text = textBox16.Text;
                        form2.label5.Location = new Point(359, 268);

                        form2.label6.Text = textBox17.Text;
                        form2.label6.Location = new Point(255, 330);

                        form2.label7.Text = textBox18.Text;
                        form2.label7.Location = new Point(72, 418);

                        form2.label8.Text = textBox19.Text;
                        form2.label8.Location = new Point(442, 419);

                        form2.label9.Text = textBox20.Text;
                        form2.label9.Location = new Point(184, 459);

                        form2.label10.Text = textBox22.Text;
                        form2.label10.Location = new Point(329, 459);

                        form2.label11.Text = textBox23.Text;
                        form2.label11.Location = new Point(258, 565);

                        /////

                        form2.label12.Text = textBox1.Text;
                        form2.label12.Location = new Point(255, 83);

                        form2.label13.Text = textBox2.Text;
                        form2.label13.Location = new Point(69, 223);

                        form2.label14.Text = textBox3.Text;
                        form2.label14.Location = new Point(442, 213);

                        form2.label15.Text = textBox4.Text;
                        form2.label15.Location = new Point(155, 317);

                        form2.label16.Text = textBox5.Text;
                        form2.label16.Location = new Point(359, 317);

                        form2.label17.Text = textBox6.Text;
                        form2.label17.Location = new Point(255, 378);

                        form2.label18.Text = textBox7.Text;
                        form2.label18.Location = new Point(69, 466);

                        form2.label19.Text = textBox8.Text;
                        form2.label19.Location = new Point(442, 466);

                        form2.label20.Text = textBox9.Text;
                        form2.label20.Location = new Point(181, 506);

                        form2.label21.Text = textBox10.Text;
                        form2.label21.Location = new Point(329, 506);

                        form2.label22.Text = textBox11.Text;
                        form2.label22.Location = new Point(258, 607);
                    }

                    form2.Show();
                    Hide();
                }
                


                numberSort.Clear();

                

            }

            else
            {
                label6.Visible = true;
            }

        }
    }
}
