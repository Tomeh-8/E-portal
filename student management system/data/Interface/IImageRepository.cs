using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.data.Interface
{
    public interface IImageRepository
    {
        IEnumerable<ProfileImage> ShowImages();

        ProfileImage GetImage(string id);

        ProfileImage AddImage(ProfileImage image);

        ProfileImage DeleteImage(ProfileImage image);
    }
}
