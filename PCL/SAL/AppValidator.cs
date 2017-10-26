//-----------------------------------------------------------------------
// <copyright file="AppValidator.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>10/26/2017 11:27:13 AM</date>
//-----------------------------------------------------------------------
namespace PCL.SAL
{
	using System;
	using System.Collections.Generic;
	using System.Text;
    using NorthWind;
    using PCL.Interfaces;

    /// <summary>
    /// Class.
    /// </summary>
    public class AppValidator
    {
        IDialog Dialog;

        public AppValidator(IDialog dialog)
        {
            this.Dialog = dialog;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public INorthWindModel Model { get; set; }

        /// <summary>
        /// Lógica de negocio para validar y mostrar en pantalla mensaje.
        /// </summary>
        public void Validate()
        {
            AppValidate();
        }

        private async void AppValidate()
        {
            var Client = new SALLab07.ServiceClient();

            var result = await Client.ValidateAsync(Email, Password, Model);

            var message = $"{result.Status}\n{result.FullName}\n{result.Token}";

            this.Dialog.Show(message);
        }
    }
}