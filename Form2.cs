using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MORSE
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            loadd(Lang.RU);
        }

        private enum Lang
        {
            RU,
            EN,
            NUM
        }

        void loadd(Lang lang)
        {
            listBox1.Items.Clear();
            var dict = new Dictionary<char, string>();
            switch (lang)
            {
                case Lang.RU:
                    dict = MorseCode.MorseCode.ru;
                    break;
                case Lang.EN:
                    dict = MorseCode.MorseCode.en;
                    break;
                case Lang.NUM:
                    dict = MorseCode.MorseCode.intl;
                    break;
            }
            foreach(var i in dict)
            {
                listBox1.Items.Add(i.Key + "   " + i.Value);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lang lang = (Lang)Enum.Parse(typeof(Lang), comboBox1.Text);
            loadd(lang);
           
        }

        public void listBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            Form f1 = new Form();
            ((Form1)this.Owner).richTextBox1.Text += listBox1.SelectedItem.ToString()[0];
            listBox1.SelectedIndex = -1;
        }
    }
}
