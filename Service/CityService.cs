using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;

namespace Service
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = _unitOfWork.CityRepository;
        }


        public CityDTO GetById(int id) =>
            _cityRepository.GetById(id);

        public void Dispose() =>
            _unitOfWork.Dispose();
    }
}
