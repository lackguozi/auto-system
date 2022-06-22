using LuckCode.IServices;
using LuckCode.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auto_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private readonly IDeptService deptService;

        public DeptController(IDeptService deptService)
        {
            this.deptService = deptService;
        }
        [HttpGet("list")]
        public async Task<List<DeptNode>> GetDeptList()
        {
            return await deptService.GetDeptList();
        }
    }
}
