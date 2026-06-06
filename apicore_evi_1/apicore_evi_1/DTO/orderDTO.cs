using apicore_evi_1.Models;

namespace apicore_evi_1.DTO
{
    public class orderDTO
    {
        public Order Order { get; set; }
        public IFormFile PicFile { get; set; }
    }
}
