using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Unit3Summative
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        string RightAnswer;
        Random random = new Random();
        //Random random = new Random((int)DateTime.Now.Ticks);
        string DiscoveredAnswer;
        bool FoundLetter = false;
        int Error404;
        int lives = 9;
        string[] beginner = new string[10];
        string[] intermediate = new string[10];
        string[] expert = new string[10];
        int Hogwarts;  
        List<string> ImageList = new List<string>();
        bool GameOver;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            int randomnumber = random.Next(1, 10);
            lblOutput.Content = "";
            //Radio Button to decide the difficulty of the game
            //and pick a random word from list/textfile
            if ((bool)begMode.IsChecked)
            {
                System.IO.StreamReader easyread = new System.IO.StreamReader("BeginnerMode.txt");
                while (!easyread.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        beginner[randomnumber] = easyread.ReadLine();
                    }
                    else
                    {
                        easyread.ReadLine();
                    }
                    RightAnswer = beginner[randomnumber];
                    count++;
                }
                easyread.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            if ((bool)interMode.IsChecked)
            {
                count = 0;
                System.IO.StreamReader mediumLevel = new System.IO.StreamReader("IntermediateMode.txt");
                while (!mediumLevel.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        intermediate[randomnumber] = mediumLevel.ReadLine();
                    }
                    else
                    {
                        mediumLevel.ReadLine();
                    }
                    RightAnswer = intermediate[randomnumber];
                    count++;
                }
                mediumLevel.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            if ((bool)expMode.IsChecked)
            {
                count = 0;
                System.IO.StreamReader HardLevel = new System.IO.StreamReader("ExpertMode.txt");
                while (!HardLevel.EndOfStream)
                {
                    if (count == randomnumber)
                    {
                        expert[randomnumber] = HardLevel.ReadLine();
                    }
                    else
                    {
                        HardLevel.ReadLine();
                    }
                    RightAnswer = expert[randomnumber];
                    count++;
                }
                HardLevel.Close();
                for (int i = 0; i <= RightAnswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            lblOutput.Content += Environment.NewLine + "Lives left:" + lives;
        }

        private void btnLetterCheck_Click(object sender, RoutedEventArgs e)
        {
            //replace the letter of the input if right
            DiscoveredAnswer = lblOutput.Content.ToString();
            for (int i = 0; i < RightAnswer.Length; i++)
            {
                char lettersingle = RightAnswer[i];
                if (lettersingle.ToString() == txtImput.Text)
                {
                    DiscoveredAnswer = DiscoveredAnswer.Remove(i * 2, 1);
                    DiscoveredAnswer = DiscoveredAnswer.Insert(i * 2, lettersingle.ToString());
                    lblOutput.Content = "";
                    lblOutput.Content += DiscoveredAnswer;
                    FoundLetter = true;
                }
            }
            //replace the image when the letter is wrong
            if (FoundLetter == false)
            {
                Error404 += 1;
                if (Error404 == 8)
                {
                    ImageList.Add("original-3541348-2.jpg");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 7)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 6)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 5)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 4)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 3)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 2)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                else if (Error404 == 1)
                {
                    ImageList.Add("");
                    Hogwarts = lives - Error404;
                    lblOutput.Content += "," + Hogwarts;
                }
                bool Game1 = false;
                CheckForWin(Game1);
            }
        }
        public bool CheckForWin(bool Win)
        {
            if (lblOutput.Content.ToString() == RightAnswer)
            {
                MessageBox.Show("You Won!");
                return Win = true;
            }
            else
            {
                return Win = false;
            }
        }

        private bool startGame(bool test)
        {
            if (lblOutput.Content.ToString() == RightAnswer || GameOver == true)
            {
                count = 0;
                int randomnumber = random.Next(0, 10);
                lblOutput.Content = "";

                if ((bool)begMode.IsChecked)
                {
                    System.IO.StreamReader easyread = new System.IO.StreamReader("BeginnerMode.txt");
                    while (!easyread.EndOfStream)
                    {
                        if (count == randomnumber)
                        {
                            beginner[randomnumber] = easyread.ReadLine();
                        }
                        else
                        {
                            easyread.ReadLine();
                        }
                        RightAnswer = beginner[randomnumber];
                        count++;
                    }
                    easyread.Close();
                    for (int i = 0; i < RightAnswer.Length; i++)
                    {
                        lblOutput.Content += "_" + " ";
                    }

                    if ((bool)interMode.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader mediumLevel = new System.IO.StreamReader("IntermediateMode.txt");
                        while (!mediumLevel.EndOfStream)
                        {
                            intermediate[count] = mediumLevel.ReadLine();
                            lblOutput.Content += intermediate[count] + Environment.NewLine;
                            count++;
                        }
                        mediumLevel.Close();
                    }
                    if ((bool)expMode.IsChecked)
                    {
                        count = 0;
                        System.IO.StreamReader HardLevel = new System.IO.StreamReader("ExpertMode.txt");
                        while (!HardLevel.EndOfStream)
                        {
                            expert[count] = HardLevel.ReadLine();
                            lblOutput.Content += expert[count] + Environment.NewLine;
                            count++;
                        }
                        HardLevel.Close();
                    }
                }

                lblOutput.Content = RightAnswer;
                lblOutput.Content += Environment.NewLine + "Lives left :" + lives;
                GameOver = false;
                return test = true;
            }
            else
            {
                return test = false;
            }
        }

    }
}


