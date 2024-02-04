namespace Examination_System;

public class Exam
{
    public int TIME_OF_EXAM { get; set; }
    public int NUM_OF_QUES { get; set; }
    public Subject ASSOCIATED_SUBJECT { get; set; }
    public List<Question> QUESTIONS { get; set; } = new List<Question>();

    public Exam()
    {

    }

    public Exam(int _TIME_OF_EXAM, int _NUM_OF_QUES, Subject _ASSOCIATED_SUBJECT)
    {
        TIME_OF_EXAM = _TIME_OF_EXAM;
        NUM_OF_QUES = _NUM_OF_QUES;
        ASSOCIATED_SUBJECT = _ASSOCIATED_SUBJECT;

    }
    public string ProcessAnswer(Question question, string userAnswer)
    {

        if (question.CheckAnswer(userAnswer))
        {
            return "Correct!";
        }
        else
        {
            return "Incorrect!";
        }
    }

    public virtual void Show_Exam()
    {

        Console.WriteLine("I`m Exam");
    }
}
