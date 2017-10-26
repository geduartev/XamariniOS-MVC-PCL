//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>10/26/2017 11:29:10 AM</date>
//-----------------------------------------------------------------------
namespace PCL.SAL
{
	using System;
	using System.Collections.Generic;
	using System.Text;
    using NorthWind;

    /// <summary>
    /// Class.
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Identificador del producto.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Identificador del proveedor.
        /// </summary>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Identificador de la categoría.
        /// </summary>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Cantidad del producto.
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Unidades de producto en inventario o existencia.
        /// </summary>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// Unidades de producto solicitadas.
        /// </summary>

        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Nivel de orden del producto.
        /// </summary>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Producto descontinuado.
        /// </summary>
        public bool Discontinued { get; set; }
    }
}