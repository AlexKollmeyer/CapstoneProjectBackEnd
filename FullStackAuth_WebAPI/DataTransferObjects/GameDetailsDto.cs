namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class GameDetailsDto
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public  string Thumbnail { get; set;}
        public string CheapestCurrentDeal { get; set; }
    }
}
