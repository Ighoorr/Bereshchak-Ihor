using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class Student
    {

        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public University University { get; set; }
        [NotMapped]
        public string UniversityName {
            get
            {
                return this.University?.Name;
            } }

    }











}