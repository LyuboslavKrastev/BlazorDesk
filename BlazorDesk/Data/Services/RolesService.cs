﻿//using BasicDesk.Data;
//using BasicDesk.Data.Models;
//using BlazorDesk.Data.Services.Interfaces;
//using System.Collections.Generic;
//using System.Linq;

//namespace BlazorDesk.Data.Services
//{
//    public class RolesService : IRolesService
//    {
//        private BlazorDeskDbContext context;

//        public RolesService(BlazorDeskDbContext context)
//        {
//            this.context = context;
//        }

//        public Role Create(Role role)
//        {
//            this.context.Roles.Add(role);
//            this.context.SaveChanges();
//            return role;
//        }

//        public IEnumerable<Role> GetAll()
//        {
//            return this.context.Roles;
//        }

//        public Role ById(int id)
//        {
//            return this.context.Roles.FirstOrDefault(r => r.Id == id);
//        }
//    }
//}
