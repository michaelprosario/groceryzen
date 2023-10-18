using System.Collections.Generic;
using DocStore.Core.Entities;

namespace DocStore.Core.Interfaces
{
    public interface IDropDownDataRepository
    {
        List<DropDownItem> GetDropDownItems();
    }
}