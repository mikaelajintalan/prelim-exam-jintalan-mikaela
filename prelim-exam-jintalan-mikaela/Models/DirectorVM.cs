using Microsoft.AspNetCore.Mvc.Rendering;

namespace prelim_exam_jintalan_mikaela.Models
{
    public class DirectorVM
    {
        public int? MovieID { get; set; }
        public int DirectorID { get; set; }
        public SelectList Movies { get; set; }
        public Director Director { get; set; }
    }
}