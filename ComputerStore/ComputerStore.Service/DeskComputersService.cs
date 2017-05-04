using System;
using System.Collections.Generic;
using System.Linq;
using ComputerStore.Models.ViewModels.DeskComputers;
using ComputerStore.Models.EntityModels.Products;
using AutoMapper;
using ComputerStore.Models.BindingModels.Comment;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.ViewModels.Comments;

namespace ComputerStore.Service
{
    public class DeskComputersService : Service
    {
        public IEnumerable<AllDescCompVM> GetAllNotebooks()
        {
            IEnumerable<DeskComputers> deskComputers = Context.Items.OfType<DeskComputers>();

            IEnumerable<AllDescCompVM> vms = Mapper.Map<IEnumerable<DeskComputers>, IEnumerable<AllDescCompVM>>(deskComputers);

            return vms;
        }

        public DetailsDescCompVM GetDetailNotebookVM(int id)
        {
            DeskComputers deskComputer = Context.Items.OfType<DeskComputers>().FirstOrDefault(desk => desk.Id == id);

            DetailsDescCompVM vm = Mapper.Map<DeskComputers, DetailsDescCompVM>(deskComputer);

            return vm;
        }

        public IEnumerable<AllDescCompVM> GetAllDescByBrand(string brand)
        {
            IEnumerable<DeskComputers> deskComputers = Context.Items.OfType<DeskComputers>().Where(product => product.Brand.Contains(brand));

            IEnumerable<AllDescCompVM> vms = Mapper.Map<IEnumerable<DeskComputers>, IEnumerable<AllDescCompVM>>(deskComputers);

            return vms;
        }

 


        public void AddCommentToProduct(int id, string userName, AddCommentBM bind)
        {
            DeskComputers computer = Context.Items.OfType<DeskComputers>().FirstOrDefault(desk => desk.Id == id);

            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            ApplicationUser user = Context.Users.FirstOrDefault(user1 => user1.UserName == userName);

            Comment comment = new Comment()
            {
                PersonName = user.Name,
                Date = DateTime.Now,
                Content = bind.Content
            };

            computer.Comments.Add(comment);
            Context.SaveChanges();

        }



        public AllCommentVm GetAllComents(int Id)
        {
            DeskComputers deskComputer = Context.Items.OfType<DeskComputers>().FirstOrDefault(desk => desk.Id == Id);


            IEnumerable<Comment> comments = deskComputer.Comments;

            IEnumerable<CommentVm> allCommentsVM = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentVm>>(comments);

            AllCommentVm vm = new AllCommentVm()
            {
                AllComments = allCommentsVM
            };


            return vm;
        }

    }
}
