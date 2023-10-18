using DocStore.Core.Responses;

namespace DocStore.Core.Interfaces
{
    public interface IMarkdownService
    {
        MarkDownServiceResponse ConvertMarkDownToHTML(string html);
    }
}