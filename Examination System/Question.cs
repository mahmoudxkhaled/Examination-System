namespace Examination_System;

public abstract class Question
{
    public string HEADER { get; set; } = string.Empty;
    public string BODY { get; set; } = string.Empty;
    public int MARK { get; set; } = default;

    public Question()
    {

    }

    public Question(string _HEADER, string _BODY, int _MARK)
    {
        HEADER = _HEADER;
        BODY = _BODY;
        MARK = _MARK;
    }
    public abstract bool CheckAnswer(string userAnswer);

}
