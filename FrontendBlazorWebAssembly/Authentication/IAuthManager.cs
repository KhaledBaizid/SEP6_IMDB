using Shared;
using System.Security.Claims;

namespace FrontendBlazorWebAssembly.Authentication
{
	public interface IAuthManager
	{
		public Task LoginAsync(User? user);
		Task <int> GetUserId();
		//     public string msgToUser();
		public Task LogoutAsync();
		public Task<ClaimsPrincipal> GetAuthAsync();

		public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
	}
}
