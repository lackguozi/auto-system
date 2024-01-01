using LuckCode.Common;
using LuckCode.Common.Helper;
using LuckCode.IServices;
using LuckCode.Model.Dto;
using LuckCode.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auto_system.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService userService;
        private readonly UserContext userContext;

        public UserController(IUserService userService,UserContext userContext)
        {
            
            this.userService = userService;
            this.userContext = userContext;
        }
        
        [HttpPost]
        public async Task<TokenInfoViewModel> Login([FromServices] IJwtHelper jwtHelper, [FromForm] string username,[FromForm]string password)
        {
            var jwt =string.Empty;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new TokenInfoViewModel()
                {
                    code=50000,
                    success = false,
                    message = "用户名或者密码不能为空",
                };
            }
            string strPwd = MD5Helper.MD5Encrypt32(password);
            string token = string.Empty;
            var userInfo = await userService.Query(a => a.Account == username && a.Password == strPwd);
            
            if (userInfo.Count > 0)
            {
                //long? id = userInfo.FirstOrDefault().ID;
                token = jwtHelper.GetJWTToken(userInfo.FirstOrDefault());
            }
            return new TokenInfoViewModel()
            {
                code = token == string.Empty ? 50000 : 200,
                success = token != string.Empty,
                message = "",
                token = token,
            };
        }
        [HttpGet]
        public async Task<UserInfo> getCurrentUserInfo()
        {
            return await userService.GetCurrentUserInfo();            
        }
        [HttpGet]
        public async Task<List<RouteMenu>> getMenuList()
        {
            return await userService.GetMenuList();
        }
        [HttpGet]
        public async Task<int> Add()
        {
            return await userService.Add(new sysuser()
            {
                 Name = "测试2",
                 Account="lisi",
                 Password= "E10ADC3949BA59ABBE56E057F20F883E",
             });
        }
        [HttpPost]
        public async Task<int> AddTest(sysuser user)
        {
            return await userService.Add(user);
        }
    }
    public class TokenInfoViewModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        public int code { get; set; }
    }
}
