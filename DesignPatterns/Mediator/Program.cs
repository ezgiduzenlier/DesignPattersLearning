//Bu desen nesneler arasındaki doğrudan iletişimi sınırlar ve sadece mediator nesnesi üzerinden haberleşmeye sağlar..



Mediator mediator = new Mediator();//mediator tanımladık

Teacher e = new Teacher(mediator);//teacherın iletişim aracısının mediator olduğunu tanımladık.
e.Name = "Ezgi";
mediator.Teacher = e;

Student d = new Student(mediator);
d.Name = "Derin";

Student s = new Student(mediator);
s.Name = "Salih";

mediator.Students = new List<Student> { d, s };
e.SendNewImageUrl("slide1.jpg");
Console.ReadLine();




abstract class CourseMember
{
    protected Mediator Mediator;//protected da büyük harf ile yazılır.
    protected CourseMember(Mediator mediator)
    {
        Mediator = mediator;
    }
}

class Teacher : CourseMember
{
    public string Name { get; set; }
    public Teacher(Mediator mediator) : base(mediator)
    {

    }
    internal void RecieveQuestion(string question, Student student) //recieve=kabul etmek
    {
        Console.WriteLine("Teacher recived question from {0}, {1}",student.Name,question);
    }
    public void SendNewImageUrl(string url)
    {
        Console.WriteLine("Teachr changed slide : {0}",url);
        Mediator.UpdateImage(url);
    }
    public void AnsverQuestion(string answer,Student student)
    {
        Console.WriteLine("Teacher answered question {0}, {1}",student.Name,answer);
    }
}

class Student : CourseMember
{
    public Student(Mediator mediator) : base(mediator)//iletişim kuracağı sistemi tanımlamış olduk.
    {
    }

    public string Name { get; internal set; }

    internal void RecieveImage(string url)
    {
        Console.WriteLine("Student recieved image {0}",url);
    }

    internal void RecieveAnswer(string answer)
    {
        Console.WriteLine("Student recieved answer {0}",answer);
    }
}

class Mediator
{
    public Teacher Teacher { get; set; }//dersin bir öğretmeni var
    public List<Student> Students { get; set; }//birden çok öğrencisi var o yüzden list.

    public void UpdateImage(string url)// öğretmen tüm öğrencilere foto göndermek isterse.
    {
        foreach (var student in Students)
        {
            student.RecieveImage(url);
        }
    }
    public void SendQuestin(string question,Student student)// öğrenci soru gönderiyor
    {
       Teacher.RecieveQuestion(question,student);//mediatoe acısından öğrencinin sorusunu göndermektir ama teacher acısından o soruyu almaktır.
    }

    public void SendAnswer(string answer, Student student)
    {
       student.RecieveAnswer(answer);
    }
}