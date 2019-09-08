using BlazorDesk.Data.Models;
using BlazorDesk.Data.Models.Requests;
using BlazorDesk.Data.Models.Solution;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Constants;

namespace BlazorDesk.Data
{
    /* Because we are using Identity which needs to store information in a database 
        we're not inheriting from DbContext but instead from IdentityDbContext.  
        The IdentityDbContext base class contains all the configuration EF needs to manage the Identity database tables. */
    public class BlazorDeskDbContext : IdentityDbContext<User>
    {
        public BlazorDeskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestReply> RequestReplies { get; set; }
        public DbSet<ReplyAttachment> ReplyAttachments { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<RequestCategory> RequestCategories { get; set; }

        public DbSet<RequestAttachment> RequestAttachments { get; set; }

        public DbSet<RequestApproval> RequestApprovals { get; set; }

        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

        public DbSet<RequestNote> RequestNotes { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<SolutionAttachment> SolutionAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Request>()
             .HasOne(u => u.Requester)
             .WithMany(r => r.Requests)
             .HasForeignKey(u => u.RequesterId);

            builder.Entity<Request>()
                .HasMany(r => r.Attachments)
                .WithOne(a => a.Request)
                .HasForeignKey(a => a.RequestId);

            builder.Entity<Solution>()
                .HasMany(s => s.Attachments)
                .WithOne(a => a.Solution)
                .HasForeignKey(a => a.SolutionId);

            //seed approval statuses
            builder.Entity<ApprovalStatus>().HasData(
                new ApprovalStatus { Id = WebConstants.PendingApprovalStatusId, Name = WebConstants.PendingApprovalStatusName },
                new ApprovalStatus { Id = WebConstants.ApprovedApprovalStatusId, Name = WebConstants.ApprovedApprovalStatusName },
                new ApprovalStatus { Id = WebConstants.DeniedApprovalStatusId, Name = WebConstants.DeniedApprovalStatusName }
            );

            builder.Entity<RequestStatus>().HasData(
               new RequestStatus { Id = WebConstants.OpenStatusId, Name = "Open" },
               new RequestStatus { Id = WebConstants.ClosedStatusId, Name = "Closed" },
               new RequestStatus { Id = WebConstants.RejectedStatusId, Name = "Rejected" },
               new RequestStatus { Id = WebConstants.OnHoldStatusId, Name = "On Hold" },
               new RequestStatus { Id = WebConstants.ForApprovalStatusId, Name = "For Approval" }
          );

            builder.Entity<RequestCategory>().HasData(
               new RequestCategory { Id = WebConstants.FirstCategoryId, Name = "First Category" },
               new RequestCategory { Id = WebConstants.SecondCategoryId, Name = "Second Category" },
               new RequestCategory { Id = WebConstants.ThirdCategoryId, Name = "Third Category" },
               new RequestCategory { Id = WebConstants.FourthCategoryId, Name = "Fourth Category" },
               new RequestCategory { Id = WebConstants.FifthCategoryId, Name = "Fifth Category" }
          );


            base.OnModelCreating(builder);
        }

    }
}
