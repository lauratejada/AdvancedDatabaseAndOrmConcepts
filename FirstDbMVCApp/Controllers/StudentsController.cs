using FirstDbMVCApp.Data;
using FirstDbMVCApp.Models;
using FirstDbMVCApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace FirstDbMVCApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly FirstDbMVCAppContext _context;

        public StudentsController(FirstDbMVCAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Student == null)
            {
                return NotFound();
            } else
            {
                return View(_context.Student.Include(s => s.Course).ToHashSet());
            }
        }

        public IActionResult Create()
        {
            // in create method, add a dropdown list of all course names
            HashSet<Course> courses = _context.Course.ToHashSet();

            CUStudentVM vm = new CUStudentVM(courses);
            vm.Student = new Student();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CUStudentVM vm)
        {
            Student student = vm.Student;
            student.CourseId = vm.SelectedCourseId;

            if (ModelState.IsValid)
            {
                _context.Student.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                return View(student);
            }
        }

        /////////////
        // GET: Students/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            Student? studentDetails = _context.Student
                .Include(s => s.Course)
                .FirstOrDefault(m => m.Id == id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            return View(studentDetails);
        }

        //UPDATE
        // GET: Students/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            Student student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            CUStudentVM vm = new CUStudentVM(_context.Course.ToHashSet());

            vm.Student = student;
            vm.SelectedCourseId = student.CourseId;

            //ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", student.CourseId);
            return View(vm);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(CUStudentVM vm)//Guid id, [Bind("Id,FullName,CourseId")] Student student)
        {
            Student student = vm.Student;
            student.CourseId = vm.SelectedCourseId;

            if (ModelState.IsValid)
            {
                _context.Student.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Problem("Error handling Student entity changes.");
            }

        }

        // GET: Students/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            Student student = _context.Student.First(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]//, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            if (_context.Student == null)
            {
                return Problem("There is no students record.");
            }

            Student student = _context.Student.Find(id);
            
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            else if (student == null) 
            {
                return NotFound();
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
