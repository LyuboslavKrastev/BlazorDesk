﻿using System.Collections.Generic;

namespace BlazorDesk.AppModels.View
{
    public class SolutionDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedOn { get; set; }

        public string Author { get; set; }

        //public IEnumerable<SolutionAttachmentViewModel> Attachments { get; set; }
    }
}
