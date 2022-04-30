using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<TagVm>> GetAllTags();

        Task<IEnumerable<TagVm>> GetTagsByName(string name);

        Task<Guid> CreateTag(string name);

        Task<bool> DeleteTag(Guid id);

        Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> tagsIds);

        // Task<bool> AddPostToTags(Post post, IEnumerable<Tag> tags);
    }
}
