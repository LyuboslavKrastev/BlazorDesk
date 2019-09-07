using BlazorDesk.DataModels.Interfaces;
using Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.DataModels.Requests
{
    public class RequestAttachment : IEntity, IAttachment
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

        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
