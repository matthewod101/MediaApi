using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Models
{
    public class GetMediaResponse
    {
        public List<MediaResponseItem> Data { get; set; }
        public string FilteredBy { get; set; }
    }

    public class MediaResponseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Kind { get; set; }
        public string RecommendedBy { get; set; }
        public bool Consumed { get; set; }
        public DateTime? DateConsumed { get; set; }
    }
}
