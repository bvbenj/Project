using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Data.SqlClient;

namespace Databaseproject
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection myconnectionList = new SqlConnection("server=mssql.cs.mtsu.edu;User Id=c8115901;password=zg4oDUzo;database=c8115901db");
            bool loggedInYet = false;
            string username;
            string password;
            //change to connection string to the right one
            while (loggedInYet == false)
            {
                Console.WriteLine("Please enter username:");
                username = Console.ReadLine();
                while (username == "")
                {
                    Console.WriteLine("ERROR: Please try entering username again.");
                    username = Console.ReadLine();
                }

                Console.WriteLine("Please enter password:");
                password = Console.ReadLine();
                while (password == "")
                {
                    Console.WriteLine("ERROR: Please try entering username again.");
                    password = Console.ReadLine();
                }

                string ssList = String.Format("SELECT * FROM TeacherInformation WHERE UserName = '{0}' and Pass = '{1}'", username, password);
                SqlDataAdapter mydataList = new SqlDataAdapter(ssList, myconnectionList);
                DataSet mysetList = new DataSet();
                SqlCommand cmd = new SqlCommand(ssList, myconnectionList);
                mydataList.Fill(mysetList, "mytable");


                string ttList = String.Format("SELECT * FROM StudentInformation WHERE UserName = '{0}' and Pass = '{1}'", username, password);

                SqlDataReader readerList;
                try
                {
                    myconnectionList.Open();
                    readerList = cmd.ExecuteReader();

                    if (readerList.HasRows)
                    {
                        Program p = new Program();
                        p.teacherOptions(username);
                        loggedInYet = true;
                    }
                }
                catch (Exception err)
                {
                    Console.Write(err);
                }
                finally
                {
                    myconnectionList.Close();
                }

                SqlDataAdapter mydataList2 = new SqlDataAdapter(ttList, myconnectionList);
                DataSet mysetList2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand(ttList, myconnectionList);
                mydataList2.Fill(mysetList, "mytable");



                SqlDataReader readerList2;
                try
                {
                    myconnectionList.Open();
                    readerList2 = cmd2.ExecuteReader();

                    if (readerList2.HasRows)
                    {
                        Program p = new Program();
                        p.studentOptions(username);
                        loggedInYet = true;
                    }
                }
                catch (Exception err)
                {
                    Console.Write(err);
                }
                finally
                {
                    myconnectionList.Close();
                }

                Console.WriteLine("Incorrect username or password. Please try again.");
            }

        }
        void doSomething()
        {
            SqlConnection myconnectionList = new SqlConnection("server=mssql.cs.mtsu.edu;User Id=c8115901;password=zg4oDUzo;database=c8115901db");
            //connect to database
            //query to check username and password
            //SELECT * FROM USERS WHERE USERNAME = {0} AND PASSWORD = {1}, X, Y
            string ssList = String.Format("SELECT * FROM TeacherInformation");
            //this does something import
            SqlDataAdapter mydataList = new SqlDataAdapter(ssList, myconnectionList);
            DataSet mysetList = new DataSet();
            SqlCommand cmd = new SqlCommand(ssList, myconnectionList);
            mydataList.Fill(mysetList, "mytable");

            SqlDataReader readerList;
            try
            {
                myconnectionList.Open();
                readerList = cmd.ExecuteReader();
                while (readerList.Read())
                {
                    Console.WriteLine("{0}", readerList["FirstName"]);
                }
            }
            catch (Exception err)
            {
                Console.Write(err);
            }
            finally
            {
                myconnectionList.Close();
            }


        }
        void createAssignment()
        {
            string year;
            string month;
            string day;
            string correct;
            Console.WriteLine("Creating assignment date...");
            Console.WriteLine("Enter year:");
            year = Console.ReadLine();
            Console.WriteLine("Enter month:");
            month = Console.ReadLine();
            Console.WriteLine("Enter day:");
            day = Console.ReadLine();

            Console.WriteLine("{0}/{1}/{2}", day,month,year);
            Console.WriteLine("Is this correct? y or n");
            correct = Console.ReadLine();
           if (correct == "y")
           {
               Console.WriteLine("Submitting...");
               SqlConnection myconnectionList = new SqlConnection("server=mssql.cs.mtsu.edu;User Id=c8115901;password=zg4oDUzo;database=c8115901db");
               //connect to database
               //query to check username and password
               //SELECT * FROM USERS WHERE USERNAME = {0} AND PASSWORD = {1}, X, Y
               string ssList = "INSERT INTO CourseWork VALUES('hw4','project','asdfasdf','ry','12c','12/12/2110', '12/13/2222')";
               //this does something import
               SqlDataAdapter mydataList = new SqlDataAdapter(ssList, myconnectionList);
               DataSet mysetList = new DataSet();
              SqlCommand cmd = new SqlCommand(ssList, myconnectionList);


               SqlDataReader readerList;
               try
               {
                   myconnectionList.Open();
                   cmd.ExecuteNonQuery();
               }
               catch (Exception err)
               {
                   Console.Write(err);
               }
               finally
               {
                   myconnectionList.Close();
               }
           
           }
           else
           {
               Console.WriteLine("Please try again...Restarting.");
               createAssignment();
           }

        }
        void editAssignment()
        {
            string year;
            string month;
            string day;
            string correct;
            Console.WriteLine("Updating assignment date...");
            Console.WriteLine("Enter year:");
            year = Console.ReadLine();
            Console.WriteLine("Enter month:");
            month = Console.ReadLine();
            Console.WriteLine("Enter day:");
            day = Console.ReadLine();

            Console.WriteLine("{0}/{1}/{2}", day, month, year);
            Console.WriteLine("Is this correct? y or n");
            correct = Console.ReadLine();
            if (correct == "y")
            {
                Console.WriteLine("Submitting update...");

            }
            else if( correct == "n"){
                Console.WriteLine("Please try again...");
                editAssignment();
            }
            else
            {
                Console.WriteLine("Incorrect input. Please try again...Restarting.");
                createAssignment();
            }

        }
        void viewAllDates()
        {
            Console.WriteLine("All Assignments dates:");
            //loop and print all assignments from database

        }
        void viewAllDueDates()
        {
            Console.WriteLine("All due dates for all classes:");
            //loop through
        }
        void viewAllDescriptions()
        {
            Console.WriteLine("All course descriptions...");

        }
        void teacherOptions(string teacher){

            string selected;



            //create assignment date
            //edit assignment date
            //delete assignment
            //view assignment date for all classes
            //view due date for all classes
            //view description for all classes
            Console.WriteLine("1. Create assignment date");
            Console.WriteLine("2. Edit assignment date");
            Console.WriteLine("3. Delete assignment");
            Console.WriteLine("4. View all assignment dates");
            Console.WriteLine("5. View all due dates for all classes");
            Console.WriteLine("6. View all descriptions");
           selected =  Console.ReadLine();
           if (selected == "1")
           {
               createAssignment();
           }
           else if (selected == "2")
           {
               editAssignment();
           }
           else if (selected == "3")
           {
               string todo;
               Console.WriteLine("Please enter assignment to Delete.");
               todo = Console.ReadLine();
               deleteAssignment(todo, teacher);
           }
           else if (selected == "4")
           {
               viewAllDates();
           }
           else if (selected == "5")
           {
               viewAllDueDates();
           }
           else if (selected == "6")
           {
               viewAllDescriptions();
           }
           else if (selected == "logout")
           {
               Console.WriteLine("Logging out...\n");
               Environment.Exit(0);
           }
           else
           {
               Console.WriteLine("Please try again.");
           }
          
        }

        void viewAssignmentDate(bool isActive, bool seeAll, string courseName)
        {
            if (isActive)
            {
                if (seeAll)
                {
                    //display all active courses
                    Console.WriteLine("Viewing all active assignment due dates");
                }
                else
                {
                    Console.WriteLine("Viewing active assignments due dates for {0}", courseName);
                    //display by choice and active
                }

            }
            else
            {
                if (seeAll)
                {
                    Console.WriteLine("Viewing all assignment due dates");
                    //see all courses
                }
                else
                {
                    Console.WriteLine("Viewing assignment due dates for {0}", courseName);
                    //see only specific course
                }

            }
        }
        void viewAssignmentAssigned(bool isActive, bool seeAll, string courseName)
        {
            if (isActive)
            {
                if (seeAll)
                {
                    //display all active courses
                    Console.WriteLine("Viewing all active assignment dates");
                }
                else
                {
                    Console.WriteLine("Viewing active assignments assignment date for {0}", courseName);
                    //display by choice and active
                }

            }
            else
            {
                if (seeAll)
                {
                    //see all courses
                    Console.WriteLine("Viewing all assignment dates");
                }
                else
                {
                    //see only specific course
                    Console.WriteLine("Viewing assignment dates for {0}", courseName);
                }

            }

        }
        void viewCourseDesc(bool isActive, bool seeAll, string key)
        {
            if (isActive)
            {
                if (seeAll)
                {
                    Console.WriteLine("Viewing all active class descriptions");
                    //display all active courses
                }
                else
                {
                    Console.WriteLine("Viewing active class {0} description", key);
                    //display by key and active
                }

            }
            else
            {
                if (seeAll)
                {
                    Console.WriteLine("Viewing all class descriptions");
                    //see all courses
                }
                else
                {
                    Console.WriteLine("Viewing class {0} description", key);
                    //see only specific key
                }

            }
        }
        //5
        void changeEmailAlert(bool isActive, bool changeAll, string choice, string course)
        {
            if (isActive)
            {
                if (changeAll)
                {
                    Console.WriteLine("Changing all active classes to {0}", choice);
                    //display all active courses
                }
                else
                {
                    Console.WriteLine("Changing active class {0} to {1}", course, choice);
                    //display by choice and active
                }

            }
            else
            {
                if (changeAll)
                {
                    Console.WriteLine("Changing all classes to {0}", choice);
                    //see all courses
                }
                else
                {
                    Console.WriteLine("Changing class {0} to {1}", course, choice);
                    //see only specific course
                }

            }


        }
        void viewCourseWork(bool isActive, bool seeAll, string choice)
        {
            if (isActive)
            {
                if (seeAll)
                {
                    Console.WriteLine("Viewing all active coursework...");
                    //display all active courses
                }
                else
                {
                    Console.WriteLine("Viewing active coursework from {0}", choice);
                    //display by choice and active
                }

            }
            else
            {
                if (seeAll)
                {
                    Console.WriteLine("Viewing all coursework...");
                    //see all courses
                }
                else
                {
                    Console.WriteLine("Viewing coursework for {0}", choice);
                    //see only specific course
                }

            }
        }
        void studentOptions(string username)
        {
            string selected;
            string Course = "test";

            Console.WriteLine("1. View assignment due date for specific class");
            Console.WriteLine("2. View assignment assigned date for specific class");
            Console.WriteLine("3. View course description for specific class");
            Console.WriteLine("4. View active coursework for specific class ");
            Console.WriteLine("5. change email alert setting for specific class");
            Console.WriteLine("6. View assignment due date for all classes");
            Console.WriteLine("7. View assignment assigned date for for all classes");
            Console.WriteLine("8. View course description for all classes");
            Console.WriteLine("9. View active coursework for all classes");
            Console.WriteLine("10. change email alert setting for all classes");
            Console.WriteLine("11. View active assignment due date for specific class");
            Console.WriteLine("12. View active assignment assigned date for specific class");
            Console.WriteLine("13. View active course description for specific class");
            Console.WriteLine("14. change email alert setting for specific active class");
            Console.WriteLine("15. View assignment due date for all active classes");
            Console.WriteLine("16. View assignment assigned date for for all active classes");
            Console.WriteLine("17. View course description for all active classes");
            Console.WriteLine("18. View active coursework for all active classes");
            Console.WriteLine("19. change email alert setting for all active classes");
            selected = Console.ReadLine();
            //view assignment for a specific class, doesn't matter if active
            if (selected == "1")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewAssignmentDate(false, false, Course);
            }
            //view assignment assiged date for a specific class, doesn't matter if active
            else if (selected == "2")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewAssignmentAssigned(false, false, Course);
            }
            //view course description for a specific class, doesn't matter if active
            else if (selected == "3")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewCourseDesc(false, false, Course);
            }
            //view active coursework for a specfic class
            else if (selected == "4")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewCourseWork(true, false, Course);
            }
            //change email alert for a specific class
            else if (selected == "5")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                changeEmailAlert(false, true, "yes", Course);
            }
            //view assignment due date for all classes, doesn't matter if active
            else if (selected == "6")
            {
                viewAssignmentDate(false, true, "nothing");
            }
            //view assignment date for all classes, doesn't matter if active
            else if (selected == "7")
            {
                viewAssignmentAssigned(false, true, "nothing");
            }
            //view course description of all classes, doesn't matter if active
            else if (selected == "8")
            {
                viewCourseDesc(false, true, "nothing");
            }
            //view active coursework for all classes
            else if (selected == "9")
            {
                viewCourseWork(true, true, "nothing");
            }
            //change email alert for all classes
            else if (selected == "10")
            {
                changeEmailAlert(false, true,"yes", "nothing");
            }
            //view active assignment due date for specific class
            else if (selected == "11")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewAssignmentDate(true, false, Course);
            }
            //view active assignment due date for specific class
            else if (selected == "12")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }

                viewAssignmentAssigned(true, false, Course);

            }
            //view active course description for specific class
            else if (selected == "13")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                viewCourseDesc(true, false, Course);
            }
            //change email alart for active, specific class
            else if (selected == "14")
            {
                Console.WriteLine("Please enter class number...");
                Course = Console.ReadLine();
                if (Course == "")
                {
                    Console.WriteLine("Something went wrong. Try again...");
                    studentOptions(username);
                }
                changeEmailAlert(true, false,"yes", Course);
            }
            //view assignment due date for all active classes
            else if (selected == "15")
            {
                viewAssignmentDate(true, true, "nothing");
            }
            //view assignment assigned date for all active classes
            else if (selected == "16")
            {
                viewAssignmentAssigned(true, true, "nothing");
            }
            //view course description for all active classes
            else if (selected == "17")
            {
                viewCourseDesc(true, true, "nothing");

            }
            //view all active coursework for all active classes
            else if (selected == "18")
            {
                viewCourseWork(true, true, "nothing");
            }
            //change email alart for all active classes
            else if (selected == "19")
            {
                changeEmailAlert(true, true,"yes", "nothing");
            }
            //user did something wrong
            else
            {
                Console.WriteLine("Please try again.");
                studentOptions(username);
            }

        }

        void deleteAssignment(string key, string teacher)
        {

            SqlConnection sqlConn = new SqlConnection("server=mssql.cs.mtsu.edu;User Id=c8115901;password=zg4oDUzo;database=c8115901db");
            SqlCommand sqlComm = new SqlCommand(key, sqlConn);
            sqlConn.Open();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = String.Format("DELETE FROM CourseWork WHERE Name='{0}'",key);
            sqlComm.Parameters.Add("@key", SqlDbType.VarChar);
            sqlComm.Parameters["@key"].Value = key;
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
            Program p = new Program();

            p.teacherOptions(teacher);
        }
    }
}
