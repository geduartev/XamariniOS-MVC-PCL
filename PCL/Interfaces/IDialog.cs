//-----------------------------------------------------------------------
// <copyright file="IDialog.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>10/26/2017 11:25:30 AM</date>
//-----------------------------------------------------------------------
namespace PCL.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	
	/// <summary>
    /// Interface.
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Muestra un mensaje en la pantalla.
        /// </summary>
        /// <param name="message">Mensaje a mostrar en pantalla.</param>
        void Show(string message);
    }
}
