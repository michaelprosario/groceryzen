using System.Collections.Generic;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;

namespace DocStore.Infrastructure
{
    public class DropDownDataRepository : IDropDownDataRepository
    {
        public List<DropDownItem> GetDropDownItems()
        {
            var dropDownData = new List<DropDownItem>();

            for (var i = 0; i < 10; i++)
            {
                var item = new DropDownItem();
                item.DropDown = "Category";
                item.Key = "Thing " + i;
                item.Value = "Thing " + i;
                dropDownData.Add(item);
            }

            return dropDownData;
        }
    }
}