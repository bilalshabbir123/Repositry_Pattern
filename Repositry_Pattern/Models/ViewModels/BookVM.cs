using Repositry_Pattern.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repositry_Pattern.Models.ViewModels
{
    public class BookVM
    {
        public BookVM()
        {

        }
        public BookVM(BookDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Author = row.Author;
            Description = row.Description;
            Publisher = row.Publisher;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}