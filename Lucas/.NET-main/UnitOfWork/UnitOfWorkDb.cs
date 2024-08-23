using School.Repositories;
using School.Repository;
using School.UnitOfWork;
using School.Models;

namespace School.UnitsOfWork
{
    internal class UnitOfWorkDB : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private StudentRepositorySQL _studentRepository;

        private BaseRepositorySQL<Section> _sectionsRepository;


        public UnitOfWorkDB(SchoolContext context)
        {
            this._context = context;
            this._studentRepository = new StudentRepositorySQL(context);
            this._sectionsRepository = new BaseRepositorySQL<Section>(context);

        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentRepository; }
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }
    }
}
