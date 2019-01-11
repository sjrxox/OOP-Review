//Identifies the namespaces containing the datatypes 
//that we want to use or reference in the code in this file

//f12 takes you to where a definition or code is.
//alt+f12 taking you to the definition without going out of the class (dots to navigate)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// declares an area or named-space in which we can 
// place our programmer-defined data types
namespace CSharp.Language.Review
{
    //the namespace plus the class name is what's called
    // a "fully-qualified" class name.
    //the fully-qualified class name for Program is
    //  CSharp.Language.Review.Program

    //keywords = blue
    //class = cyan
    //
    public class Program
    {
        //A static field initialized to a new Random object
        private static Random rnd = new Random();

        // Main() is the entry point
        //static is needed in Main
        //static method
        public static void Main(string[] args)
        {


            //the body of the Main() method
            //acts as the "driver" of my application.
            Program app = new Program(args);

            app.AssignMarks(30, 80);

            foreach (Student person in app.Students)
            {
                System.Console.WriteLine("Name: " + person.Name);
                foreach (EarnedMark item in person.Marks)
                    System.Console.WriteLine("\t" + item);

            }
        }

        //field
        //this field is acting as a "backing store"
        //for the students property
        private List<Student> _students = new List<Student>();

        //property
        //implemented because it is told what to do
        
        //This property provides "controlled access"
        // to do the data in the backing store (the field)
        
        public List<Student> Students
        { 
            get { return _students; }
            set { _students = value; }
        }


        //constructor
        //The job of a constructor is to enusre
        //that all of the fields/properties
        //have "meaningful" values.
        public Program(string[] studentNames)
        {
            WeightedMark[] CourseMarks = new WeightedMark[4];
            CourseMarks[0] = new WeightedMark("Quiz 1", 20);
            CourseMarks[1] = new WeightedMark("Quiz 2", 20);
            CourseMarks[2] = new WeightedMark("Exercises", 25);
            CourseMarks[3] = new WeightedMark("Lab", 35);
            int[] possibleMarks = new int[4] { 25, 50, 12, 35 };

            foreach (string name in studentNames)
            {
                EarnedMark[] marks = new EarnedMark[4];
                for (int i = 0; i < possibleMarks.Length; i++)
                    marks[i] = new EarnedMark(CourseMarks[i], possibleMarks[i], 0);
                Students.Add(new Student(name, marks));
            }
        }
        //XML comment ///

        /// <summary>
        /// This assigns a random mark to each student 
        /// in the <see cref="Students"/> property
        /// </summary>
        /// <param name="min"> The minimum possible earned value for the student's mark</param>
        /// <param name="max"> The maximum possible earned value for the student's mark</param>

        //method
        public void AssignMarks(int min, int max)
        {
            foreach (Student person in Students)
                foreach (EarnedMark item in person.Marks)
                    item.Earned = (rnd.Next(min, max) / 100.0) * item.Possible;

        }
    }
}
