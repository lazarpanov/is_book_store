using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Book : BaseEntity
    {
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public string? BookImage { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Rating { get; set; }
        public string? author { get; set; }
        [Required]
        public Guid? AuthorId { get; set; }
        public string? publisher { get; set; }
        [Required]
        public Guid? PublisherId { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCarts { get; set; }
        public virtual IEnumerable<BookInOrder>? BooksInOrder { get; set; }

    }
}
