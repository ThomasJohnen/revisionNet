using School.Repository;
using School.Models;
using School.Repositories;

namespace School.UnitOfWork
{
    interface IUnitOfWork
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }
    }
}