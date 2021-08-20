using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Models
{
    public class MasterMovie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImgLink { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public int Fk_TypeId { get; set; }
    }
}
