using Area.Services.Abstract;
using Areas.Entities;
using Areas.Entities.Areas.Entities;
using Areas.Repository;

namespace Area.Service
{
    public class AreaServices : IAreaServices
    {
        private readonly Area1Repository _area1repository;
        public AreaServices(Area1Repository area1repository)
        {
            _area1repository = area1repository;
        }
        public Task<IEnumerable<AreasAdmin>> GetAllAsync()
        {
            return _area1repository.GetAllAsync();
        }

        public Task<AreasAdmin?> GetByIdAsync(int id)
        {
            return _area1repository.GetByIdAsync(id);
        }

        public Task<int> crearareaAsync(AreasAdmin area)
        {
            return _area1repository.crearareaAsync(area);
        }




        public Task<int> DeleteAsync(int id)
        {
            return _area1repository.DeleteAsync(id);

        }

        public Task<int> editarareaAsync(AreasAdmin area)
        {
            return _area1repository.editarareaAsync(area);


        }

        public Task<IEnumerable<Accion>> GetIdJefaturaAsync()
        {
           return _area1repository.GetIdJefaturaAsync();
        }
        //}
        //public Task<int> AsignacionAsync(string id)
        //{
        //    return _area1repository.editarareaAsync(id);
        //}



    }
}