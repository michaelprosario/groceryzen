using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocumentStore.Helpers;
using DocumentStore.Requests;
using DocumentStore.Responses;
using Marten;
using Marten.Pagination;

namespace DocStore.Infrastructure.Marten
{
    public class MartenUserDataServices : IUserDataServices
    {
        private readonly IDocumentSession _session;

        public MartenUserDataServices(IDocumentSession session)
        {
            Require.ObjectNotNull(session, "Session should not be null");
            _session = session;
        }

        public User Add(User entity)
        {
            Require.ObjectNotNull(entity, "entity should not be nuull");

            _session.Store(entity);
            _session.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _session.Delete(entity);
            _session.SaveChanges();
        }

        public bool RecordExists(string id)
        {
            Require.NotNullOrEmpty(id, "id is required");
            return _session.Query<User>().Count(e => e.Id.Equals(id)) > 0;
        }

        public User GetById(string id)
        {
            Require.NotNullOrEmpty(id, "id is required");
            return _session.Query<User>().Single(e => e.Id.Equals(id));
        }

        public User GetUserByName(string userName)
        {
            Require.NotNullOrEmpty(userName, "userName is required");
            return _session.Query<User>().Single(e => e.UserName.Equals(userName));
        }

        public List<User> List()
        {
            return _session.Query<User>().ToList();
        }

        public void Update(User entity)
        {
            _session.Store(entity);
            _session.SaveChanges();
        }

        public bool UserNameUsed(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentException("UserName needs to be defined");
            return _session.Query<User>().Any(e => e.UserName.Equals(userName));
        }

        public async Task<GetDocumentsResponse<User>> GetPagedList(GetDocumentsQuery query)
        {
            var pagedList = await _session.Query<User>().ToPagedListAsync(query.Page, query.Rows);
            var response = new GetDocumentsResponse<User>
            {
                TotalItemCount = pagedList.TotalItemCount,
                PageCount = pagedList.PageCount,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                FirstItemOnPage = pagedList.FirstItemOnPage,
                LastItemOnPage = pagedList.LastItemOnPage,
                Documents = pagedList.ToList()
            };

            return response;
        }
    }
}