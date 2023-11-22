using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp1.Pages.Something
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        
        public IndexModel(
            UserManager<IdentityUser> userManager)
            
        {
            _userManager=userManager;
        }
        public void OnGet()
        {
            IdentityUser? user =  _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                //Trying to get the list of roles assigned to the user
                //IUserRoleStore interface remains to be implemented    
                //AggregateException: One or more errors occurred. (Store does not implement IUserRoleStore<TUser>.)
                IList<string> roles = _userManager.GetRolesAsync(user).Result;

                if (roles != null)
                {
                    foreach (string role in roles) 
                    { 
                    
                    }
                }
            }

        }
    }
}
