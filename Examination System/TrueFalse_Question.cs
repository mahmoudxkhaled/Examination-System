namespace Examination_System;

public class TrueFalse_Question : Question
{

    public bool CorrectAnswer { get; set; }

    public TrueFalse_Question(string header, string body, int mark, bool _CorrectAnswer)
    {
        HEADER = header;
        BODY = body;
        MARK = mark;
        CorrectAnswer = _CorrectAnswer;
    }


    public override bool CheckAnswer(string userAnswer)
    {
        bool userResponse;
        if (bool.TryParse(userAnswer, out userResponse))
        {
            return userResponse == CorrectAnswer;
        }
        return false;
    }
}
