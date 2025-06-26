using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CyberBotGUI;

namespace CyberBotGUI
{
    public partial class MainWindow : Window
    {
        private readonly UserProfile _userProfile = new();
        private readonly CyberSecurityKnowledgeBase _knowledgeBase = new();
        private readonly ResponseGenerator _responseGenerator;
        private readonly ChatBot _chatBot;
        private readonly List<string> activityLog = new();
        private readonly List<TaskItem> taskList = new();

        private int quizIndex = 0;
        private int quizScore = 0;
        private readonly string[,] quizQuestions = new string[,]
        {
            { "What is phishing?", "A) Fake websites", "B) Fake emails", "C) Malware", "B" },
            { "Strong passwords should include?", "A) Pet names", "B) Birthdays", "C) Letters, numbers, symbols", "C" },
            { "What does 2FA stand for?", "A) Two-Factor Authentication", "B) Two-Fold Access", "C) Two-Factor Agreement", "A" },
            { "Should you share your password?", "A) Yes", "B) No", "C) Sometimes", "B" },
            { "What to do with suspicious emails?", "A) Reply", "B) Delete", "C) Report as phishing", "C" },
            { "What is malware?", "A) Hardware failure", "B) Harmful software", "C) Protective software", "B" },
            { "A good password is...?", "A) Short", "B) Complex and unique", "C) Easy to remember", "B" },
            { "Is HTTPS safer than HTTP?", "A) No", "B) Sometimes", "C) Yes", "C" },
            { "Social engineering means?", "A) Manipulating people", "B) Computer bugs", "C) Search engines", "A" },
            { "Safest way to store passwords?", "A) Browser", "B) Sticky notes", "C) Password manager", "C" }
        };

        public MainWindow()
        {
            InitializeComponent();
            _responseGenerator = new ResponseGenerator(_knowledgeBase, _userProfile);
            _chatBot = new ChatBot(_userProfile, _responseGenerator);

            VoicePlayer.PlayIntro();
            AddBotMessage("Welcome to the Cybersecurity Awareness Bot!");
            AddBotMessage("Ask me anything: 'start quiz', 'add task', 'show tasks', 'show log', 'password', 'phishing'...");
        }

        private void AddBotMessage(string message)
        {
            ChatPanel.Children.Add(new TextBlock
            {
                Text = "Bot: " + message,
                Margin = new Thickness(5),
                Foreground = System.Windows.Media.Brushes.Blue
            });
        }

        private void AddUserMessage(string message)
        {
            ChatPanel.Children.Add(new TextBlock
            {
                Text = "You: " + message,
                Margin = new Thickness(5),
                Foreground = System.Windows.Media.Brushes.Black
            });
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AddUserMessage(input);

            if (input.Contains("add task", StringComparison.OrdinalIgnoreCase))
            {
                string title = Microsoft.VisualBasic.Interaction.InputBox("Enter Task Title:", "Add Task");
                string reminder = Microsoft.VisualBasic.Interaction.InputBox("Enter Reminder (e.g., 3 days):", "Reminder");
                taskList.Add(new TaskItem { Title = title, Reminder = reminder });
                activityLog.Add($"Task added: '{title}' ({reminder})");
                AddBotMessage($"Task '{title}' added with reminder: {reminder}");
            }
            else if (input.Contains("show tasks", StringComparison.OrdinalIgnoreCase))
            {
                AddBotMessage("Your tasks:");
                foreach (var task in taskList)
                    AddBotMessage($"- {task.Title} (Reminder: {task.Reminder})");
                activityLog.Add("Viewed task list");
            }
            else if (input.Contains("show log", StringComparison.OrdinalIgnoreCase))
            {
                AddBotMessage("Activity Log:");
                foreach (var entry in activityLog)
                    AddBotMessage("- " + entry);
            }
            else if (input.Contains("quiz", StringComparison.OrdinalIgnoreCase))
            {
                quizIndex = 0;
                quizScore = 0;
                AddBotMessage("Starting quiz! Type A, B, or C to answer.");
                AskNextQuizQuestion();
            }
            else if (quizIndex < quizQuestions.GetLength(0) && (input.Equals("A", StringComparison.OrdinalIgnoreCase) || input.Equals("B", StringComparison.OrdinalIgnoreCase) || input.Equals("C", StringComparison.OrdinalIgnoreCase)))
            {
                CheckQuizAnswer(input);
                AskNextQuizQuestion();
            }
            else
            {
                string response = _chatBot.GetResponse(input.ToLower());
                AddBotMessage(response);
                activityLog.Add("User asked: " + input);
            }

            InputBox.Clear();
        }

        private void AskNextQuizQuestion()
        {
            if (quizIndex >= quizQuestions.GetLength(0))
            {
                AddBotMessage($"Quiz complete! Score: {quizScore}/{quizQuestions.GetLength(0)}");
                activityLog.Add($"Completed quiz with score {quizScore}");
                return;
            }

            AddBotMessage($"Q{quizIndex + 1}: {quizQuestions[quizIndex, 0]}");
            AddBotMessage(quizQuestions[quizIndex, 1]);
            AddBotMessage(quizQuestions[quizIndex, 2]);
            AddBotMessage(quizQuestions[quizIndex, 3]);
        }

        private void CheckQuizAnswer(string input)
        {
            string correct = quizQuestions[quizIndex, 4];
            if (input.Equals(correct, StringComparison.OrdinalIgnoreCase))
            {
                AddBotMessage("Correct!");
                quizScore++;
            }
            else
            {
                AddBotMessage($"Incorrect. The correct answer was: {correct}");
            }
            quizIndex++;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Click(sender, e);
                e.Handled = true;
            }
        }
    }

    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public string Reminder { get; set; } = string.Empty;
    }
}
