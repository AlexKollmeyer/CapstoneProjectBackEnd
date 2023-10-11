namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class WishListDto
    {
        public string UserId { get; set; }
        public List<GameDetailsDto> WishListedGames { get; set; }
            

    }
}
