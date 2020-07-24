using System;
using System.Collections.Generic;
using System.Text;

namespace YamakazeDiscordBot.Modules.ClasseUtiles.Metiers
{
    public class VideoHololive
    {
        private string duration;
        private string translatorChannel;
        private string translatorName;
        private string uploadTime;
        private string videoId;
        private string videoName;
        private string vtuber;
        public string Duration { get => duration; set => duration = value; }
        public string TranslatorChannel { get => translatorChannel; set => translatorChannel = value; }
        public string TranslatorName { get => translatorName; set => translatorName = value; }
        public string UploadTime { get => uploadTime; set => uploadTime = value; }
        public string VideoId { get => videoId; set => videoId = value; }
        public string VideoName { get => videoName; set => videoName = value; }
        public string Vtuber { get => vtuber; set => vtuber = value; }

        public VideoHololive(string dur, string transchan, string transname, string up, string vidid, string vidname, string vtu)
        {
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