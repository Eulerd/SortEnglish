using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SortEnglish
{
    public partial class Form1 : Form
    {
        private List<string> InputSentence = new List<string>();
        private string[][] words;
        private string[] Ansers;
        private string[] Questions;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name,line;

            FileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = "英文テキストを開く",
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = dialog.FileName;
                StreamReader file = new StreamReader(name);
                while ((line = file.ReadLine()) != null)
                {
                    InputSentence.Add(line);
                }
            }

            int length = InputSentence.Count;

            words = new string[length][];
            Ansers = new string[length];
            Questions = new string[length];
            for (int i = 0; i < length; i++)
            {
                words[i] = InputSentence[i].Split(' ');
                Ansers[i] += "A." + (i + 1).ToString() + " ";
                for (int j = 0; j < words[i].Length; j++)
                {
                    words[i][j] = words[i][j].Replace('^', ' ');
                    if (words[i][j].IndexOf('\'') >= 0) j++;
                    Ansers[i] += (words[i][j] + " ");
                }
            }

            Random r;
            int num1, num2;
            listBox1.Items.Add("question count : " + words.Length);
            for (int i = 0; i < words.Length; i++)
            {
                int l = words[i].Length;
                Swap(0, l - 2,i);
                for (int j = 0; j < l; j++)
                {
                    r = new Random(j);
                    num1 = r.Next(l);
                    r = new Random(i + num1 % (l - j));

                    do num2 = r.Next(l);
                    while (num1 == num2);

                    Swap(num1, num2, i);
                }
            }


            for (int i = 0; i < length; i++)
            {
                Questions[i] += "Q." + (i + 1).ToString() + " (/ ";
                for (int j = 0; j < words[i].Length; j++)
                {
                    Questions[i] += (words[i][j] + " / ");
                    if (words[i][j].IndexOf('\'') >= 0) j++;
                }
                Questions[i] += ")";
            }

            listBox1.Items.Add("---ANSERS---");
            listBox1.Items.AddRange(Ansers); //答えの文
            listBox1.Items.Add("---QUESTIONS---");
            listBox1.Items.AddRange(Questions); //問題の文
        }

        private void Swap(int num1, int num2,int i)
        {
            string word = words[i][num1];
            words[i][num1] = words[i][num2];
            words[i][num2] = word;
        }



        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) this.Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                FileName = "Problem",
                Title = "英文並び替え問題を保存",
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer 
                    = new StreamWriter(dialog.FileName, true, Encoding.GetEncoding("UTF-8"));
                for (int i = 0; i < Questions.Length; i++)
                    writer.WriteLine(Questions[i]);
                writer.WriteLine();
                for (int i = 0; i < Ansers.Length; i++)
                    writer.WriteLine(Ansers[i]);
                writer.Close();
                MessageBox.Show("保存しました");
            }
        }
    }
}
