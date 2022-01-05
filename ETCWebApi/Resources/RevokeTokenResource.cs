using System.ComponentModel.DataAnnotations;

namespace ETCWebApi.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}