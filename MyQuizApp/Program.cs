namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question("What is the capital of France?", new string[] { "Berlin", "Madrid", "Paris", "Rome" }, 2),
                new Question("What is 2 + 2?", new string[] { "3", "4", "5", "6" }, 1),
                new Question("What is the largest planet in our solar system?", new string[] { "Earth", "Jupiter", "Mars", "Saturn" }, 1)
            };

            Quiz quiz = new Quiz(questions);
            quiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
