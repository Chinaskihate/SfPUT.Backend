using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Interfaces.Photos
{
    public interface IPhotoService
    {
        public Task<bool> SavePhoto(Guid userId, Guid postId, IFormFile photo);

        public Task<byte[]> DownloadPhoto(Guid postId);

        public Task<bool> DeletePhoto(Guid userId, Guid postId);
    }
}
