using BlazorDesk.DataModels.Interfaces;
using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models.Requests
{
    public class ReplyAttachment : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestAttachmentConstants.FileNameMinLength)]
        [MaxLength(RequestAttachmentConstants.FileNameMaxLength)]
        public string FileName { get; set; }

        [Required]
        [MinLength(RequestAttachmentConstants.PathToFileMinLength)]
        [MaxLength(RequestAttachmentConstants.PathToFileMaxLength)]
        public string PathToFile { get; set; }

        public int ReplyId { get; set; }
        public RequestReply Reply { get; set; }
    }
}
