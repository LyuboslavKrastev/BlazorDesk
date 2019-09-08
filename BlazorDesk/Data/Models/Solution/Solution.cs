using BlazorDesk.Data.Models;
using BlazorDesk.Data.Models.Solution;
using BlazorDesk.DataModels.Interfaces;
using Shared.Constants.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models.Solution
{
    public class Solution :IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(SolutionConstants.TitleMinLength)]
        [MaxLength(SolutionConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(SolutionConstants.ContentMinLength)]
        [MaxLength(SolutionConstants.ContentMaxLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public int Views { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public ICollection<SolutionAttachment> Attachments { get; set; } = new List<SolutionAttachment>();
    }
}
