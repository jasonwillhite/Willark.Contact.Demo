using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Willark.Contact.Demo.Models
{
    [Dapper.Contrib.Extensions.Table("Item")]
    public class Item
    {
        [Dapper.Contrib.Extensions.Key]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
