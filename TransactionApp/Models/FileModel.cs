using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TransactionApp.Models
{
    public class FileModel: IValidatableObject
    {
        [Required(ErrorMessage = "Please select a file.")]
        [AllowedExtensionsAttribute(new string[] { ".csv",".xml"})]
        public IFormFile FileUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> members = new List<string>();
            members.Add("FileUpload");
            var size = FileUpload.Length;
            if (size > (1 * 1024 * 1024))
                yield return new ValidationResult("File size is bigger than 1MB.", members);
                //ModelState.AddModelError("FileUpload", ex.Message);
        }
    }
}
