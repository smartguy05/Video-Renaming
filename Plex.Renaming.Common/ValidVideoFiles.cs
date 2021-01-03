using System.ComponentModel;

namespace Video.Renaming.Common
{
    public enum ValidVideoFiles
    {
        [Description("mkv")]
        Mkv,
        [Description("mp4")]
        Mp4,
        [Description("mov")]
        Mov,
        [Description("avi")]
        Avi,
        [Description("flv")]
        Flv,
        [Description("webm")]
        WebM,
        [Description("wmv")]
        Wmv
    }
}