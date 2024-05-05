using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public String Heading { get; set; }
        public String PageTitle { get; set; }
        public String Content { get; set; }
        public String ShortDescription { get; set; }
        public String FeaturedImageUrl { get; set; }
        public String UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        //vt den etiketleri secip ekranda gostermek icin 
        public IEnumerable<SelectListItem> Tags {  get; set; }
        //etiketleri yakalamk icin
        public string SelectedTag {  get; set; }
    }
}
