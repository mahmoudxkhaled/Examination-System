namespace Examination_System;


public class Answer
{

    public int ANSWER_ID { get; set; } = 0;
    public string ANSWER_TEXT { get; set; } = string.Empty;

    public Answer()
    {

    }

    public Answer(int _ANSWER_ID, string _ANSWER_TEXT)
    {
        ANSWER_ID = _ANSWER_ID;
        ANSWER_TEXT = _ANSWER_TEXT;
    }






}
