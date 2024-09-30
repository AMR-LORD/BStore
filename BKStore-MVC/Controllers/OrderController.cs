﻿using BKStore_MVC.Models;
using BKStore_MVC.Repository;
using BKStore_MVC.Repository.Interfaces;
using BKStore_MVC.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BKStore_MVC.Controllers
{
    public class OrderController : Controller
    {
        IOrderBookRepository orderBookRepository;
        IDeliveryClientRepository deliveryClientRepository;
        IOrderRepository orderRepository;
        ICustomerRepository customerRepository;
        IBookRepository bookRepository;
        IGovernorateRepository governorateRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public OrderController(SignInManager<ApplicationUser> signInManager
            , IOrderRepository orderRepository,
            ICustomerRepository customerRepository, IBookRepository bookRepository,
            IOrderBookRepository orderBookRepository, IDeliveryClientRepository deliveryClientRepository
            , IGovernorateRepository governorateRepository)
        {
            this.orderBookRepository = orderBookRepository;
            this.deliveryClientRepository = deliveryClientRepository;
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
            this.bookRepository = bookRepository;
            this.governorateRepository = governorateRepository;
            _signInManager = signInManager;
        }
        //[Authorize(Roles = "Delivery")]
        public IActionResult GetAll()
        {
            return View("GetAll", orderRepository.GetAll());
        }
        public IActionResult DetailedOrder(int OrderId)
        {
            OrderDetailVM orderDetailVM = new OrderDetailVM();
            orderDetailVM.BookName = bookRepository.GetByID(orderBookRepository.GetByID(OrderId).BookID).Title ?? "nothing";
            orderDetailVM.CustomerName = customerRepository.GetByID(orderRepository.GetByID(OrderId).CustomerID ?? 0).Name;
            orderDetailVM.Quantity = orderBookRepository.GetByID(OrderId).Quantity;
            orderDetailVM.TotalPrice = orderRepository.GetByID(OrderId).TotalAmount ?? 0;
            orderDetailVM.CustomerAddress = customerRepository.GetByID(orderRepository.GetByID(OrderId).CustomerID ?? 0).Address;
            orderDetailVM.Governorate = governorateRepository.GetByID(customerRepository.GetByID(orderRepository.GetByID(OrderId).CustomerID ?? 0).GovernorateID ?? 0).Name;
            return View("DetailedOrder", orderDetailVM);
        }
        public async Task<IActionResult> DeliverOrder(string CustomerName)
        {

            Order order = orderRepository.GetByCustomerID(customerRepository.GetByName(CustomerName).ID);
            order.DelivaryStatus = "Delivering";
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"];
            if (cookie != null)
            {
                var ticket = await _signInManager.Context.AuthenticateAsync(IdentityConstants.ApplicationScheme);
                if (ticket != null)
                {
                    var userId = ticket.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                    order.DeliveryClientsID = deliveryClientRepository.GetByUserID(userId).ID;
                    orderRepository.Update(order);
                    orderRepository.Save();
                    return View("GetAll", orderRepository.GetAll());
                }
            }
            //order.DeliveryClientsID = deliveryClientRepository.GetByUserID(userIdCookie).ID;
            //orderRepository.Update(order);
            //orderRepository.Save();
            //return View("GetAll", orderRepository.GetAll());
            return Content("Error");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int orderID)
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"];
            if (cookie != null)
            {
                var ticket = await _signInManager.Context.AuthenticateAsync(IdentityConstants.ApplicationScheme);
                if (ticket != null)
                {
                    var userId = ticket.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                    Order UpdateOrder = orderRepository.GetBydeliveryID(deliveryClientRepository.GetByUserID(userId).ID, orderID);
                    if (UpdateOrder != null)
                    {
                        UpdateOrder.DelivaryStatus = "Delivered";
                        orderRepository.Update(UpdateOrder);
                        orderRepository.Save();
                        return Json(new { success = true });
                    }

                }
            }
            return Json(new { success = false });
        }

    }
}
