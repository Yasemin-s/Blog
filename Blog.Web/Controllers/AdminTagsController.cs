using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogDbContext blogDbContext;

        public AdminTagsController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        //formdan tag ekleme
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //formdan geeln veriler buraya gelecek. 
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //tagdomain modeli addrequest ile eşleştirildi. 
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            blogDbContext.Tags.Add(tag);
            blogDbContext.SaveChanges();
            return View("Add");
        }
    }
}
