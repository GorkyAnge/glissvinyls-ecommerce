﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductoAppMVC.Models;
using ProductoAppMVC.Service;
using ProductoAppMVC.Interfaces;

namespace ProductoAppMVC.Controllers
{
    public class ComprasController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAPIService _apiProductoEnCarrito;
        private readonly IAPIService _apiUsuario;

        public ComprasController(IAPIService apiProductoEnCarrito, IHttpContextAccessor httpContextAccessor, IAPIService apiUsuario)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiProductoEnCarrito = apiProductoEnCarrito;
            _apiUsuario = apiUsuario;
        }
        public async Task<IActionResult> Index()
        {
            //List<Resena> resenas = await _apiResena.GetListResenas();
            //return View(resenas);
            List<Usuario> productos = await _apiUsuario.GetUsuarios();
            return View(productos);
        }

        public async Task<IActionResult> ComprasPorUsuario(int IdUsuario)
        {

            //List<Resena> resenas = await _apiResena.GetListResenas();
            //return View(resenas);
            List<ProductoEnCarrito> compras = await _apiProductoEnCarrito.ObtenerProductosEnCarrito(IdUsuario);
            return View(compras);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Boolean compra2 = await _apiProductoEnCarrito.EliminarProductoEnCarrito(id);
            if (compra2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
