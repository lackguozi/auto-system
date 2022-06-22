using AutoMapper;
using LuckCode.Common;
using LuckCode.IRepository.Base;
using LuckCode.IServices;
using LuckCode.Model;
using LuckCode.Model.Dto;
using LuckCode.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Services
{
    public class DeptService : BaseService<sysdept>, IDeptService
    {
        private readonly IBaseRepository<sysdept> baseRepository;
        private readonly UserContext currentUser;
        private readonly IMapper mapper;

        public DeptService(IBaseRepository<sysdept> baseRepository, UserContext currentUser, IMapper mapper) : base(baseRepository)
        {
            
            this.baseRepository = baseRepository;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }
        

        public async Task<List<DeptNode>> GetDeptList()
        {
            var res = new List<DeptNode>();
            var lists = await baseRepository.Query();
            if (lists.Count > 0)
            {
                var deptNodes = mapper.Map<List<DeptNode>>(lists);
                var dictDepts = deptNodes.ToDictionary(x => x.ID);
                foreach(var pair in dictDepts)
                {
                    var currNode = pair.Value;
                    var parNode = deptNodes.FirstOrDefault(a => a.ID == currNode.Pid);
                    if(parNode != null)
                    {
                        parNode.Children.Add(currNode);
                    }
                    else
                    {
                        res.Add(currNode);
                    }
                }
            }
            return res;
        }
    }
}
