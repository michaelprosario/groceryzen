using DocStore.Core.Interfaces;
using DocStore.Core.Responses;
using Markdig;

namespace DocStore.Infrastructure
{
    public class MarkDownService : IMarkdownService
    {
        public MarkDownServiceResponse ConvertMarkDownToHTML(string markDownContent)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();

            var response = new MarkDownServiceResponse { HtmlContent = Markdown.ToHtml(markDownContent, pipeline) };

            return response;
        }
    }
}