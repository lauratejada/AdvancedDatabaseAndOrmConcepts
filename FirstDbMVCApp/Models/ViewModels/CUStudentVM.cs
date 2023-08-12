using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstDbMVCApp.Models.ViewModels
{ 
    public class CUStudentVM
    { 
        public Student? Student { get; set; }
        public int SelectedCourseId { get; set; }
        public List<SelectListItem> SelectItems = new List<SelectListItem>();

        public CUStudentVM(ICollection<Course> courses)
        {
            foreach(Course c in courses)
            {
                SelectItems.Add(new SelectListItem { Text = c.Title, Value = c.Id.ToString() });
            }
        }

        public CUStudentVM() { }
    }
}
