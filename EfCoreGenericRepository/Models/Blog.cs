//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreGenericRepository.Models
{
  public class Blog:IAuditable
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }=new HashSet<Post>();
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
