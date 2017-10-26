//-----------------------------------------------------------------------
// <copyright file="NorthWindModel.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>10/26/2017 11:28:43 AM</date>
//-----------------------------------------------------------------------
namespace PCL.SAL
{
	using System;
	using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using NorthWind;

    /// <summary>
    /// Class.
    /// </summary>
    public class NorthWindModel : INorthWindModel
    {
        /// <summary>
        /// Estado actual de la búsqueda de un producto.
        /// </summary>
        public event ChangeStatusEventHandler ChangeStatus;

        /// <summary>
        /// Realiza la búsqueda de un producto específico.
        /// </summary>
        /// <param name="ID">Identificador del producto.</param>
        /// <returns>Retorna información del producto.</returns>
        public async Task<IProduct> GetProductByIDAsync(int ID)
        {
            Product Product = new Product();

            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(PCL.Properties.Resources.ResourceManager.GetString("UriApiWeb"));
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Notificar aquí que la API Web será invocada
                ChangeStatus?.Invoke(this, new ChangeStatusEventArgs(StatusOptions.CallingWebAPI));

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                // Notificar aquí que se va a verificar el resultado de la llamada.
                ChangeStatus?.Invoke(this, new ChangeStatusEventArgs(StatusOptions.VerifyingResult));

                if (Response.IsSuccessStatusCode)
                {
                    var JSONProduct = await Response.Content.ReadAsStringAsync();
                    Product = JsonConvert.DeserializeObject<Product>(JSONProduct);

                    if (Product != null)
                    {
                        // Notificar aquí que el producto fue encontrado.
                        ChangeStatus?.Invoke(this, new ChangeStatusEventArgs(StatusOptions.ProductFound));
                    }
                    else
                    {
                        // Notificar aquí que el producto NO fue encontrado.
                        ChangeStatus?.Invoke(this, new ChangeStatusEventArgs(StatusOptions.ProductNotFound));
                    }
                }
                return Product;
            }
        }
    }
}