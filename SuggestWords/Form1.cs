using System.Text;
using Accessibility;
using SuggestWords.MyButtons;

namespace SuggestWords
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        private int value, countAnswers = 0, sbThink = 0, countAnswersToDef = 0, middleNum = 0;
        bool starting = false, checkRandom = false;
        StringBuilder sb = new StringBuilder();
        Dictionary<int, object> _defMiddle = new();

        Dictionary<int, Color> _randomColors;
        Dictionary<int, Color> _randomBackColors;
        Dictionary<int, Color> _randomDisabledColors;

        Dictionary<int, Button> _buttonList;
        Dictionary<int, Button> _buttonDisabledList;

        List<string> words = new List<string>() {"скоморох", "рыцарь", "король", "замок", "дракон", "дамба", "принцесса", "принц", "полицейский", "доктор", "алхимик", "волшебник",
            "бессмертие", "ребёнок", "вода", "камень", "корова", "институт", "противник", "девушка", "ловушка", "преступление", "божество", "средневековье", "школа", "озеро", "море",
            "океан", "долина", "кровать", "ворона", "медведь", "кристалл", "посёлок", "город", "страна", "континент", "планета", "желание", "рыба", "предатель", "подчинённый",
            "искусство", "красота", "язык", "корона", "доблесть", "деревня", "поселение", "переправа", "рыболовство", "кузнец", "доспехи", "жемчуг", "заговор", "воровство", "страдание",
            "наказание", "филин", "шоколад", "лекарство", "болезнь", "гонец", "придворный", "свадьба", "дворец", "крепость", "мечник", "лучник", "защитник", "страж", "часовой", "стрела",
            "хозяин", "раб", "рабство", "поклонник", "священник", "богохульство", "жаба", "олень", "кабан", "лось", "волк", "собака", "кошка", "хранитель", "дворецкий"};

        public Form1()
        {
            InitializeComponent();

            thinkButton.Enabled = false;
            countAnswers = Properties.Settings.Default.countAnswersFinal;
            countAnswersToDef = Properties.Settings.Default.answersToDef;

            answerTextBox.Visible = false;
            thinkLabel.Text = countAnswersToDef.ToString() + "/" + "5";
            answeredWordsLabel.Text = "Слов отгадано: " + countAnswers.ToString();
            _buttonList = new Dictionary<int, Button>()
            {
                {1, buttonConstructor1 },
                { 2, buttonConstructor2 },
                { 3, buttonConstructor3 },
                { 4, buttonConstructor4 },
                { 5, buttonConstructor5 },
                { 6, buttonConstructor6 },
                { 7, buttonConstructor7 },
                { 8, buttonConstructor8 },
                { 9, buttonConstructor9 },
                { 10, buttonConstructor10 },
                { 11, buttonConstructor11 },
                { 12, buttonConstructor12 },
                { 13, buttonConstructor13 },
                { 14, buttonConstructor14 },
                { 15, buttonConstructor15 },
                { 16, buttonConstructor16 },
                { 17, buttonConstructor17 },
                { 18, buttonConstructor18 },
            };

            _buttonDisabledList = new Dictionary<int, Button>()
            {
                { 13, buttonConstructor20 },
                { 14, buttonConstructor21 },
                { 15, buttonConstructor22 },
                { 16, buttonConstructor23 },
                { 17, buttonConstructor24 },
                { 18, buttonConstructor25 },
                { 7, buttonConstructor26 },
                { 8, buttonConstructor27 },
                { 9, buttonConstructor28 },
                { 10, buttonConstructor29 },
                { 11, buttonConstructor30 },
                { 12, buttonConstructor31 },
                { 6, buttonConstructor32 },
                { 5, buttonConstructor33 },
                { 4, buttonConstructor34 },
                { 3, buttonConstructor35 },
                { 2, buttonConstructor36 },
                { 1, buttonConstructor37 },
            };

            _randomColors = new Dictionary<int, Color>()
            {
                {1, Color.Firebrick},
                {2, Color.SeaGreen},
                {3, Color.SteelBlue},
                {4, Color.Goldenrod},
                {5, Color.DarkSlateBlue},
                {6, Color.MediumTurquoise},
                {7, Color.DarkOrange}
            };

            _randomBackColors = new Dictionary<int, Color>()
            {
                {1, Color.LightCoral },
                {2, Color.SpringGreen },
                {3, Color.DeepSkyBlue },
                {4, Color.Gold },
                {5, Color.MediumSlateBlue },
                {6, Color.Aquamarine },
                {7, Color.Orange }
            };

            _randomDisabledColors = new Dictionary<int, Color>()
            {
                {1, Color.DarkRed },
                {2, Color.DarkGreen},
                {3, Color.DarkBlue},
                {4, Color.SaddleBrown},
                {5, Color.Indigo},
                {6, Color.DarkSlateGray},
                {7, Color.SaddleBrown}

            };

            doVisible();

            for (int i = 1; i <= _buttonList.Count; i++)
            {
                // _buttonList[i].Size = new Size(84, 74);
            }



        }


        private void EnabledTrue()
        {
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].Enabled = true;
            }
        }

        private void letterClick(object sender, EventArgs e)
        {
            undoButton.Enabled = true;

            Button letter = (Button)sender;
            answerTextBox.Text += letter.Text;
            letter.Enabled = false;
            letter.Visible = false;
            // letter.BackColor = Color.LightGray;

            if (answerTextBox.Text == sb.ToString())
            {

                undoButton.Visible = false;
                undoButtonDisabled.Visible = false;
                this.BackColor = Color.White;
                startButton.Visible = true;
                startButtonDisabled.Visible = true;
                startButton.Enabled = true;

                letterFinalNo();
                doVisible();
                EnabledTrue();
                defTextBox.ForeColor = Color.Black;
                defTextBox.Visible = true;
                // defTextBox.Text = "Отлично!";
                countAnswers++;
                if (countAnswersToDef < 5)
                {
                    countAnswersToDef++;
                    thinkLabel.Text = countAnswersToDef.ToString() + "/" + "5";
                }

                defAnswerLabel.Visible = false;

                label2.Text = "";
                label2.Visible = false;

                _defMiddle.Clear();
                if (countAnswersToDef == 5)
                {
                    thinkButton.Enabled = true;
                    // label2.Text = "У вас есть подсказка!";
                }

                answeredWordsLabel.Text = "Слов отгадано: " + countAnswers.ToString();
                // pictureBox2.Visible = true;

            }
        }

        private void letterFinalNo()
        {
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].Text = "-";
            }
        }



        private void startButton_Click(object sender, EventArgs e)
        {
            // pictureBox2.Visible = false;
            Button letter = (Button)sender;
            letter.Visible = false;
            startButton.Enabled = false;
            startButtonDisabled.Visible = false;

            RandomColors();
            ChangeTextColor(buttonConstructor1.BackColor);

            if (startButton.Text == "Начать")
                startButton.Text = "Продолжить";
            sb.Remove(0, sb.Length);
            answerTextBox.Text = "";


            value = random.Next(0, words.Count);
            sbAppend(value);

            thinkButton.Visible = true;
            thinkLabel.Visible = true;
            undoButton.Visible = true;
            undoButton.Enabled = false;
            undoButtonDisabled.Visible = true;
            label2.Visible = true;

            cheatCode.Visible = true;
            cheatCodeDisabled.Visible = true;
            cheatTextBox.Visible = true;
            answerTextBox.Visible = true;

            if (defTextBox.Visible == true)
                defTextBox.Visible = false;


        }
        private void sbAppend(int value)
        {
            sb.Append(words[value]);
            answerLabel.Text = sb.ToString();
            int randomButton = 1;
            for (int i = 0; i < sb.Length; i++)
            {
                for (int j = 0; j == 0;)
                {
                    randomButton = random.Next(1, _buttonList.Count);
                    // label1.Text += randomButton + " "; // проверка
                    if (_buttonList[randomButton].Text == "-")
                    {
                        char letter = sb[i];
                        _buttonList[randomButton].Text = letter.ToString();
                        _defMiddle.Add(middleNum, _buttonList[randomButton].Visible);
                        middleNum++;
                        _buttonList[randomButton].Visible = true;
                        _buttonDisabledList[randomButton].Visible = true;
                        break;
                    }

                }

            }


        }

        private void doVisible()
        {
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].Visible = false;
                _buttonDisabledList[i].Visible = false;
            }


            // previousLabel.Visible= false;
            label1.Visible = false;
            thinkButton.Visible = false;
            thinkLabel.Visible = false;
            // answerLabel.Visible= false;

            cheatCode.Visible = false;
            cheatCodeDisabled.Visible = false;
            cheatTextBox.Visible = false;

        }



        private void cheatCode_Click(object sender, EventArgs e)
        {
            if (cheatTextBox.Text == "подсказка" && countAnswersToDef < 4)
            {
                countAnswersToDef++;
                thinkLabel.Text = countAnswersToDef.ToString() + "/" + "5";
            }
            else if (countAnswersToDef == 4)
            {
                countAnswersToDef++;
                thinkLabel.Text = countAnswersToDef.ToString() + "/" + "5";
                thinkButton.Enabled = true;
            }
        }

        private void ColorRandom_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomColors();
            checkRandom = true;
            ChangeTextColor(buttonConstructor1.BackColor);
        }

        private void RandomColors()
        {
            int randomColor = random.Next(1, 7);
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].BackColor = (Color)_randomBackColors[randomColor];
                this.BackColor = _randomColors[randomColor];
                _buttonDisabledList[i].BackColor = _randomDisabledColors[randomColor];
                menuStrip1.BackColor = _randomBackColors[randomColor];
                pictureBox1.BackColor = _randomDisabledColors[randomColor];
                startButton.BackColor = _randomBackColors[randomColor];
                startButtonDisabled.BackColor = _randomDisabledColors[randomColor];
                cheatCode.BackColor = _randomBackColors[randomColor];
                cheatCodeDisabled.BackColor = _randomDisabledColors[randomColor];
                undoButton.BackColor = _randomBackColors[randomColor];
                undoButton.ForeColor = _randomDisabledColors[randomColor];
                undoButtonDisabled.BackColor = _randomDisabledColors[randomColor];
            }
            // DoColors();
        }

        private void ChangeColor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            ChangeColor(tsmi.BackColor);
            if (checkRandom == true)
                checkRandom = false;
            ChangeTextColor(tsmi.BackColor);


        }

        private void ChangeColor(Color color)
        {
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].BackColor = color;
            }

        }

        private void LoadSettings(Color color, Color textColor, Color disabledColor, out int answers, out int answersToDef)
        {
            ButtonConstructor.borderRadius = Properties.Settings.Default.borderRadius;
            SpecialButtonConstructor.borderRadius = Properties.Settings.Default.specialBorderRadius;
            answers = Properties.Settings.Default.countAnswersFinal;
            answersToDef = Properties.Settings.Default.answersToDef;
            this.BackColor = Properties.Settings.Default.foneColor;
            startButton.BackColor = color;
            startButtonDisabled.BackColor = disabledColor;
            cheatCode.BackColor = color;
            cheatCodeDisabled.BackColor = disabledColor;
            menuStrip1.BackColor = color;
            pictureBox1.BackColor = disabledColor;
            undoButton.BackColor = color;
            undoButton.ForeColor = disabledColor;
            undoButtonDisabled.BackColor = disabledColor;


            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].BackColor = color;
                _buttonList[i].ForeColor = textColor;
                _buttonDisabledList[i].BackColor = disabledColor;
            }

        }

        private void ChangeTextColor(Color color)
        {
            if (color == Color.Gold
                || color == Color.MediumTurquoise
                || color == Color.Orange)
            {
                for (int i = 1; i <= _buttonList.Count; i++)
                {
                    _buttonList[i].ForeColor = Color.Black;
                }
            }
            else
            {
                for (int i = 1; i <= _buttonList.Count; i++)
                {
                    _buttonList[i].ForeColor = Color.Black;
                }
            }
        }

        private void thinkButton_Click(object sender, EventArgs e)
        {

            thinkButton.Enabled = false;
            char letter = sb[sbThink];
            defAnswerLabel.Text = "'" + letter + "'";
            defAnswerLabel.Visible = true;
            countAnswersToDef = 0;
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            answerTextBox.Text = "";
            undoButton.Enabled = false;
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                if (_buttonList[i].Text != "-")
                {
                    _buttonList[i].Visible = true;
                    _buttonList[i].Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings(Properties.Settings.Default.colorFinal,
                Properties.Settings.Default.colortTextFinal,
                Properties.Settings.Default.disabledColor,
                out countAnswers, out countAnswersToDef);
            for (int i = 1; i <= _buttonList.Count; i++)
            {
                _buttonList[i].TabStop = false;
                _buttonDisabledList[i].TabStop = false;
            }
            // startButton.TabStop = false;
            startButtonDisabled.TabStop = false;
            cheatCode.TabStop = false;
            cheatCodeDisabled.TabStop = false;
            // undoButton.TabStop = false;
            undoButtonDisabled.TabStop = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.disabledColor = buttonConstructor20.BackColor;
            Properties.Settings.Default.foneColor = this.BackColor;
            Properties.Settings.Default.answersToDef = countAnswersToDef;
            Properties.Settings.Default.borderRadius = ButtonConstructor.borderRadius;
            Properties.Settings.Default.colorFinal = buttonConstructor1.BackColor;
            Properties.Settings.Default.colortTextFinal = buttonConstructor1.ForeColor;
            Properties.Settings.Default.countAnswersFinal = countAnswers;
            Properties.Settings.Default.specialBorderRadius = SpecialButtonConstructor.borderRadius;
            Properties.Settings.Default.Save();
        }

        private void styleClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmp = (ToolStripMenuItem)sender;
            if (tsmp.Text == "Квадратный")
            {
                ButtonConstructor.borderRadius = 0;
                SpecialButtonConstructor.borderRadius = 0;
            }
            else if (tsmp.Text == "Закруглённый")
            {
                ButtonConstructor.borderRadius = 15;
                SpecialButtonConstructor.borderRadius = 10;
            }
            else if (tsmp.Text == "Сильно закруглённый")
            {
                ButtonConstructor.borderRadius = 30;
                SpecialButtonConstructor.borderRadius = 10;
            }
            else if (tsmp.Text == "Почти круглый")
            {
                ButtonConstructor.borderRadius = 40;
                SpecialButtonConstructor.borderRadius = 10;
            }

            if (startButton.Visible == false)
            {
                for (int i = 1; i <= _buttonList.Count; i++)
                {
                    if (_buttonList[i].Text != "-")
                    {
                        _buttonList[i].Visible = false;
                        _buttonDisabledList[i].Visible = false;
                        _buttonList[i].Visible = true;
                        _buttonDisabledList[i].Visible = true;
                    }
                }
                undoButton.Visible = false;
                undoButtonDisabled.Visible = false;
                cheatCode.Visible = false;
                cheatCodeDisabled.Visible = false;
                undoButton.Visible = true;
                undoButtonDisabled.Visible = true;
                cheatCode.Visible = true;
                cheatCodeDisabled.Visible = true;
            }
            else if (startButton.Visible == true)
            {

                startButton.Visible = false;
                startButton.Visible = true;
                startButtonDisabled.Visible = false;
                startButtonDisabled.Visible = true;
            }
            // pictureBox2.Visible = true;


            //this.Hide();
            //MessageBox.Show("Перезайдите для обновления состояния.");
            //this.Close();
        }
    }
}