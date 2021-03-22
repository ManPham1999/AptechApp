using System;
namespace DatingApp_Backend.DTO
{
    public class PhotoDTO
    {
        public PhotoDTO()
        {
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
