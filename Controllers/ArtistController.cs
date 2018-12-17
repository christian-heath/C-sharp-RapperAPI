using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        [HttpGet("Artists")]
        public string Artists()
        {
            string guys = "List of artists:\n";
            foreach(var artist in allArtists)
            {
                guys += "    " + artist.ArtistName + "\n";
            }
            return guys;
        }

        [HttpGet("Artists/Name/{Name}")]
        public string Name(string Name)
        {
            string guys = "List of artists whose stage name contains " + Name + " :\n";
            List<Artist> names = allArtists.Where(art => art.ArtistName.Contains(Name)).ToList();
            foreach(var artist in names)
            {
                guys += "    " + artist.ArtistName + "\n";
            }
            return guys;
        }

        [HttpGet("Artists/RealName/{RealName}")]
        public string RealName(string RealName)
        {
            string guys = "List of artists whose real name contains " + RealName + " :\n";
            List<Artist> names = allArtists.Where(art => art.RealName.Contains(RealName)).ToList();
            foreach(var artist in names)
            {
                guys += "    " + artist.ArtistName + "\n";
            }
            return guys;
        }

        [HttpGet("Artists/HomeTown/{HomeTown}")]
        public string HomeTown(string HomeTown)
        {
            string guys = "List of artists whose home town is " + HomeTown + " :\n";
            List<Artist> names = allArtists.Where(art => art.Hometown == HomeTown).ToList();
            foreach(var artist in names)
            {
                guys += "    " + artist.ArtistName + "\n";
            }
            return guys;
        }

        [HttpGet("Artists/GroupId/{GroupId}")]
        public string GroupId(int GroupId)
        {
            string guys = "List of artists belong to Group " + GroupId + " :\n";
            List<Artist> names = allArtists.Where(art => art.GroupId == GroupId).ToList();
            foreach(var artist in names)
            {
                guys += "    " + artist.ArtistName + "\n";
            }
            return guys;
        }
    }
}