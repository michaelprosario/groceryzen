using DocStore.Core.Interfaces;
using DocStore.Core.Responses;
using DocumentStore.Helpers;

namespace DocStore.Core.Services
{
    public class MarkDownConverterService
    {
        private readonly IMarkdownService _markdownService;

        public MarkDownConverterService(IMarkdownService markdownService)
        {
            Require.ObjectNotNull(markdownService, "markdown service is required");
            _markdownService = markdownService;
        }

        public MarkDownServiceResponse Convert(string markDownContent)
        {
            Require.ObjectNotNull(markDownContent, "mark down content should be be provided");
            Require.NotNullOrEmpty(markDownContent, "mark down content should be provided");
            return _markdownService.ConvertMarkDownToHTML(markDownContent);
        }
    }
}