using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet("Groups")]
        public string Groups()
        {
            string groups = "List of groups:\n";
            foreach(var group in allGroups)
            {
                groups += "    " + group.GroupName + "\n";
            }
            return groups;
        }

        [HttpGet("Groups/Name/{Name}")]
        public string GroupName(string Name)
        {
            string groups = "List of groups whose name contains " + Name + " :\n";
            List<Group> names = allGroups.Where(g => g.GroupName.Contains(Name)).ToList();
            foreach(var group in names)
            {
                groups += "    " + group.GroupName + "\n";
            }
            return groups;
        }

        [HttpGet("Groups/GroupId/{GroupId}")]
        public string GroupId(int GroupId)
        {
            string groups = "List of groups whose id matches " + GroupId + " :\n";
            List<Group> names = allGroups.Where(g => g.Id == (GroupId)).ToList();
            foreach(var group in names)
            {
                groups += "    " + group.GroupName + "\n";
            }
            return groups;
        }
    }
}