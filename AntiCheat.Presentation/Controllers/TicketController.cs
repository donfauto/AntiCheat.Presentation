﻿using AntiCheat.BusinessLogic.Models;
using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using AntiCheat.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiCheat.Presentation.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketSaleService _ticketSaleService;
        public TicketController(ITicketService ticketService, ITicketSaleService ticketSaleService)
        {
            _ticketService = ticketService;
            _ticketSaleService = ticketSaleService;
        }
        public async Task<IActionResult> Index()
        {

            try
            {
                var tickets = await _ticketService.GetTicketsAsync();

                return View(tickets);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult SaveTicket()
        {
            ViewBag.Sucess = TempData["Sucess"];
            ViewBag.Exist = TempData["Exist"];
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SaveTicket(SaleViewModel saleViewModel)
        {  
            try
            {
                if (await _ticketSaleService.CheckIfTRansactionExistAsync(saleViewModel.TicketSale.NumTransaction))
                {
                    TempData["Exist"] = "No se pudo agregar";
                }
                else
                {
                    var savedTicket = await _ticketSaleService.SaveTicketSaleAsync(saleViewModel);
                    TempData["Sucess"] = "Agregado correctamente!";
                    
                }
                return RedirectToAction("SaveTicket");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
