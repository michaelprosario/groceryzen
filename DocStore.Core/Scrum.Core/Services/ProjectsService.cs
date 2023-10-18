using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentStore.Responses;
using FluentValidation;
using Scrum.Core.Entities;
using Scrum.Core.ValueObjects;

namespace Scrum.Core.Services
{

    public interface IProjectsService
    {
      Project GetNewProject();
    }

    public class ProjectsService : IProjectsService
    {
        public ProjectsService()
        {
        }

        public Project GetNewProject()
        {
            Project aProject = new Project();
            aProject.Name = "";
            aProject.Description = "";
            aProject.Notes = "";
            aProject.Id = Guid.NewGuid().ToString();
            aProject.CreatedAt = DateTime.UtcNow;
            aProject.State = "active";

            int numberOfSprints = 1 * 12 * 2;
            aProject.Sprints = new List<Sprint>();
            for (int sprint = 0; sprint < numberOfSprints; sprint++)
            {
                var aSprint = new Sprint();
                aSprint.IterationPath = "sprint-" + sprint;
                aSprint.DayCount = 10;
                aSprint.Goal = "";
                aSprint.EstEffort = 0;
                aSprint.CreatedAt = DateTime.UtcNow;
                aProject.Sprints.Add(aSprint);
            }

            aProject.ProjectStatusList = MakeDropDownItemList("active|on-hold|done");
            aProject.TaskStatusList = MakeDropDownItemList("new|in-progress|review|resolved|done|blocked");
            aProject.UserStoryStatusList = MakeDropDownItemList("new|active|review|closed|blocked");

            return aProject;
        }

        private List<DropDownItem> MakeDropDownItemList(string pipeListOfItems)
        {
            string[] items = pipeListOfItems.Split('|');
            List<DropDownItem> response = new List<DropDownItem>();
            int index = 1;
            foreach (var item in items)
            {
                var aItem = new DropDownItem { Key = item, Value = item, SortOrder = index };
                index++;
                response.Add(aItem);
            }
            return response;
        }
    }

}