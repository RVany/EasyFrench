using EasyFrench.Data;
using EasyFrench.Data.ViewData;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Pages.Admin.ManageTopic
{
    public class TopicLevelsPageModel : PageModel
    {
        public List<AssignedLevelData> AssignedLevelDataList;

        public void PopulateAssignedLevelData(ApplicationDbContext context,
                                               Topic topic)
        {
            var allLevels = context.Levels;
            var topicLevels = new HashSet<int>(
                topic.TopicLevels.Select(c => c.LevelID));
            AssignedLevelDataList = new List<AssignedLevelData>();

            foreach (var level in allLevels)
            {
                AssignedLevelDataList.Add(new AssignedLevelData
                {
                    LevelID = level.ID,
                    Title = level.Title,
                    Assigned = topicLevels.Contains(level.ID)
                });
            }
        }

        public void UpdateTopicLevels(ApplicationDbContext context,
            string[] selectedLevels, Topic topicToUpdate)
        {
            if (selectedLevels == null)
            {
                topicToUpdate.TopicLevels = new List<TopicLevel>();
                return;
            }

            var selectedLevelsHS = new HashSet<string>(selectedLevels);
            var topicLevels = new HashSet<int>
                (topicToUpdate.TopicLevels.Select(c => c.Level.ID));
            foreach (var level in context.Levels)
            {
                if (selectedLevelsHS.Contains(level.ID.ToString()))
                {
                    if (!topicLevels.Contains(level.ID))
                    {
                        topicToUpdate.TopicLevels.Add(
                            new TopicLevel
                            {
                                TopicID = topicToUpdate.ID,
                                LevelID = level.ID
                            });
                    }
                }
                else
                {
                    if (topicLevels.Contains(level.ID))
                    {
                        TopicLevel levelToRemove
                            = topicToUpdate
                                .TopicLevels
                                .SingleOrDefault(i => i.LevelID == level.ID);
                        context.Remove(levelToRemove);
                    }
                }
            }
        }

    }
}
