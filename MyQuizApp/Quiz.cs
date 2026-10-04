using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score;

        public Quiz(Question[] questions)
        {
            this._questions = questions;
            this._score = 0;
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1;
            foreach (var question in _questions)
            {
                Console.WriteLine($"\nQuestion {questionNumber}:");
                DisplayQuestion(question);
                questionNumber++;
                int userChoice = getUserChoice();
                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    _score++;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect! The correct answer is: {question.Answers[question.CorrectAnswerIndex]}");
                    Console.ResetColor();
                }
            }
            DisplayResults();
        }

        public void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------Question-------------------");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  ");
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($". {question.Answers[i]}");
            }
        }

        private int getUserChoice()
        {
            Console.Write("Enter your choice (1-4): ");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 4)
            {
                return choice - 1; // Convert to zero-based index
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                return getUserChoice(); // Recursively ask for input again
            }
        }
        private void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------Results-------------------");
            Console.ResetColor();
            Console.WriteLine($"\nQuiz completed! Your score: {_score}/{_questions.Length}");
            double percentage = ((double)_score / _questions.Length) * 100;
            Console.WriteLine($"Percentage: {percentage}%");
            if(percentage >= 80)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent performance!");
            }
            else if(percentage >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good job! Keep practicing.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Better luck next time. Keep learning!");
            }
            Console.ResetColor();   
        }
    }
}
