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
        [HttpGet("parlist")]
        public async Task<List<DeptNode>> GetParDeptList()
        {
            return await deptService.GetParDeptList();
        }
        [HttpPost("add")]
        public async Task<bool> Add(SysDeptDto node)
        {
            return await deptService.AddDept(node) ;
        }
        [HttpPost("addtest")]
        public bool Add1(SysDeptDto node)
        {
            return true;
        }
    }
}
