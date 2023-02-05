using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TestPost.Models
{
    internal class Post
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public User Author { get; set; }

        public List<int> Comments { get; set; } = new List<int>();

        public string Content { get; set; }

        public string Preview { get; set; }

        public Post()
        {
            DateOfCreation= DateTime.Now;
        }

        public int GetNumberPastDays()
        {
            return DateTime.Now.Subtract(DateOfCreation).Days;
        }

        public int GetNumberPastDaysFrom(DateTime date)
        {
            return date.Subtract(DateOfCreation).Days;
        }

        public void AddComment(Comment comment)
        {
            comment.Post = this;
            Comments.Add(comment.Id);
        }

        public override string ToString()
        {
            return $"{Content} created in {DateOfCreation.Date.ToString("dd/MM/yyyy")} by {Author}";
        }

    }
}
