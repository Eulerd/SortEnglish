﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SortEnglish
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ソースリストの読み込んだテキストファイル
        /// </summary>
        private List<string> InputSentence = new List<string>();

        /// <summary>
        /// 各入力文(List)を空白ごとに区切った(Array)、リスト配列
        /// </summary>
        private List<string>[] words;

        /// <summary>
        /// 各回答文リスト
        /// </summary>
        private string[] Ansers;

        /// <summary>
        /// 各問題文リスト
        /// </summary>
        private string[] Questions;

        /// <summary>
        /// 各文に対応した句読点(.!?)
        /// </summary>
        private string[] endS;

        /// <summary>
        /// 読み込んだ文の数
        /// </summary>
        private int length;

        /// <summary>
        /// フォームのメイン
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ファイルを開いてその内容を問題と解答にする
        /// </summary>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name, line;

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
                while ((line = file.ReadLine()) != null && line.Length != 0)
                {
                    InputSentence.Add(line);
                }
                MessageBox.Show(InputSentence.Count + "の文章を追加しました");
            }
            length = InputSentence.Count;
            //文末の[. ? !]を保管しておく
            endS = new string[length];

            for (int i = 0; i < length; i++)
            {
                if (InputSentence[i].IndexOf(".") != -1) endS[i] = ".";
                else if (InputSentence[i].IndexOf("?") != -1) endS[i] = "?";
                else endS[i] = "!";

                int l = InputSentence[i].Length;
                InputSentence[i] = InputSentence[i].Remove(l - 1);
            }

            Ansers = new string[length];
            Questions = new string[length];

            // 入力されたテキストから問題と解答を取得
            inputS();

            // 問題文をランダムに並び替える
            Sorting();

            // 回答分を追加
            for (int i = 0; i < length; i++)
            {
                Questions[i] += "Q." + (i + 1).ToString() + " 【 ";
                for (int j = 0; j < words[i].Count; j++)
                {
                    Questions[i] += (words[i][j]);
                    if (j == words[i].Count - 1) Questions[i] += " 】" + endS[i];
                    else Questions[i] += " / ";
                }
                
                // 問題文取得が失敗していた場合、その文を表示する
                if (Questions[i].IndexOf('^') >= 0) MessageBox.Show("error\n" + Questions[i]);
                if (Ansers[i].IndexOf('^') >= 0) MessageBox.Show("error\n" + Ansers[i]);
            }

            // 取得した問題文回答分をフォームに表示
            listBox1.Items.Insert(0, "Question Count : " + length);
            listBox1.Items.Add("---ANSERS---");
            listBox1.Items.AddRange(Ansers); //答えの文 
            listBox1.Items.Add("---QUESTIONS---");
            listBox1.Items.AddRange(Questions); //問題の文 
        }

        /// <summary>
        /// 入力されたテキストファイルを問題を回答に分ける
        /// </summary>
        private void inputS()
        {
            words = new List<string>[length];

            for(int i = 0;i < length;i++)
            {
                words[i] = new List<string>();
                words[i].AddRange(InputSentence[i].Split(' '));

                Ansers[i] += "A." + (i + 1).ToString() + " ";

                for(int j = 0;j < words[i].Count;j++)
                    words[i][j] = words[i][j].Replace('^', ' ');

                string inputword = words[i][0];
                words[i][0] = words[i][0].Substring(0, 1).ToUpper() + words[i][0].Substring(1); //大文字にする

                for (int j = 0; j < words[i].Count; j++)
                {
                    if (words[i][j].IndexOf("[") >= 0)
                    {
                        Ansers[i] += words[i][j + 1];
                        words[i].Remove(words[i][j + 1]);
                    }
                    else Ansers[i] += words[i][j];
                    if (j == words[i].Count - 1) Ansers[i] += endS[i];
                    else Ansers[i] += " ";
                }

                words[i][0] = inputword; //元に戻す
            }
        }


        /// <summary>
        /// 問題を単語の数回ランダムに並び替える
        /// </summary>
        private void Sorting()
        {
            Random r;
            int num1, num2;

            for (int i = 0; i < words.Length; i++)
            {
                int l = words[i].Count;

                Swap(0, l - 2, i);
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
        }


        /// <summary>
        /// 配列内の単語を交換する
        /// </summary>
        /// <param name="num1">交換したい単語(一つ目)</param>
        /// <param name="num2">交換したい単語(二つ目)</param>
        /// <param name="i">何文目</param>
        private void Swap(int num1, int num2,int i)
        {
            string word = words[i][num1];
            words[i][num1] = words[i][num2];
            words[i][num2] = word;
        }


        /// <summary>
        /// ESCキーが押されたらプログラムを終了する
        /// </summary>
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) this.Close();
        }

        /// <summary>
        /// 作成した問題と解答をテキストファイルとして出力する
        /// 問題と解答を合わせてとそれぞれわけての合計3つのファイルを出力する
        /// </summary>
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
                // -4は".txt"分戻すため
                string Aname = dialog.FileName.Insert(dialog.FileName.Length - 4, "-Anser");
                string Qname = dialog.FileName.Insert(dialog.FileName.Length - 4, "-Question");

                StreamWriter Anserwriter
                    = new StreamWriter(Aname, false, Encoding.GetEncoding("UTF-8"));
                StreamWriter Questionwriter
                    = new StreamWriter(Qname, false, Encoding.GetEncoding("UTF-8"));
                StreamWriter writer 
                    = new StreamWriter(dialog.FileName, false, Encoding.GetEncoding("UTF-8"));
                foreach (string Q in Questions)
                {
                    writer.WriteLine(Q);
                    Questionwriter.WriteLine(Q);
                }

                writer.WriteLine();

                foreach(string A in Ansers)
                {
                    writer.WriteLine(A);
                    Anserwriter.WriteLine(A);
                }

                writer.Close();
                Questionwriter.Close();
                Anserwriter.Close();
                MessageBox.Show("保存しました");
            }
        }

        /// <summary>
        /// 問題と解答をすべて初期化する(未実装)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            InputSentence.Clear();
        }

        /// <summary>
        /// プログラムを終了する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
