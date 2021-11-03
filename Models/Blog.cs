using System;
using System.Collections.Generic;

namespace Class_10.Models
{
    public class Blog
    {
        public int BlogId{ get; set; }

        public string Name { get; set; }

        // entity framework relationship
        // navigation properties
        public List<Post> Posts{ get; set; }
    }
}