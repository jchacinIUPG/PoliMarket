using PoliMarket.Models;
using PoliMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services
{
    public class EntregasService : IEntregas
    {
        private readonly List<EntregaModel> _entregas;
        private readonly List<DisponibilidadModel> _disponibilidades;


        public EntregasService()
        {
            // Datos simulados de entregas
            _entregas = new List<EntregaModel>
        {
            new EntregaModel
            {
                Id = 1,
                IdVenta = 1001,
                Entregado = "Pendiente",
                Productos = new List<ProductoModel>
                {
                    new ProductoModel { Id = 1, Nombre = "A123", Descripcion = "Producto A" },
                    new ProductoModel { Id = 2, Nombre = "B456", Descripcion = "Producto B" }
                }
            },
            new EntregaModel
            {
                Id = 2,
                IdVenta = 1002,
                Entregado = "Sí",
                Productos = new List<ProductoModel>
                {
                    new ProductoModel { Id = 3, Nombre = "C789", Descripcion = "Producto C" }
                }
            }
        };

            // Datos simulados de disponibilidad en bodegas
            _disponibilidades = new List<DisponibilidadModel>
        {
            new DisponibilidadModel
            {
                IdBodega = 1,
                IdProducto = 1,
                Cantidad = 10,
                Unidad = "Unidades",
                Producto = new ProductoModel { Id = 1, Nombre = "A123", Descripcion = "Producto A" },
                Bodega = new BodegaModel { Id = 1, Nombre = "Bodega Central" }
            },
            new DisponibilidadModel
            {
                IdBodega = 2,
                IdProducto = 2,
                Cantidad = 5,
                Unidad = "Unidades",
                Producto = new ProductoModel { Id = 2, Nombre = "B456", Descripcion = "Producto B" },
                Bodega = new BodegaModel { Id = 2, Nombre = "Bodega Norte" }
            },
            new DisponibilidadModel
            {
                IdBodega = 1,
                IdProducto = 3,
                Cantidad = 0,
                Unidad = "Unidades",
                Producto = new ProductoModel { Id = 3, Nombre = "C789", Descripcion = "Producto C" },
                Bodega = new BodegaModel { Id = 1, Nombre = "Bodega Central" }
            }
        };
        }


        // 4. Consultar entregas pendientes
        public List<EntregaModel> ObtenerEntregas(string estado)
        {
            return _entregas
                .Where(e => string.Equals(e.Entregado, estado, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // 5. Confirmar salida de stock por entrega
        public bool RegistrarSalida(EntregaModel entrega)
        {
            // Buscar entrega
            var entregaExistente = _entregas.FirstOrDefault(e => e.Id == entrega.Id);

            if (entregaExistente == null || entregaExistente.Entregado == "Sí")
                return false;

            foreach (var producto in entregaExistente.Productos ?? Enumerable.Empty<ProductoModel>())
            {
                // Buscar disponibilidad con stock > 0
                var disponibilidad = _disponibilidades
                    .FirstOrDefault(d => d.IdProducto == producto.Id && d.Cantidad > 0);

                if (disponibilidad == null || disponibilidad.Cantidad < 1)
                {
                    return false;
                }

                disponibilidad.Cantidad -= 1;
            }

            entregaExistente.Entregado = "Sí";
            return true;
        }
    }
}
