﻿
namespace BlazorDesk.AppModels.Management.Binding
{
    public class RequestEditingBindingModel
    {
        public int Id { get; set; }

        public string AssignToId { get; set; }

        public int? StatusId { get; set; }

        public int? CategoryId { get; set; }
		
		public string Resolution { get; set; }
    }
}
