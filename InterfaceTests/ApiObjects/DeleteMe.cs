﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    class DeleteMe
    {

        public class Rootobject
        {
            public Featured[] featured { get; set; }
        }

        public class Featured
        {
            public string text { get; set; }
            public string title { get; set; }
            public bool sponsored { get; set; }
            public int priority { get; set; }
            public bool scheduled { get; set; }
            public string image { get; set; }
            public Stream stream { get; set; }
        }

        public class Stream
        {
            public string game { get; set; }
            public int viewers { get; set; }
            public int video_height { get; set; }
            public float average_fps { get; set; }
            public string _id { get; set; }
            public int delay { get; set; }
            public DateTime created_at { get; set; }
            public bool is_playlist { get; set; }
            public Preview preview { get; set; }
            public Channel channel { get; set; }
        }

        public class Preview
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
            public string template { get; set; }
        }

        public class Channel
        {
            public bool mature { get; set; }
            public string status { get; set; }
            public string broadcaster_language { get; set; }
            public string display_name { get; set; }
            public string game { get; set; }
            public string language { get; set; }
            public string name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string _id { get; set; }
            public string logo { get; set; }
            public string video_banner { get; set; }
            public string profile_banner { get; set; }
            public string profile_banner_background_color { get; set; }
            public bool partner { get; set; }
            public string url { get; set; }
            public int views { get; set; }
            public int followers { get; set; }
        }

    }
}
