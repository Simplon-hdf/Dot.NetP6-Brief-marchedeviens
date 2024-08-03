namespace MarcheEtDevient.Server.Repository
{
    public interface IRepository
    {
        public interface IRepository<T, TKey>
        {
            Task<T> GetById(TKey id);                   //Recupere par un id
            Task<IEnumerable<T>> GetAll();              //Recupere tout
            void Add(T model);                    //creer
            void Update(T model, TKey id);        // met a jour
            void Delete(TKey id);                 // supprime
        }
    }
}
}
