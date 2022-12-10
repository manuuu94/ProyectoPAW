using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  
    
        [Route("api/[controller]")]
        [ApiController]

    public class RoleController : Controller
    {

            //instancia la interfaz de la entidad
            private IRoleDAL roleDAL;
            //constructor
            public RoleController()
            {
            roleDAL = new RoleDalImpl(new Entities.PROYECTO_PAWContext());
            }

            #region Consultar
            [HttpGet]
            public JsonResult Get()
            {
                IEnumerable<Role> roles;
                roles = roleDAL.GetAll();

                return new JsonResult(roles);
            }


            [HttpGet("{id}")]
            public JsonResult Get(int id)
            {
                Role Role;
                Role = roleDAL.Get(id);
                return new JsonResult(Role);
            }
        }
    }
#endregion
