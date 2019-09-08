using System.Collections.Generic;

namespace BlazorDesk.AppModels.Management.View

{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
