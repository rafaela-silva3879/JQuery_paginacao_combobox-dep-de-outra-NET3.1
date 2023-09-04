using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JQuery.Presentation.Models;
using JQuery.Application.Interfaces;
using System.Text;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Services;


namespace JQuery.Presentation.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendApplicationService _friendapplicationservice;



        public FriendController(IFriendApplicationService friendapplicationservice)
        {

            _friendapplicationservice = friendapplicationservice;

        }
    
        public IActionResult Create()
        {
         
                return View();
           
        }
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult AddFriend([FromBody] CreateModel fm)
        {
            var erro = new ErrorModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var f = new Friend();
                    f.FriendName = fm.FriendName;
                    f.Phone = fm.Phone;
                    f.IdState = int.Parse(fm.IdState);

                    _friendapplicationservice.Create(f);

                    ModelState.Clear();
                 
                }
                return Json("Amigo salvo com sucesso.");


            }
            catch (Exception e)
            {
                //ViewBag.MensagemErro = e.Message;
                erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);

            }
            //return View("Create");
        }

        //método para abrir a página /Friend/Search
        public IActionResult Search()
        {
    
            return View();
        }
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult SearchFriends([FromBody] FriendSearchModel model)
        {
            ErrorModel erro;
            var fsm = new List<FriendSearchTableModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    if (String.IsNullOrEmpty(model.DataMin) || String.IsNullOrEmpty(model.DataMax))
                        return Json("Por favor, entre os campos requeridos");


                    var datamin = DateTime.Parse(model.DataMin);
                    var datamax = DateTime.Parse(model.DataMax);


                    var result = _friendapplicationservice.GetByDataCadastro(datamin, datamax);

                    if (result != null && result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            var f = new FriendSearchTableModel();
                            f.FriendName = item.FriendName;
                            f.IdFriend = item.IdFriend.ToString();
                            f.Phone = item.Phone;
                            f.StateAcronym = item.State.StateAcronym;
                            f.DataCadastro = item.DataCadastro.ToString("dd'/'MM'/'yyyy");
                            fsm.Add(f);
                        }
                    }
                }
                catch (Exception e)
                {

                    // ViewBag.MensagemErro1 = e.Message.ToString();
                    erro = new ErrorModel();
                    erro.ErrorStr = e.Message;
                    return Json(erro);
                }
            
            }
            return Json(fsm); //devolver a 'model' para a página

        }



        
        public JsonResult SearchForEdit([FromBody] string id)
        {
            var model = new FriendEditModel();

            try
            {
                var Id = Guid.Parse(id);
                //buscar os dados da tarefa no banco atraves do ID..
                var f = _friendapplicationservice.GetById(Id);

                //passar os dados da tarefa para a classe model
                model.IdFriend = f.IdFriend.ToString();
                model.FriendName = f.FriendName;
                model.Phone = f.Phone;
                model.IdState = f.IdState.ToString();
            }
            catch (Exception e)
            {
                ViewBag.MensagemErro = e.Message;
            }
            return Json(model); //devolver a 'model' para a página

        }
        
        //método para abrir a página /Friend/Edicao?id={}
        public IActionResult Edit()
        {
            return View();
        }
        
 

        public IActionResult EditFriend(FriendEditModel model)
        {
            var erro = new ErrorModel();
            try
            {
                if (ModelState.IsValid)
                {                        
                    var f = new Friend();
                    Guid identificador = Guid.Parse(model.IdFriend);

                    f.IdFriend = identificador;
                    f.FriendName = model.FriendName;
                    f.Phone = model.Phone;
                    f.IdState =Convert.ToInt32(model.IdState);

                    _friendapplicationservice.Update(f);

                    ViewBag.MensagemSucesso = $"Amigo {model.FriendName}, atualizado com sucesso.";
         
                }
            }
            catch (Exception e)
            {
                //ViewBag.MensagemErro = e.Message;
                erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);

            }
            return View("Edit");
        }



        //método para excluir um amigo URL: /Friend/Exclusao?id={}
        public IActionResult Delete(string id)
        {
            var erro = new ErrorModel();
            try
            {
                Guid identificador = Guid.Parse(id);

                //buscar a tarefa no banco de dados atraves do ID..
                var f = _friendapplicationservice.GetById(identificador);


                //excluir a tarefa
                _friendapplicationservice.Delete(f);

                //mensagem na página
                ViewBag.MensagemSucesso = $"Amigo {f.FriendName}, excluído com sucesso.";
            }
            catch (Exception e)
            {
                //ViewBag.MensagemErro = e.Message;
                erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);
            }

            //redirecionar para a página de consulta
            return View("Search");
        }

        //método para abrir a página /Friend/Detalhes
        public IActionResult Detalhes()
        {
            return View();
        }

        public JsonResult GetNames(int idState) 
        {
            try
            {
                var nomes = _friendapplicationservice.GetByStateId(idState);
                var lista = new List<NamesModel>();
                foreach (var item in nomes)
                {
                    var n = new NamesModel();
                    n.IdFriend = item.IdFriend;
                    n.FriendName = item.FriendName;
                    lista.Add(n);
                }
                return Json(lista);
            }
            catch (Exception e)
            {
                var erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);
            }
        }

        public JsonResult GetFriend(Guid idFriend)
        {
            try
            {
                var friend = _friendapplicationservice.GetById(idFriend);
                var f = new FriendModel();
                if (friend != null)
                { 
                    f.FriendName = friend.FriendName;
                    f.DataCadastro = friend.DataCadastro.ToString("dd-MM-yyyy");
                    f.Phone= friend.Phone;
                    f.StateAcronym = friend.State.StateAcronym;   
                }
                return Json(f);
            }
            catch (Exception e)
            {
                var erro = new ErrorModel();
                erro.ErrorStr = e.Message;
                return Json(erro);
            }
        }
    }

}