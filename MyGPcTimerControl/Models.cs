namespace MyGPcTimerControl
{
    public class TimeRange
    {
        public string basla { get; set; }
        public string bitir { get; set; }
    }

    public class EkSure
    {
        public bool aktif { get; set; }
        public int sure_dakika { get; set; }
        public string verildigi_zaman { get; set; }
    }

    public class DatabaseModel
    {
        public List<TimeRange> saat_araliklari { get; set; }
        public EkSure ek_sure { get; set; }
    }
}