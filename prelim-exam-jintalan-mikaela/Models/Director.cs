using Newtonsoft.Json;
using System.Collections.Generic;

namespace prelim_exam_jintalan_mikaela.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }
        public int id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}