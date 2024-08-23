using School.Repository;
using School.Models;
using School.UnitOfWork;
using SchoolProject.Repositories;
using School.Repositories;

namespace School.UnitsOfWork
{
    class UnitOfWorkMem : IUnitOfWork
    {
        private SectionRepositoryMemory _sectionsRepository;

        private StudentRepositoryMemory _studentsRepository;

        public UnitOfWorkMem()
        {
            this._sectionsRepository = new SectionRepositoryMemory();
            this._studentsRepository = new StudentRepositoryMemory();
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }

        public IStudentRepository StudentsRepository
        {
            get { return (IStudentRepository)this._studentsRepository; }
        }
    }
}
