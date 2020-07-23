using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles.Metiers
{
    public class VideoHololive
    {
        private string description;
        private int duration;
        private string translatorChannel;
        private string translatorName;
        private string uploadTime;
        private string videoId;
        private string videoName;
        private string vtuber;

        public string Description { get => description; set => description = value; }
        public int Duration { get => duration; set => duration = value; }
        public string TranslatorChannel { get => translatorChannel; set => translatorChannel = value; }
        public string TranslatorName { get => translatorName; set => translatorName = value; }
        public string UploadTime { get => uploadTime; set => uploadTime = value; }
        public string VideoId { get => videoId; set => videoId = value; }
        public string VideoName { get => videoName; set => videoName = value; }
        public string Vtuber { get => vtuber; set => vtuber = value; }

        public VideoHololive(string des, int dur, string transchan, string transname, string up, string vidid, string vidname, string vtu)
        {
            Description = des;
            Duration = dur;
            TranslatorChannel = transchan;
            TranslatorName = transname;
            UploadTime = up;
            VideoId = vidid;
            VideoName = vidname;
            Vtuber = vtu;
        }
    }
}
