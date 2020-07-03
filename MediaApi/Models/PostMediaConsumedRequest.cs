using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Models
{
    public class PostMediaConsumedRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Kind { get; set; }
        public string RecommendedBy { get; set; }
        public bool Consumed { get; set; }
        public DateTime? DateConsumed { get; set; }
    }
}


