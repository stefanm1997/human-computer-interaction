using Sport_Quiz_Game.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sport_Quiz_Game
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        static string questionImage = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\Question";
        static List<Question> allQuestions = new List<Question>();
        static int numberOfQuestion, questionCounter = 1, counter = 0, numberOfCorrectAnswer = 0;
        public GameWindow(int number)
        {
            numberOfQuestion = number;
            //Console.WriteLine(numberOfQuestion);
            InitializeComponent();
            ReadAllQuestion();
            QuestionInitialization(allQuestions.ElementAt(counter));
        }

        private async void Check_Answer(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            var button = sender as Button;
            if (counter < numberOfQuestion)
            { 
                var question = allQuestions.ElementAt(counter);
                counter++;
                if (question.CorrectAnswer.Equals(button.Content))
                {
                    button.Background = Brushes.LimeGreen;
                    numberOfCorrectAnswer++;
                    Console.WriteLine("Tacan odgovor!");
                    //Thread.Sleep(3000);
                    await PutTaskDelay();
                    button.Background = Brushes.Orange;
                }
                else
                {
                    button.Background = Brushes.Red;
                    await PutTaskDelay();
                    //Thread.Sleep(3000);
                    button.Background = Brushes.Orange;
                }
                if (counter < numberOfQuestion)
                    QuestionInitialization(allQuestions.ElementAt(counter));
                else
                {
                    resultState.Text = "Rezultat: " + numberOfCorrectAnswer + "/" + numberOfQuestion;
                    MessageBoxResult result = MessageBox.Show("Vaš rezultat je: " + numberOfCorrectAnswer + "/" + numberOfQuestion+
                        "\nDa li želite ponovo da igrate kviz?",
                                          "Rezultat",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    else
                        Application.Current.Shutdown();
                }
                    

            }
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(1500);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                btn1.Height = 80;
                btn2.Height = 80;
                btn3.Height = 80;
                btn4.Height = 80;
                btn1.Width = 600;
                btn2.Width = 600;
                btn3.Width = 600;
                btn4.Width = 600;
            }
            else
            {
                btn1.Height = 45;
                btn2.Height = 45;
                btn3.Height = 45;
                btn4.Height = 45;
                btn1.Width = 400;
                btn2.Width = 400;
                btn3.Width = 400;
                btn4.Width = 400;
            }
                
            //Window.WindowStateProperty.
        }

        public void QuestionInitialization(Question q)
        {
            resultState.Text = "Rezultat: "+numberOfCorrectAnswer+"/" + numberOfQuestion;
            questionNumber.Text = "Pitanje " + questionCounter++ + ".";
            questionText.Text = q.QuestionText;
            Shuffle(q.Answers);
            btn1.Content = q.Answers.ElementAt(0);
            btn2.Content = q.Answers.ElementAt(1);
            btn3.Content = q.Answers.ElementAt(2);
            btn4.Content = q.Answers.ElementAt(3);
            picture.Source = new BitmapImage(new Uri(q.ImageLocation));
        }
        public void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public void ReadAllQuestion()
        {          
            var line = "";
            using (var reader = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Questions.txt", Encoding.UTF8))
            {
                int id = 0, counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                    var split = line.Split('#');
                    var question = new Question
                    {
                        ID = id++,
                        QuestionText = split[0],
                        CorrectAnswer = split[3],
                        ImageLocation = questionImage+split[5],
                        Answers = new List<string>() { split[1], split[2], split[3], split[4] }
                    };
                    /*question.Answers.Add(split[1]);
                    question.Answers.Add(split[2]);
                    question.Answers.Add(split[3]);
                    question.Answers.Add(split[4]);*/
                    Shuffle(question.Answers);
                    allQuestions.Add(question);
                }
            }
            Shuffle(allQuestions);
            var different = 15 - numberOfQuestion;
            if (different != 0)
            {
                for(int i = 0; i < different; i++)
                {
                    allQuestions.RemoveAt(i);
                }
            }
        }

    }
}
