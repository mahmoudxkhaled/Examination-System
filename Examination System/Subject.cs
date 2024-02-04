namespace Examination_System;

public class Subject
{
    public static int lastSubjectId = 0;

    public int SUBJECT_ID { get; set; }
    public string SUBJECT_NAME { get; set; } = string.Empty;

    public Exam EXAM_OF_SUBJECT;


    public Subject()
    {
        SUBJECT_ID = ++lastSubjectId;
    }

    public Subject(string _SUBJECT_NAME) : this()
    {
        SUBJECT_NAME = _SUBJECT_NAME;
    }

    public void CreateExam()
    {

        Console.Write("Enter Name Of Subject: ");
        string SubjectName = Console.ReadLine();

        Console.Write("\nEnter the type of exam (1 => Final || 2 => Practical):  ");
        int examType;

        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out examType) && (examType == 1 || examType == 2))
            {
                break;
            }
            else
            {
                Console.Write("Please enter 1 || 2:  ");
            }
        }



        Console.Write("\nEnter the duration of the exam in minutes:  ");
        int timeOfExam;
        while (!int.TryParse(Console.ReadLine(), out timeOfExam) || timeOfExam <= 0)
        {
            Console.Write("Please enter a valid number:  ");
        }



        Console.Write("\nEnter the number of questions:  ");
        int numOfQues;
        while (!int.TryParse(Console.ReadLine(), out numOfQues) || numOfQues <= 0)
        {
            Console.Write("Please enter a valid number:  ");
        }



        Subject subject = new Subject(SubjectName);

        this.EXAM_OF_SUBJECT = examType switch
        {
            1 => new Final_Exam(timeOfExam, numOfQues, this),
            2 => new Practical_Exam(timeOfExam, numOfQues, this),
            _ => throw new Exception("Invalid exam type")
        };



        for (int i = 0; i < numOfQues; i++)
        {
            string body;
            int mark;

            if (examType == (int)Exam_Type.FINAL)
            {
                Console.Clear();
                Console.Write($"Select the question type for Q ({i + 1}) [ 1 => TrueFalse || 2 => MCQ ]:  ");
                int questionType;



                while (true)
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out questionType) && (questionType == 1 || questionType == 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter 1 || 2:  ");
                    }
                }

                Console.Clear();
                string header;
                if (questionType == 1)
                {
                    header = $"Q ({i + 1}) =>  True || False Question";
                }
                else
                {
                    header = $"Q ({i + 1}) => MCQ Question";

                }



                Console.WriteLine(header);

                Console.WriteLine($"Enter the Question body:  ");
                body = Console.ReadLine();


                Console.Write("\nEnter the mark:  ");
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.Write("Please enter a valid positive num for the mark:  ");
                }

                switch (questionType)
                {
                    case 1:
                        Console.Write("\nEnter the right answer  [ 1 for True || 2 for False ] :  ");
                        bool isTrue;

                        while (true)
                        {
                            string input = Console.ReadLine();

                            if (input == "1")
                            {
                                isTrue = true;
                                break;
                            }
                            else if (input == "2")
                            {
                                isTrue = false;
                                break;
                            }
                            else
                            {
                                Console.Write("Please enter 1 for True || 2 for False:  ");
                            }
                        }



                        this.EXAM_OF_SUBJECT.QUESTIONS.Add(new TrueFalse_Question(header, body, mark, isTrue));
                        break;

                    case 2:
                        List<Answer> answers = new List<Answer>();
                        Console.Write("\nEnter the number of choices:  ");
                        int numChoices;
                        while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
                        {
                            Console.Write("Please enter a valid positive number:  ");
                        }

                        for (int j = 0; j < numChoices; j++)
                        {
                            Console.Write($"\nEnter choice Num {j + 1}:  ");
                            string choiceText = Console.ReadLine();
                            answers.Add(new Answer(j + 1, choiceText));
                        }

                        Console.Write("\nEnter the correct answer (1, 2, 3, etc....):  ");
                        int correctAnswer;
                        while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > numChoices)
                        {
                            Console.Write($"Please enter a valid num between 1 and {numChoices} for the correct answer:  ");
                        }


                        this.EXAM_OF_SUBJECT.QUESTIONS.Add(new MCQ_Question(header, body, mark, answers, correctAnswer));
                        break;
                }
            }
            else
            {
                string header = $"Q ({i + 1}) => MCQ Question";
                Console.Clear();
                Console.WriteLine(header);

                Console.WriteLine($"Enter the Question body:  ");
                body = Console.ReadLine();


                Console.Write("Enter the mark:");
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.Write("Please enter a valid positive num for the mark:  ");
                }
                List<Answer> answers = new List<Answer>();
                Console.Write("Enter the number of choices:  ");
                int numChoices;
                while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
                {
                    Console.Write("Please enter a valid positive num :  ");
                }

                for (int j = 0; j < numChoices; j++)
                {
                    Console.Write($"Enter choice num {j + 1}:  ");
                    string choiceText = Console.ReadLine();
                    answers.Add(new Answer(j + 1, choiceText));
                }

                Console.Write("Enter the correct answer (1, 2, 3, etc...):  ");
                int correctAnswer;
                while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > numChoices)
                {
                    Console.Write($"Please enter a valid num between 1 and {numChoices} for the correct answer:");
                }


                this.EXAM_OF_SUBJECT.QUESTIONS.Add(new MCQ_Question(header, body, mark, answers, correctAnswer));

            }


        }

    }
}
