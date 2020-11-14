using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TransactionApp.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [AllowedExtensionsAttribute(new string[] { ".csv",".xml"})]
        public IFormFile FileUpload { get; set; }
    }
}
