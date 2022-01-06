using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class University
    { 
        public University()
        {
            Students = new HashSet<Student>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    
    }







}