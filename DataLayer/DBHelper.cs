using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBHelper
    {
        LMSdbEntities db = new LMSdbEntities();

        public List<Student_Progress> GetStudentProgresses()
        {
            return db.Student_Progress.ToList();
        }

        public List<Cours> GetCourses()
        {
            LMSdbEntities db = new LMSdbEntities();
            return db.Courses.ToList();
        }

        public List<User_Details> GetUserDetails()
        {
            LMSdbEntities db = new LMSdbEntities();
            return db.User_Details.ToList();
        }

        public bool EnrollUser(Student_Progress sp)
        {
            try
            {
                List<User_Details> u = db.User_Details.ToList();
                foreach(var x in u)
                {
                    if (x.UserName == sp.UserName)
                    {
                        sp.UserID = x.UserID;
                        break;
                    }
                }
                sp.Certi_status = "Not Generated";
                sp.Prog_status = 0;
                sp.Test_scores = 0;
                db.Student_Progress.Add(sp);
                db.SaveChanges();
                return true;

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool AddCourse(Cours c)
        {
            try
            {
                db.Courses.Add(c);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool AddUserDetails(User_Details u)
        {
            try
            {
                db.User_Details.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool EditCourse(Cours c)
        {
            try
            {
                Cours cou = db.Courses.Find(c.CourseID);
                db.Courses.Remove(cou);
                db.Courses.Add(c);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool EditStudent(User_Details u)
        {
            try
            {
                User_Details user = db.User_Details.Find(u.UserID);
                db.User_Details.Remove(user);
                db.User_Details.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }
       
        public bool DeleteCourse(int id)
        {
            bool status = false;
            try
            {
                Cours cou = db.Courses.Find(id);
                db.Courses.Remove(cou);
                db.SaveChanges();
                status =  true;
            }
            catch
            {
            }
            return status;
        }
        public bool DeleteStudent(int id)
        {
            bool status = false;
            try
            {
                User_Details cou = db.User_Details.Find(id);
                db.User_Details.Remove(cou);
                db.SaveChanges();
                status = true;
            }
            catch
            {

            }
            return status;
        }

        public bool DetailsCourse(int id)
        {

            try
            {
                Cours cou = db.Courses.Find(id);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }

        public User_Details ValidateUser(string username, string password)
        {
            return db.User_Details.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }

        public bool AddRegistrationDetails(User_Details u)
        {
            try
            {
                db.User_Details.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
            }
            return false;
        }
        public bool EditTest(Student_Progress u)
        {
            try
            {
                List<Student_Progress> cou = db.Student_Progress.ToList();
                foreach (var i in cou)
                {
                    if (u.UserID == i.UserID && u.CourseID == i.CourseID && u.UserName == i.UserName)
                    {
                        i.Test_scores = 100;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool EditCertificate(Student_Progress u)
        {
            try
            {
                List<Student_Progress> cou = db.Student_Progress.ToList();
                foreach (var i in cou)
                {
                    if (u.UserID == i.UserID && u.CourseID == i.CourseID && u.UserName == i.UserName )
                    {
                        if (i.Test_scores == 100 && i.Prog_status >= 85)
                        {
                            i.Certi_status = "Generated";
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }    
       public bool EditProgress(Student_Progress u)
        {
            try
            {
                List<Student_Progress> cou = db.Student_Progress.ToList();
                foreach (var i in cou)
                {
                    if (u.UserID == i.UserID && u.CourseID == i.CourseID && u.UserName == i.UserName)
                    {
                        i.Prog_status = u.Prog_status;
                        if(!(i.Prog_status >= 0 && i.Prog_status <= 100))
                        {
                            return false;
                        }
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}
