
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace Blog.Web.Repositories
{
    public class CloudinaryImageRepository : IImageRepository
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        //configurasyondaki(appsetting.json) bilgilerini burada kullanmak icin

        public CloudinaryImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        public async Task<string> UploadAysnc(IFormFile file)
        {
            /*
            //kullaniciyi cloud a eriştiriyoruz ? sanirim
            var client = new Cloudinary(account);

            //yukleme kismi
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName= file.FileName
            };
            var uploadResult = await client.UploadAsync(uploadParams);

            //dosya yuklemenin basarili olup olmadigi kontrol ediliyor.
            if(uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }
            return null;
            */


            // Cloudinary nesnesini oluşturun
            Cloudinary cloudinary = new Cloudinary(account);

            // Dosya yükleme işlemi
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };

            // Yükleme işlemini gerçekleştirin
            var uploadResult = cloudinary.Upload(uploadParams);

            // Yükleme işleminin başarılı olup olmadığını kontrol edin
            if (uploadResult.StatusCode == HttpStatusCode.OK)
            {
                // Güvenli URI'yi döndürün
                return uploadResult.SecureUri.ToString();
            }
            else
            {
                // Başarısız durumda null döndürün
                return null;
            }


        }
    }
}
