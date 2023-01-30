namespace InternProject.Application.Dto;

public class TokenResponseDto
{
    public AccessToken accessToken { get; set; }

    private TokenResponseDto( bool success, string message, AccessToken accessToken)

    {
        this.accessToken = accessToken;
    }

    //success
    public TokenResponseDto( AccessToken accessToken): this( true, string.Empty, accessToken)
    {
        
    }

    public TokenResponseDto( string message): this( false, message, null)
    {
        
    }
}