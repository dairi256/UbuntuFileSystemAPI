namespace UbuntuFileSystemAPI.Models
{
    public class FileRecord
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public long SizeInBytes { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
