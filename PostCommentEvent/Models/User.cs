namespace TestPost.Models
{
    internal class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<int> IdPosts { get; set; } = new List<int>();

        public List<int> IdComments { get; set; } = new List<int>();

        public void CreatePost(Post post)
        {
            post.Author = this;
            IdPosts.Add(post.Id);
        }

        public void CreateCommentInPost(Comment comment, Post post)
        {
            comment.Author = this;
            comment.Post = post;
            post.AddComment(comment);
            IdComments.Add(comment.Id);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}