namespace AudioPerformer
{
    /// <summary>
    /// 这个类用于打包传递(soundTouch无法涵盖的)播放信息，即是否变速不变调、是否启用抗锯齿、是否启用快速搜索算法(启用后减少cpu负担，但会引起轻微音质降低)
    /// </summary>
    internal class SoundTouchProfile
    {
        //是否变速不变调
        public bool UseTempo { get; set; }
        //是否启用抗锯齿
        public bool UseAntiAliasing { get; set; }

        public bool UseQuickSeek { get; set; }

        public SoundTouchProfile(bool useTempo, bool useAntiAliasing)
        {
            UseTempo = useTempo;
            UseAntiAliasing = useAntiAliasing;
        }
    }
}