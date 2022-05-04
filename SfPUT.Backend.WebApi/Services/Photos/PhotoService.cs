using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Application.Interfaces.Photos;

namespace SfPUT.Backend.WebApi.Services.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPostDataService _dataService;

        public PhotoService(IWebHostEnvironment env, IPostDataService dataService)
        {
            _env = env;
            _dataService = dataService;
        }

        public async Task<bool> SavePhoto(Guid userId, Guid postId, IFormFile photo)
        {
            var post = await _dataService.Get(postId);
            if (post.User.Id != userId)
            {
                return false;
            }
            using (var stream = new FileStream(GetPhysicalPath(postId), FileMode.OpenOrCreate))
            {
                await photo.CopyToAsync(stream);
            }

            return true;
        }

        public async Task<byte[]> DownloadPhoto(Guid postId)
        {
            var physicalPath = GetPhysicalPath(postId);
            if (!File.Exists(physicalPath))
            {
                return null;
            }

            byte[] data = await File.ReadAllBytesAsync(physicalPath);
            return data;
        }

        public async Task<bool> DeletePhoto(Guid userId, Guid postId)
        {
            var post = await _dataService.Get(postId);
            if (post.User.Id != userId)
            {
                return false;
            }

            string physicalPath = GetPhysicalPath(postId);
            if (!File.Exists(physicalPath))
            {
                return false;
            }
            File.Delete(physicalPath);
            return true;
        }

        private string GetPhysicalPath(Guid postId)
        {
            string fileName = postId.ToString() + ".png";
            return _env.ContentRootPath + "/Photos/" + fileName;
        }
    }
}
