namespace Blog.Web.Models.Domain
{
    public class BlogPostLike
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; } //blogpost ile iliskili olacaktir. 
        public Guid UserId {  get; set; } //gercekten begenen kullanicinni id si
    }
}
