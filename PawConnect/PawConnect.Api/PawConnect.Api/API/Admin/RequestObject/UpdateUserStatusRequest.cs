namespace PawConnect.Api.API.Admin.RequestObject
{
    public class UpdateUserStatusRequest
    {
        public bool IsVerified { get; set; }
        public bool IsBlocked { get; set; }
    }
}
