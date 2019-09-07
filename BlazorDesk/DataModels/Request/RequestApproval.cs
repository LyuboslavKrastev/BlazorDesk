using BlazorDesk.DataModels.Interfaces;
using Constants;
using Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.DataModels.Requests
{
    public class RequestApproval : IEntity
    {
        public int Id { get; set; }

        [MinLength(RequestConstants.SubjectMinLength)]
        [MaxLength(RequestConstants.SubjectMaxLength)]
        public string Subject { get; set; }

        public string Description { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public string RequesterId { get; set; }
        //public User Requester { get; set; }

        //public string ApproverId { get; set; }
        //public User Approver { get; set; }

        public int StatusId { get; set; } = WebConstants.PendingApprovalStatusId;
        public ApprovalStatus Status { get; set; }

        public string ApproverComment { get; set; }
    }
}
