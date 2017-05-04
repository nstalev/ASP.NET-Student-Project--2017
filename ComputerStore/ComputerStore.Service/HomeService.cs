using System.Collections.Generic;
using System.Linq;
using ComputerStore.Models.ViewModels.Notebook;
using ComputerStore.Models.EntityModels.Products;
using AutoMapper;

namespace ComputerStore.Service
{
    public class HomeService : Service
    {
        public IEnumerable<AllNotebooksVm> GetAllNotebooks()
        {
            IEnumerable<Notebooks> notebooks = Context.Items.OfType<Notebooks>();

            IEnumerable<AllNotebooksVm> vms = Mapper.Map<IEnumerable<Notebooks>, IEnumerable<AllNotebooksVm>>(notebooks);

            return vms;
        }
    }
}
