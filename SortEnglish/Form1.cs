using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SortEnglish
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ソースリストの読み込んだ英文テキストファイル
        /// </summary>
        private List<string> InputEngSentence = new List<string>();

        /// <summary>
        /// ソースリストの読み込んだ和訳テキストファイル
        /// </summary>
        private List<string> InputJapSentence = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private List<string> InputNumbers = new List<string>();

        /// <summary>
        /// 各入力文(List)を空白ごとに区切った(Array)、リスト配列
        /// </summary>
        private List<List<string>> words;

        /// <summary>
        /// 各回答文リスト
        /// </summary>
        private List<string> Ansers;

        /// <summary>
        /// 各問題文リスト
        /// </summary>
        private List<string> Questions;

        /// <summary>
        /// 各文に対応した句読点(.!?)
        /// </summary>
        private List<string> endS;

        /// <summary>
        /// 読み込んだ英文の数
        /// </summary>
        private int EngLength = 0;

        /// <summary>
        /// 読み込んだ和訳の数
        /// </summary>
        private int JapLength = 0;

        /// <summary>
        /// 読み込んだ番号の数
        /// </summary>
        private int NumLength = 0;

        /// <summary>
        /// フォームのメイン
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> GetTextToFile(string title)
        {
            List<string> list = new List<string>();
            string name, line;

            FileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "*.txt",
                Filter = "テキストファイル|*.txt|すべてのファイル|*.*",
                Title = title,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = dialog.FileName;
                StreamReader file = new StreamReader(name);
                while ((line = file.ReadLine()) != null && line.Length != 0)
                {
                    list.Add(line);
                }
            }

            return list;
        }

        /// <summary>
        /// 入力されたテキストファイルを問題を回答に分ける
        /// </summary>
        private void inputS()
        {
            words = new List<List<string>>();
            string anser = "";

            for(int i = 0;i < EngLength;i++)
            {
                words.Add(new List<string>());
                anser = "";

                words[i].AddRange(InputEngSentence[i].Split(' '));

                anser += "A." + (i + 1).ToString() + " ";

                for(int j = 0;j < words[i].Count;j++)
                    words[i][j] = words[i][j].Replace('^', ' ');

                string inputword = words[i][0];
                words[i][0] = words[i][0].Substring(0, 1).ToUpper() + words[i][0].Substring(1); //大文字にする

                for (int j = 0; j < words[i].Count; j++)
                {
                    if (words[i][j].IndexOf("[") >= 0)
                    {
                        anser += words[i][j + 1];
                        words[i].Remove(words[i][j + 1]);
                    }
                    else anser += words[i][j];
                    if (j == words[i].Count - 1) anser += endS[i];
                    else anser += " ";
                }

                Ansers.Add(anser);

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

            for (int i = 0; i < words.Count; i++)
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
        /// キー入力に応じて各イベントを発生させる
        /// </summary>
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキーが押されたらプログラムを終了する
            if (e.KeyData == Keys.Escape)
                this.Close();

            if (e.KeyData == Keys.Delete)
                ClearAll();
        }

        /// <summary>
        /// 作成した問題と解答をテキストファイルとして出力する
        /// 問題と解答を合わせてとそれぞれわけての合計3つのファイルを出力する
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (JapLength == 0)
                MessageBox.Show("和訳が読み込まれていません。");
            else if (EngLength == 0)
                MessageBox.Show("英文が読み込まれていません。");
            else if (NumLength == 0)
                MessageBox.Show("番号が読み込まれていません。");
            else if (EngLength != JapLength)
                MessageBox.Show("英文と和訳の数が一致していません。\r\n取得に失敗している場合があります。");
            else if (NumLength != EngLength)
                MessageBox.Show("読み込まれた番号の数が文章の数と一致しません");
            else
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
                    for (int i = 0; i < Questions.Count; i++)
                    {
                        writer.WriteLine(InputNumbers[i] + " " + InputJapSentence[i]);
                        writer.WriteLine(Questions[i]);
                        writer.WriteLine();

                        Questionwriter.WriteLine(InputJapSentence[i]);
                        Questionwriter.WriteLine(Questions[i]);
                        Questionwriter.WriteLine();
                    }

                    writer.WriteLine();

                    foreach (string A in Ansers)
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
        }

        /// <summary>
        /// 問題と解答をすべて初期化する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        /// <summary>
        /// 全てを削除する
        /// </summary>
        private void ClearAll()
        {
            DialogResult result = MessageBox.Show("本当に削除しますか？", "確認",
                 MessageBoxButtons.YesNoCancel,
                 MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                QuestionListBox.Items.Clear();
                AnserListBox.Items.Clear();
                JapListBox.Items.Clear();

                words.Clear();
                InputEngSentence.Clear();
                Questions.Clear();
                Ansers.Clear();
                endS.Clear();

                EngLength = 0;

                QuestionListBox.Refresh();
            }
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

        /// <summary>
        /// 英文ファイルを開いてその内容を問題と解答にする
        /// </summary>
        private void EngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputEngSentence = GetTextToFile("英文テキストを開く");

            EngLength = InputEngSentence.Count;

            MessageBox.Show(EngLength + "の文章を追加しました");

            //文末の[. ? !]を保管しておく
            endS = new List<string>();

            for (int i = 0; i < EngLength; i++)
            {
                if (InputEngSentence[i].IndexOf(".") != -1) endS.Add(".");
                else if (InputEngSentence[i].IndexOf("?") != -1) endS.Add("?");
                else endS.Add("!");

                int l = InputEngSentence[i].Length;
                InputEngSentence[i] = InputEngSentence[i].Remove(l - 1);
            }

            Ansers = new List<string>();
            Questions = new List<string>();

            // 入力されたテキストから問題と解答を取得
            inputS();

            // 問題文をランダムに並び替える
            Sorting();

            // 回答分を追加
            string question;
            for (int i = 0; i < EngLength; i++)
            {
                question = "";
                question += "     【 ";
                for (int j = 0; j < words[i].Count; j++)
                {
                    question += (words[i][j]);
                    if (j == words[i].Count - 1) question += " 】" + endS[i];
                    else question += " / ";
                }

                // 問題文取得が失敗していた場合、その文を表示する
                if (question.IndexOf('^') >= 0) MessageBox.Show("error\n" + question);
                if (Ansers[i].IndexOf('^') >= 0) MessageBox.Show("error\n" + Ansers[i]);

                Questions.Add(question);
            }

            // 取得した問題文回答分をフォームに表示
            //QuestionListBox.Items.Insert(0, "Question Count : " + length);
            AnserListBox.Items.AddRange(Ansers.ToArray()); //答えの文 

            QuestionListBox.Items.AddRange(Questions.ToArray()); //問題の文 
        }

        private void JapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputJapSentence = GetTextToFile("和訳テキストを開く");

            JapLength = InputJapSentence.Count;

            MessageBox.Show(JapLength + "の文章を追加しました");

            // リストボックスに追加
            JapListBox.Items.AddRange(InputJapSentence.ToArray());
        }

        private void NumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputNumbers = GetTextToFile("番号テキストを開く");

            NumLength = InputNumbers.Count;
            MessageBox.Show(NumLength + "個の番号を追加しました");
        }
    }
}
