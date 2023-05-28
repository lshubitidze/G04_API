using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;

namespace Service
{
    public class RelatedPersonService : IRelatedPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelatedPersonRepository _relatedPersonRepository;


        public RelatedPersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _relatedPersonRepository = _unitOfWork.RatedPersonRepository;
        }

        public RelatedPersonDTO GetById(int id) =>
            _relatedPersonRepository.GetById(id);

        public RelatedPersonDTO Insert(RelatedPersonDTO model)
        {
            _relatedPersonRepository.Insert(model);
            _unitOfWork.SaveChanges();
            return model;
        }

        public void Update(RelatedPersonDTO model)
        {
            _relatedPersonRepository.Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(RelatedPersonDTO model)
        {
            _relatedPersonRepository.Delete(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _relatedPersonRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void Dispose() =>
            _unitOfWork.Dispose();
    }
}

