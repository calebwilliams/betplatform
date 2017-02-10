using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    class DeleteMe
    {
        //azubu response 

        public class Rootobject
        {
            public Datum[] data { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
        }

        public class Datum
        {
            public User user { get; set; }
            public string title { get; set; }
            public string url_thumbnail { get; set; }
            public string url_thumbnail_mobile { get; set; }
            public bool is_live { get; set; }
            public Category category { get; set; }
            public object language { get; set; }
            public int followers_count { get; set; }
            public int view_count { get; set; }
            public int vods_view_count { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string url_channel { get; set; }
            public string url_stream { get; set; }
            public string url_chat { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public Team[] teams { get; set; }
            public Profile profile { get; set; }
            public string display_name { get; set; }
            public string alt_name { get; set; }
        }

        public class Profile
        {
            public object country { get; set; }
            public object time_zone { get; set; }
            public object locale { get; set; }
            public object ui_primary_language { get; set; }
            public string in_game_name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string dob { get; set; }
            public object phone_number { get; set; }
            public object skype_account { get; set; }
            public string twitter_id { get; set; }
            public string twitter_account { get; set; }
            public string twitter_url { get; set; }
            public string facebook_id { get; set; }
            public string facebook_account { get; set; }
            public string facebook_url { get; set; }
            public string website { get; set; }
            public object youtube_url { get; set; }
            public object instagram_url { get; set; }
            public object e_sportspedia_url { get; set; }
            public string biography { get; set; }
            public string url_photo_small { get; set; }
            public string url_photo_large { get; set; }
        }

        public class Team
        {
            public Team1 team { get; set; }
            public Role role { get; set; }
        }

        public class Team1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string title { get; set; }
        }

        public class Role
        {
            public int id { get; set; }
            public string name { get; set; }
            public string role { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public string url_thumbnail { get; set; }
        }

    }
}
