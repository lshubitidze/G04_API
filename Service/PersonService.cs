using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;
using System.Linq.Expressions;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _personRepository = _unitOfWork.PersonRepository;
        }

        public IQueryable<PersonDTO> Search(Expression<Func<PersonDTO, bool>> predicate) =>
            _personRepository.Search(predicate);

        public PersonDTO GetById(int id) =>
            _personRepository.GetById(id);

        public void UploadOrChangeImage(int personId, string image)
        {
            _personRepository.UploadOrChangeImage(personId, image);
            _unitOfWork.SaveChanges();
        }

        public PersonDTO Insert(PersonDTO model)
        {
            _personRepository.Insert(model);
            _unitOfWork.SaveChanges();
            return model;
        }

        public void Update(PersonDTO model)
        {
            _personRepository.Update(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(PersonDTO model) 
        {
            _personRepository.Delete(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id) 
        {
            _personRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void Dispose() =>
            _unitOfWork.Dispose();
    }
}
