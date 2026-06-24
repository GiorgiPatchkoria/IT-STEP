namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[10];
            int studentCount = CreateInitialStudents(students);
            StudentService studentService = new StudentService(students, studentCount);

            string choice = "0";
            while (choice != "8"){
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice){
                    case "1":
                        studentService.ShowAllStudents();
                        break;
                    case "2":
                        studentService.FindBestStudent();
                        break;
                    case "3":
                        studentService.CalculateAverageGPA();
                        break;
                    case "4":
                        studentService.SearchByLastName();
                        break;
                    case "5":
                        studentService.SortByGPA();
                        break;
                    case "6":
                        studentService.AddStudent();
                        break;
                    case "7":
                        studentService.RemoveStudent();
                        break;
                    case "8":
                        break;
                    default:
                        Console.WriteLine("არასწორი ოპერაცია, სცადეთ თავიდან");
                        break;
                    }
            }
        }

        static int CreateInitialStudents(Student[] students)
        {
            int count = 0;
            students[count++] = new Student("საბა", "ჩიტაია", 20, "saba.chitaia@gmail.com", "598325586", 2.3, Faculty.IT);
            students[count++] = new Student("ნინო", "მაღლაკელიძე", 21, "nino.m@gmail.com", "597293395", 2.1, Faculty.Business);
            students[count++] = new Student("ლუკა", "სირაძე", 19, "luka.siradze@gmail.com", "551293819", 3.4, Faculty.Design);
            students[count++] = new Student("მარიამ", "მნათობიშვილი", 22, "marimnatobishvili@gmail.com", "598293849", 1.7, Faculty.Medicine);
            students[count++] = new Student("გიორგი", "წერეთელი", 20, "giorgi.tsereteli.1@gmail.com", "555019283", 3.8, Faculty.IT);
            students[count++] = new Student("ანა", "მაჭარაძე", 23, "ana.matcharadze@gmail.com", "598291029", 3.1, Faculty.Business);
            students[count++] = new Student("ნიკა", "გაბელაია", 18, "nika.gabelaia@gmail.com", "597293017", 3.0, Faculty.Design);
            students[count++] = new Student("გიგი", "ნემსაძე", 21, "nemsadze.gigi@gmail.com", "599196738", 2.7, Faculty.Medicine);
            students[count++] = new Student("თამარ", "ბანეთიშვილი", 20, "tamuna.banetishvili@gmail.com", "591839101", 2.5, Faculty.IT);
            students[count++] = new Student("ვერიკო", "გიორგაძე", 19, "veriko.giorgadze@gmail.com", "555678592", 2.5, Faculty.Business);
            return count;
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. ყველა სტუდენტის ჩვენება");
            Console.WriteLine("2. საუკეთესო სტუდენტის პოვნა");
            Console.WriteLine("3. GPA-ის საშუალოს გამოთვლა");
            Console.WriteLine("4. სტუდენტის ძებნა გვარით");
            Console.WriteLine("5. სტუდენტების დალაგება GPA-ის მიხედვით");
            Console.WriteLine("6. ახალი სტუდენტის დამატება");
            Console.WriteLine("7. სტუდენტის წაშლა");
            Console.WriteLine("8. პროგრამიდან გასვლა");
            Console.Write("აირჩიეთ ოპერაცია: ");
        }
    }
}