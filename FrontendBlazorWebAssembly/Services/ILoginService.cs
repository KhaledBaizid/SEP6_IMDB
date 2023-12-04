using Shared;

namespace FrontendBlazorWebAssembly.Services
{
	public interface ILoginService
	{
		Task<User?> Login(User user);
	}
}
