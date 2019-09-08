using BlazorDesk.Data.Models;
using BlazorDesk.DataModels.Interfaces;
using Shared.Constants.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models.Requests
{
    public class RequestReply : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestConstants.SubjectMinLength)]
        [MaxLength(RequestConstants.SubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MinLength(RequestConstants.DescriptionMinLength)]
        [MaxLength(RequestConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public ICollection<ReplyAttachment> Attachments { get; set; } = new List<ReplyAttachment>();
    }
}
