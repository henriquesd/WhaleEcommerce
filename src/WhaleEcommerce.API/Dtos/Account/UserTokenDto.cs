using System.Collections.Generic;

namespace WhaleEcommerce.API.Dtos.Account
{
    public class UserTokenDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimDto> Claims { get; set; }
    }
}
