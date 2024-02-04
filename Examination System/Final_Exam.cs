using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System;

public class Final_Exam : Exam
{
    public Final_Exam(int timeOfExam, int numOfQuestions, Subject subject) : base(timeOfExam, numOfQuestions, subject)
    {

    }

    public override void Show_Exam()
    {
        Console.WriteLine("Welcome to Exam! Answer the following questions:  ");


        //Show Questions and Save All User Answers =>
        List<string> userAnswers = new List<string>();
        int correctAnswers = 0;
        int totalMarksOfCorrectAnswers = 0;
        int totalMarksOfExam = 0;

        for (int i = 0; i < QUESTIONS.Count; i++)
        {
            var question = QUESTIONS[i];
            Console.WriteLine($"\nQ{i + 1}) {question.BODY} \n");

            DisplayQuestionOptions(question);

            Console.WriteLine("-----------------------");
            Console.Write("Your Answer: ");

            //Read and Validate User Answer
            string userAnswer = ReadAndValidateUserAnswer(question);
            userAnswers.Add(userAnswer);

            //Check and Sum => totalMarks and correctAnswers
            ProcessAnswer(question, userAnswer);

            if (question.CheckAnswer(userAnswer))
            {
                correctAnswers++;
            }

            totalMarksOfCorrectAnswers += question.CheckAnswer(userAnswer) ? question.MARK : 0;
            totalMarksOfExam += question.MARK;
        }

        //Results
        Console.Clear();
        Console.WriteLine("Congratulations! You have completed the Exam.\n");
        Console.WriteLine("Your Results is: \n");

        DisplayResults(userAnswers, correctAnswers, totalMarksOfCorrectAnswers, totalMarksOfExam);
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
        else if (question is TrueFalse_Question tfQuestion)
        {
            Console.WriteLine("1. True                   2. False");
        }
    }

    private string ReadAndValidateUserAnswer(Question question)
    {
        string userAnswer;
        bool isValidAnswer;

        do
        {
            userAnswer = Console.ReadLine();

            isValidAnswer = question is MCQ_Question mcq
                ? mcq.AnswerList.Exists(choice => userAnswer == choice.ANSWER_ID.ToString())
                : userAnswer == "1" || userAnswer == "2";

            if (!isValidAnswer)
            {
                Console.WriteLine("Please enter a valid choice");
                Console.Write("Your Answer: ");
            }
        } while (!isValidAnswer);

        return question is TrueFalse_Question tfQuestion
            ? (userAnswer == "1" ? "True" : "False")
            : userAnswer;
    }

    private void DisplayResults(List<string> userAnswers, int correctAnswers, int totalMarksOfCorrectAnswers, int totalMarksOfExam)
    {
        for (int i = 0; i < QUESTIONS.Count; i++)
        {
            var question = QUESTIONS[i];
            var correction = ProcessAnswer(question, userAnswers[i]);

            Console.WriteLine($"Q{i + 1}) {question.BODY} : {userAnswers[i]} => {correction}\n");
        }
        Console.WriteLine($"Your Total Marks = {totalMarksOfCorrectAnswers} out of {totalMarksOfExam} \n");
        Console.WriteLine($"Your Total Correct Answers = {correctAnswers} out of {QUESTIONS.Count}  QUESTIONS \n");
    }
}