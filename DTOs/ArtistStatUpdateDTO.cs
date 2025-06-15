using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class ArtistStatUpdateDTO
    {
        [Range(0, int.MaxValue)]
    public int? Followers { get; set; }

    [Range(0, int.MaxValue)]
    public int? MonthlyListeners { get; set; }

    [Range(0, int.MaxValue)]
    public int? Views { get; set; }

    [Range(0, int.MaxValue)]
    public int? Likes { get; set; }

    [Range(0, int.MaxValue)]
    public int? Comments { get; set; }
        
    }
}