using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Domain
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Kind { get; set; }
        public string RecommendedBy { get; set; }
        public bool Consumed { get; set; }
        public DateTime? DateConsumed { get; set; }

        public bool Removed { get; set; }
    }
}
/*
 * {
    id: string;
    title: string;
    kind: KindType;
    recommendedBy: string;
    consumed: boolean;
    dateConsumed: null | string
   }
*/
