using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rede.Aplicacao.DTO;
using Teste.Dominio.Entidades;
using Teste.Servico.Servicos;
using Teste.Servico.Validacoes;

namespace Teste.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BaseServico<Usuario> service = new BaseServico<Usuario>();

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO item)
        {
            try
            {
                Usuario user = new Usuario();
                user.Email = item.Email;
                user.Nome  = item.Nome;
                user.Senha = item.Senha;

                service.Post<UsuarioValidador>(user);

                return Ok("Usuário criado:" + user.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UsuarioDTO item)
        {
            try
            {
                var user = service.Get(id);
                
                if(user != null)
                {
                    user.Nome = item.Nome;
                    user.Email = item.Email;
                    user.Senha = item.Senha;

                    service.Put<UsuarioValidador>(user);
                    return Ok(item);
                }

                return NotFound("Usuário não encontrado, impossível atualizar");
                
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            try
            {

                if (service.Get(id) != null)
                {
                    service.Delete(id);
                    return Ok("Usuário deletado: " + id);
                    
                }

                return NotFound("Usuário não existe: " + id);
                
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet(Name = "Todos")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpGet("{id}", Name = "GetOne")]
        public IActionResult GetOne(int id)
        {
            try
            {
                if (service.Get(id) != null)
                    return Ok(service.Get(id));
                return NotFound("Usuário não encontrado: " + id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}