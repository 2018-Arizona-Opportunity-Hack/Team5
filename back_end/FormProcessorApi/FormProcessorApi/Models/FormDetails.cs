﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormProcessorApi.Models
{
    public class FormDetails
    {
        public int FormDetailsId { get; set; }
        public int TemplateId { get; set; }
        public string Filename { get; set; }
        public bool IsTemplate { get; set; }

        public Question[] Questions { get; set; }

        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
