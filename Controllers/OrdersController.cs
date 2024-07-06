using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ing.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ing.Data;
using Ing.Data.Cart;
using Ing.Data.ViewModels;
using Ing.Models;

namespace Ing.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(AppDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Orders.Include(o => o.User);
            return View(await appDbContext.ToListAsync());
        }

       
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        
        
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            // Fetch the specific movie by its ID
            var item = await _context.Movies.FindAsync(id);

            // Check if the item exists
            if (item == null)
            {
                return NotFound();
            }

            // Add the item to the shopping cart
            _shoppingCart.AddItemToCart(item);

            // Redirect to the shopping cart view
            return RedirectToAction(nameof(ShoppingCart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            // Retrieve the item using the context
            var item = await _context.Movies.FindAsync(id);

            // Check if the item exists
            if (item == null)
            {
                return NotFound();
            }

            // Remove the item from the cart
            _shoppingCart.RemoveItemFromCart(item);

            // Redirect to the shopping cart view
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            if (items == null || !items.Any())
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            var order = new Order
            {
                UserId = userId,
                Email = userEmailAddress,
                OrderItems = items.Select(item => new Ticket
                {
                    MovieId = item.Movie.MovieId,
                    Amount = item.Amount,
                    Price = item.Movie.Price,
                    DatePurchase = DateOnly.FromDateTime(DateTime.Now), // Assuming DateOnly
                   /* SessaoId = item.SessionId // Assuming this exists in shopping cart item  */
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
        }
    }

