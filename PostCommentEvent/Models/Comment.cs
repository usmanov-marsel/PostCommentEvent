using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestPost.Models
{
    internal class Comment
    {
        public int Id { get; set; }

        public Post Post { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        public Comment()
        {
            DateOfCreation = DateTime.Now;
        }

        public int GetNumberPastDays()
        {
            return DateTime.Now.Subtract(DateOfCreation).Days;
        }

        public override string ToString()
        {
            return $"{Content} in postId = {Post.Id} authorId = {Author.Id}";
        }
    }
}
