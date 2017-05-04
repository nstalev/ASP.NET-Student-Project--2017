using ComputerStore.Data;

namespace ComputerStore.Service
{
    public abstract class Service
    {

        public Service()
        {
            this.Context = new ComputerStoreContext();
        }
        protected ComputerStoreContext Context { get; }

    }
}
