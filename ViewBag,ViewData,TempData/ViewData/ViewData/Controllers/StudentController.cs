using Microsoft.AspNetCore.Mvc;

namespace ViewData.Controllers
{
    public class StudentController : Controller
    {
        //ViewData is a Dictionary
        //ViewData and ViewBag both use the same dictionary internally.
        //So you cannot have ViewData Key matches with the property name of ViewBag,
        //otherwise it will throw a runtime exception.
        public ActionResult Index()
        {
            IList<Student> studentList = new List<Student>();
            studentList.Add(new Student() { StudentName = "Bill" });
            studentList.Add(new Student() { StudentName = "Steve" });
            studentList.Add(new Student() { StudentName = "Ram" });

            ViewData["students"] = studentList;

            return View();
        }

        //you can add keyvalue pair
        public ActionResult Index()
        {
            ViewData.Add("Id", 1);
            ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            ViewData.Add(new KeyValuePair<string, object>("Age", 20));

            return View();
        }
    }
}
