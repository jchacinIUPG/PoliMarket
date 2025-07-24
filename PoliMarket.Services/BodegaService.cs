using PoliMarket.Models;
using PoliMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.Services
{
    public class BodegaService : IBodega
    {
        private static BodegaModel? Bodega { get; set; }

        public BodegaService() 
        {
            Bodega = new BodegaModel 
            {
                Id = 1,
                Nombre = "Bodega por defecto",
                Capacidad = "20.000cm3",
                Productos = new List<DisponibilidadModel>()
            };

            Bodega.Productos.Add(new DisponibilidadModel 
            {
                IdBodega = 1, IdProducto = 1, Cantidad = 10, Unidad = "Caja", Producto = new ProductoModel
                {
                    Id = 1,
                    Nombre = "Nintendo Switch",
                    Descripcion = "Consola de videojuegos portátil",
                    Precio = 1200999
                },
            });

            Bodega.Productos.Add(new DisponibilidadModel
            {
                IdBodega = 1,
                IdProducto = 2,
                Cantidad = 5,
                Unidad = "Caja",
                Producto = new ProductoModel
                {
                    Id = 2,
                    Nombre = "Playstation 4",
                    Descripcion = "Consola de videojuegos Sony",
                    Precio = 1500900
                },
            });

            Bodega.Productos.Add(new DisponibilidadModel
            {
                IdBodega = 1,
                IdProducto = 3,
                Cantidad = 15,
                Unidad = "Caja",
                Producto = new ProductoModel
                {
                    Id = 3,
                    Nombre = "Xbox Series X",
                    Descripcion = "Consola de videojuegos Microsoft",
                    Precio = 3700000
                },
            });

            Bodega.Productos.Add(new DisponibilidadModel
            {
                IdBodega = 1,
                IdProducto = 4,
                Cantidad = 0,
                Unidad = "Caja",
                Producto = new ProductoModel
                {
                    Id = 4,
                    Nombre = "Xbox Series S",
                    Descripcion = "Consola de videojuegos Microsoft",
                    Precio = 1500000
                },
            });
        }

        public List<DisponibilidadModel> ProductosDisponibles()
        {
            return Bodega?.Productos?.FindAll(p => p.Cantidad > 0) ?? [];
        }
    }
}
