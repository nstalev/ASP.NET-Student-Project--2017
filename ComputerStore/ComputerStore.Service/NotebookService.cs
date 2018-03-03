using AutoMapper;
using ComputerStore.Models.BindingModels.Comment;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.EntityModels.Products;
using ComputerStore.Models.ViewModels.Comments;
using ComputerStore.Models.ViewModels.Notebook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStore.Service
{
    public class NotebookService : Service
    {

        public IEnumerable<AllNotebooksVm> GetAllNotebooks()
        {
            IEnumerable<Notebooks> notebooks = Context.Items.OfType<Notebooks>();

            IEnumerable<AllNotebooksVm> vms = Mapper.Map<IEnumerable<Notebooks>, IEnumerable<AllNotebooksVm>>(notebooks);

            return vms;
        }

        public DetailsNotebookVm GetDetailNotebookVM(int id)
        {
            Notebooks notebook = Context.Items.OfType<Notebooks>().FirstOrDefault(book => book.Id == id);

            DetailsNotebookVm vm = Mapper.Map<Notebooks, DetailsNotebookVm>(notebook);


            return vm;
        }

        public IEnumerable<AllNotebooksVm> GetAllNotebooksByBrand(string brand)
        {
            IEnumerable<Notebooks> notebooks = Context.Items.OfType<Notebooks>().Where(product => product.Brand.Contains(brand));

            IEnumerable<AllNotebooksVm> vms = Mapper.Map<IEnumerable<Notebooks>, IEnumerable<AllNotebooksVm>>(notebooks);

            return vms;
        }

        public IEnumerable<AllNotebooksVm> GetAllNotebooksByPrice(string range)
        {
           // string lowerPrice = range.Split('-')[0].ToString();
           // int lowerPriceInt = int.Parse(lowerPrice);
           //
           // string higherPrice = range.Split('-')[1].ToString();
           // int higherPriceInt = int.Parse(lowerPrice);

            IEnumerable<Notebooks> notebooks = Context.Items.OfType<Notebooks>().Where(product => product.Price >100 && product.Price <=1000);

            IEnumerable<AllNotebooksVm> vms = Mapper.Map<IEnumerable<Notebooks>, IEnumerable<AllNotebooksVm>>(notebooks);

            return vms;
        }

        public void AddCommentToProduct(int Id, string userName, AddCommentBM bind)
        {
            Notebooks notebook = Context.Items.OfType<Notebooks>().FirstOrDefault(desk => desk.Id == Id);

            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            ApplicationUser user = Context.Users.FirstOrDefault(user1 => user1.UserName == userName);

            Comment comment = new Comment()
            {
                PersonName = user.Name,
                Date = DateTime.Now,
                Content = bind.Content
            };

            notebook.Comments.Add(comment);
            Context.SaveChanges();

        }



        public AllCommentVm GetAllComents(int Id)
        {
            Notebooks notebooks = Context.Items.OfType<Notebooks>().FirstOrDefault(desk => desk.Id == Id);


            IEnumerable<Comment> comments = notebooks.Comments;

            IEnumerable<CommentVm> allCommentsVM = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentVm>>(comments);

            AllCommentVm vm = new AllCommentVm()
            {
                AllComments = allCommentsVM
            };


            return vm;
        }



    }
}
