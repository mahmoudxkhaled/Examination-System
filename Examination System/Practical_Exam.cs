using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System;

public class Practical_Exam : Exam
{
    public Practical_Exam(int timeOfExam, int numOfQuestions, Subject subject) : base(timeOfExam, numOfQuestions, subject)
    {

    }

    public override void Show_Exam()
    {
        Console.WriteLine("Welcome to Exam! Answer the following questions:  ");

        // Show Questions and Save All User Answers =>
        List<string> userAnswers = new List<string>();
        int correctAnswers = 0;
        int totalMarksOfCorrectAnswers = 0;
        int totalMarksOfExam = 0;

        for (int i = 0; i < QUESTIONS.Count; i++)
        {
            var question = QUESTIONS[i];
            Console.WriteLine($"\nQ{i + 1}) {question.BODY}");

            DisplayQuestionOptions(question);

            Console.WriteLine("-----------------------");
            Console.Write("Your Answer: ");

            // Read and Validate User Answer
            string userAnswer = ReadAndValidateUserAnswer(question);
            userAnswers.Add(userAnswer);

            // Check and Sum => Marks and CorrectAnswers
            ProcessAnswer(question, userAnswer);

            if (question.CheckAnswer(userAnswer))
            {
                correctAnswers++;
            }

            totalMarksOfCorrectAnswers += question.CheckAnswer(userAnswer) ? question.MARK : 0;
            totalMarksOfExam += question.MARK;
        }

        // Results
        Console.Clear();
        Console.WriteLine("Exam Completed! CONGRATSSSSS \n");
        Console.WriteLine("Your Results: \n");

        DisplayResults(userAnswers, totalMarksOfCorrectAnswers, totalMarksOfExam, correctAnswers);
    }

    private void DisplayQuestionOptions(Question question)
    {
        if (question is MCQ_Question mcqQuestion)
        {
            foreach (var choice in mcqQuestion.AnswerList)
            {
                Console.WriteLine($"{choice.ANSWER_ID}- {choice.ANSWER_TEXT}");
            }
        }
    }

    private string ReadAndValidateUserAnswer(Question question)
    {
        string userAnswer;
        bool isValidAnswer = false;

        do
        {
            userAnswer = Console.ReadLine();

            if (question is MCQ_Question mcq)
            {
                foreach (var choice in mcq.AnswerList)
                {
                    if (userAnswer == choice.ANSWER_ID.ToString())
                    {
                        isValidAnswer = true;
                        break;
                    }
                }
            }

            if (!isValidAnswer)
            {
                Console.WriteLine("Please enter a valid choice");
                Console.Write("Your Answer:  ");
            }
        } while (!isValidAnswer);

        return userAnswer;
    }

    private void DisplayResults(List<string> userAnswers, int totalMarksOfCorrectAnswers, int totalMarksOfExam, int correctAnswers)
    {
        for (int i = 0; i < QUESTIONS.Count; i++)
        {
            var question = QUESTIONS[i];
            var correction = ProcessAnswer(question, userAnswers[i]);

            Console.WriteLine($"Q{i + 1}) {question.BODY} : {userAnswers[i]} => {correction}\n");
        }
        Console.WriteLine($"Your Total Marks: {totalMarksOfCorrectAnswers} out of {totalMarksOfExam}\n");
        Console.WriteLine($"Your Total Correct Answers = {correctAnswers} out of {QUESTIONS.Count}  QUESTIONS\n");
    }
}