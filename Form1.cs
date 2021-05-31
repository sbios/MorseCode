using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MorseCode.MorseCode;
using System.Diagnostics;

namespace MORSE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1 getform1()
        {
            return this;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((!comboBox1.Items.Contains(comboBox1.Text)) || (!comboBox2.Items.Contains(comboBox2.Text)))
            {
                MessageBox.Show("Выберите язык из списка", "Ошибка");
                return;
            }
            if (comboBox1.Text==comboBox2.Text)
            {
                MessageBox.Show("Языки не должны совпадать", "Ошибка");
                return;
            }
            if ((comboBox1.Text=="RU" && comboBox2.Text=="EN") || (comboBox2.Text == "RU" && comboBox1.Text == "EN"))
            {
                MessageBox.Show("Мы не Яндекс переводчик :(", "Ошибка");
                return;
            }
            
            if (comboBox1.Text == "Morse")
            {
                Lang lang = (Lang)Enum.Parse(typeof(Lang), comboBox2.Text);
              
                richTextBox2.Text = MorseCode.MorseCode.toNormal(richTextBox1.Text, lang);
            }
            else if (comboBox2.Text == "Morse")
            {
                Lang lang = (Lang)Enum.Parse(typeof(Lang), comboBox1.Text);
                
                Regex rgx = new Regex("[^a-zA-Z0-9 ]");
                if (lang == MorseCode.MorseCode.Lang.RU)
                {
                    rgx = new Regex("[^а-яА-Я0-9 ]");
                }
                string temp = rgx.Replace(richTextBox1.Text, "");
                richTextBox2.Text = MorseCode.MorseCode.toMorse(temp, lang);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "text file|*.txt";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox2.Text);
                }
            }
            else MessageBox.Show("Поле не должно быть пустым", "Ошибка");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length > 0)
            {
                string textData = richTextBox2.Text;
                Clipboard.SetData(DataFormats.Text, (Object)textData);
            }
            else MessageBox.Show("В данном поле нечего копировать", "Ошибка");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = "";
            string temp = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text = temp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|.jpg|Bitmap Image|.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox2.Text);
                }
            }
            else MessageBox.Show("Поле не должно быть пустым", "Ошибка");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Owner = this;
            newForm.Show();
            

        }
    }
}
