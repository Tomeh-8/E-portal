using student_management_system.data.Interface;
using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly StudentDbcontext _db;

        public ImageRepository(StudentDbcontext db)
        {
            _db = db;
        }
        public ProfileImage AddImage(ProfileImage image)
        {
            _db.profileImage.Add(image);
            _db.SaveChanges();
            return image;
        }

        public ProfileImage DeleteImage(ProfileImage image)
        {
            _db.profileImage.Remove(image);
            _db.SaveChanges();
            return image;
        }

        public ProfileImage GetImage(string id)
        {
            return _db.profileImage.Find(id);
        }

        public IEnumerable<ProfileImage> ShowImages()
        {
            return _db.profileImage;
        }
    }
}
