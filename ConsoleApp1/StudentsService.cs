namespace ConsoleApp1
{
    public class StudentService
    {
        private Student[] students;
        private int studentCount;

        public StudentService(Student[] students, int initialCount)
        {
            this.students = students;
            this.studentCount = initialCount;
        }


        // 1. ყველა სტუდენტის ჩვენება
        public void ShowAllStudents()
        {
            Console.WriteLine("\nყველა სტუდენტი:");
            foreach (Student s in students)
            {
                s.Print();
            }
        }

        // 2. საუკეთესო სტუდენტის პოვნა
        public void FindBestStudent()
        {
            Student best = students[0];
            foreach (Student student in students)
            {
                if (student.GPA > best.GPA)
                {
                    best = student;
                }
            }

            Console.WriteLine("\nსაუკეთესო სტუდენტი: ");
            best.Print();
        }
        
        // 3. GPA-ის საშუალოს გამოთვლა
        public void CalculateAverageGPA()
        {
            double sum = 0;
            for (int i = 0; i < studentCount; i++)
            {
                sum += students[i].GPA;
            }

            double average = studentCount > 0 ? sum/studentCount : 0;
            Console.WriteLine($"\nGPA-ის საშუალო მაჩვენებელია: {average}");
        }

        // 4. სტუდენტის ძებნა გვარით
        public void SearchByLastName()
        {
            Console.Write("\nშეიყვანეთ გვარი: ");
            string input = Console.ReadLine().Trim().ToLower();

            bool found = false;
            foreach (Student s in students)
            {
                if (s.LastName.ToLower().Contains(input))
                {
                    if (!found)
                    {
                        Console.WriteLine($"\n{input}-ს მონაცემები: ");
                        found = true;
                    }
                    s.Print();
                }
            }

            if (!found)
            {
                Console.WriteLine("სტუდენტი ამ გვარით ვერ მოიძებნა");
            }
        }

        // 5. სტუდენტების დალაგება GPA - ის მიხედვით
        public void SortByGPA()
        {
            for (int i = 0; i < studentCount - 1; i++)
            {
                for (int j = 0; j < studentCount - i - 1; j++)
                {
                    if (students[j] < students[j + 1])
                    {
                        Student s = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = s;
                    }
                }
            }

            Console.WriteLine("\nსტუდენტები დალაგებულია GPA-ის მიხედვით (კლებადობით): ");
            ShowAllStudents();
        }

        // 6. ახალი სტუდენტის დამატება
        public void AddStudent()
        {
            if (studentCount >= students.Length)
            {
                Console.WriteLine("სტუდენტების რაოდენობა სავსეა");
                return;
            }

            try
            {
                Console.Write("სახელი: ");
                string name = Console.ReadLine();

                Console.Write("გვარი: ");
                string lastName = Console.ReadLine();

                Console.Write("ასაკი: ");
                int age = int.Parse(Console.ReadLine());
                if (age <= 16)
                {
                    throw new ArgumentException("ასაკი უნდა იყოს 16-ზე მეტი!");
                }

                Console.Write("Email: ");
                string email = Console.ReadLine();
                if (!email.Contains("@"))
                {
                    throw new ArgumentException("Email უნდა შეიცავდეს '@' სიმბოლოს!");
                }

                Console.Write("ტელეფონი: ");
                string phone = Console.ReadLine();

                Console.Write("GPA (0-4): ");
                double gpa = double.Parse(Console.ReadLine());
                if (gpa < 0 || gpa > 4)
                {
                    throw new ArgumentException("GPA უნდა იყოს 0-დან 4-მდე შუალედში!");
                }

                Console.WriteLine("ფაკულტეტი (0-IT, 1-Business, 2-Design, 3-Medicine): ");
                int facultyChoice = int.Parse(Console.ReadLine());
                if (facultyChoice < 0 || facultyChoice > 3)
                {
                    throw new ArgumentException("ფაკულტეტის კოდი უნდა იყოს 0-დან 3-მდე!");
                }
                Faculty faculty = (Faculty)facultyChoice;

                Student newStudent = new Student(name, lastName, age, email, phone, gpa, faculty);
                students[studentCount++] = newStudent;

                Console.WriteLine("სტუდენტი დაემატა");
            }
            catch (FormatException)
            {
                Console.WriteLine("შეცდომა: გთხოვთ შეიყვანოთ სწორი ფორმატის მონაცემები");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"შეცდომა: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"მოულოდნელი შეცდომა: {ex.Message}");
            }
        }

        // 7. სტუდენტის წაშლა
        public void RemoveStudent()
        {
            Console.Write("\nშეიყვანეთ წასაშლელი სტუდენტის Email: ");
            string email = Console.ReadLine().Trim().ToLower();

            int indexToRemove = -1;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].Email.ToLower() == email)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
            {
                Console.WriteLine("სტუდენტი ამ Email-ით ვერ მოიძებნა.");
                return;
            }

            string removedName = $"{students[indexToRemove].Name} {students[indexToRemove].LastName}";

            for (int i = indexToRemove; i < studentCount - 1; i++)
            {
                students[i] = students[i + 1];
            }
            students[studentCount - 1] = null;
            studentCount--;

            Console.WriteLine($"სტუდენტი შემდეგი მეილით - {email} წაიშალა");
        }
    }
}