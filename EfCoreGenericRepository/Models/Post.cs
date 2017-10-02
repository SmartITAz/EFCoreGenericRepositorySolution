//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using System;
using System.ComponentModel.DataAnnotations;

namespace EfCoreGenericRepository.Models
{
  public class Post : IAuditable
  {
    [Key]
    public int PostId { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime TimeStamp { get; set; }
    public Blog Blog { get; set; }

    public DateTime? CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string CreatedBy { get; set; }
  }
}
