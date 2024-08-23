using Repositories;
using RevisionLinqToEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RevisionLinqToEntities.Repositories
{
    class SectionsRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections;
public void Delete(Section entity)
        {
            _sections.Remove(entity);
        }

        public IList<Section> GetAll()
        {
            return _sections;
        }

        public Section GetById(int id)
        {
            return _sections[id];
        }

        public void Insert(Section entity)
        {
            _sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section sectionFound = (SearchFor(predicate)).FirstOrDefault();
            if (sectionFound == null)
            {
                _sections.Add(sectionFound);
                return true;
            }
            return false;
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return _sections.AsQueryable().Where(predicate).ToList();
        }
    }
}
