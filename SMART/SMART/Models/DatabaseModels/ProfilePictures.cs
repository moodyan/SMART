using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class ProfilePictures
    {
        public ProfilePictures()
        {
            Employees = new HashSet<Employees>();
        }

        public int ProfilePictureId { get; set; }
        public byte[] Picture { get; set; }
        public string PictureName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
