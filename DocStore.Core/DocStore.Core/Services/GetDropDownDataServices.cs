using System;
using System.Collections.Generic;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;

namespace DocStore.Core.Services
{
    public interface IGetDropDownDataService
    {
        List<DropDownItem> GetDropDownItems();
    }

    public class GetDropDownDataService : IGetDropDownDataService
    {
        private readonly IDropDownDataRepository repository;

        public GetDropDownDataService(IDropDownDataRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<DropDownItem> GetDropDownItems()
        {
            return repository.GetDropDownItems();
        }
    }
}