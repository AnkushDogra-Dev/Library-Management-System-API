namespace LMS.Identity.API.Application.DTOs
{
    public record AuthToken
    {
        public string Token { get; private set; }
        public AuthToken(string token)
        {
            Token = token;
        }
    }
}