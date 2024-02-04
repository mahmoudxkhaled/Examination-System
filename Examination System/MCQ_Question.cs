namespace Examination_System;

public class MCQ_Question : Question
{
    public List<Answer> AnswerList { get; set; }
    public int CorrectAnswer { get; set; }

    public MCQ_Question(string header, string body, int mark, List<Answer> answerList, int correctAnswer)
    {
        HEADER = header;
        BODY = body;
        MARK = mark;
        AnswerList = answerList;
        CorrectAnswer = correctAnswer;
    }



    public override bool CheckAnswer(string userAnswer)
    {
        int userResponse;
        if (int.TryParse(userAnswer, out userResponse))
        {
            return userResponse == CorrectAnswer;
        }
        return false;
    }
}
