public class Question
{
    public string questionText {get;set;}
    public int questionNumber {get;set;}
    public string answer {get;set;}
    public string A {get;set;}
    public string B {get;set;}
    public string C {get;set;}
    public string D {get;set;}
    public string userAnswer {get;set;}
    public bool isCorrect()
    {
        return userAnswer.Equals(answer);
    }
}