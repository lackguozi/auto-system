using LuckCode.IRepository;
using LuckCode.IRepository.Base;
using LuckCode.IServices;
using LuckCode.IServices.Base;
using LuckCode.Model;
using LuckCode.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Services
{
    public class DepartmentSevice : BaseService<department>, IDepartmentService
    {
        //private readonly IDepartmentRepository departRepository;

        public DepartmentSevice(IBaseRepository<department> baseRepository) : base(baseRepository)
        {
            //this.departRepository = departRepository;
        }

    }
}
