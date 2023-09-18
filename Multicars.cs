using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicars.Data;
using Multicars.Models.BD;

namespace Multicars.Controllers
{
    public class Multicars : Controller
    {
        public ApplicationDbContext db;
        public Multicars(ApplicationDbContext Db)
        {
            db = Db;
        }

        //**************************************************************************************************
        //GRUPOS
        [HttpPost]
        public async Task<IActionResult> Cadastrar_grupos(Grupos model)
        {
            if (ModelState.IsValid)
            {
                db.grupos.Add(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Grupo cadastrado com sucesso!'); window.location.href='';</script>");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar_grupos()
        {
            return View();
        }
        //**************************************************************************************************
        //CARROS
        [HttpPost]
        public async Task<IActionResult> Cadastrar_Carros(Carros model)
        {
            if (ModelState.IsValid)
            {
                model.disponibilidade = true;
                db.carros.Add(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Carro cadastrado com sucesso!'); window.location.href='';</script>");

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar_Carros()
        {
            ViewBag.Grupo = new SelectList(db.grupos, "id", "nome");
            return View();
        }
        //**************************************************************************************************
        //ALUGUEIS
        [HttpGet]
        public IActionResult Cadastrar_aluguel()
        {
            ViewBag.Carro = new SelectList(db.carros.Where(carro=>carro.disponibilidade == true), "id", "modelo");
            ViewBag.Cliente = new SelectList(db.cliente, "CNH", "nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar_aluguel(Alugueis model)
        {
            if (ModelState.IsValid)
            {
                var carro = db.carros.Single(f => f.id == model.id_carro);
                var grupo = db.grupos.Single(j => j.id == carro.grupo);

                int dias = (int)model.Data_retorno.Subtract(model.Data_alugada).TotalDays;
                model.valor = grupo.valor * dias;
                carro.disponibilidade = false;
                db.alugueis.Add(model);
                db.carros.Update(carro);

                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Alugado com sucesso!'); window.location.href='';</script>");

            }
            return View();
        }

        //**************************************************************************************************
        //CLIENTES
        [HttpGet]
        public IActionResult Cadastrar_clientes()
        {
            return View(db.cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar_clientes(Cliente model)
        {
            if (ModelState.IsValid)
            { 
                db.cliente.Add(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Cadastrado realizado com sucesso!'); window.location.href='';</script>");
            }
            return View(model);
        }
//***********************************************************************

        //GRUPOS
        [HttpGet]
        public IActionResult List()
        {
            return View(db.grupos);
        }

        [HttpGet]
        public IActionResult Editar_grupos(string id)
        {
            var grupos = db.grupos.Single(a => a.id == Convert.ToInt32(id));
            return View(grupos);
        }

        [HttpPost]
        public async Task<IActionResult> Editar_grupos(Grupos model)
        {
            if (ModelState.IsValid)
            {
                db.grupos.Update(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Grupo editado com sucesso!'); window.location.href='../List';</script>");
            }
            return View(model);
        }
        //***********************************************************************

        //CARROS
        [HttpGet]
        public IActionResult Lista_carros()
        {
            return View(db.carros);
        }

        [HttpGet]
         public IActionResult Editar_carros(string id)
         {
            var carros = db.carros.Single(a => a.id == Convert.ToInt32(id));
            return View(carros);
         }

        [HttpPost]
        public async Task<IActionResult> Editar_carros(Carros model)
        {
            if (ModelState.IsValid)
            {
                db.carros.Update(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Carro editado com sucesso!'); window.location.href='../Lista_carros';</script>");
            }
            return View(model);

        }
        //***********************************************************************

        //CLIENTE
        [HttpGet]
        public IActionResult Lista_clientes()
        {
            return View(db.cliente);
        }

        [HttpGet]
        public IActionResult Editar_cliente(string id)
        {
            var cliente = db.cliente.Single(c => c.CNH == id);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Editar_cliente(Cliente model)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Update(model);
                await db.SaveChangesAsync();
                await Response.WriteAsync("<script language='javascript'> alert('Cliente editado com sucesso!'); window.location.href='../List';</script>");
            }
            return View(model);
        }




        //***********************************************************************
        //ALUGUEL
        public IActionResult Lista_alugueis()
        {
            return View(db.alugueis);
        }

    }
}
