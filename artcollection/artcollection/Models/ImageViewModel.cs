using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ArtCollection.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual Image Image { get; set; }

    }
}