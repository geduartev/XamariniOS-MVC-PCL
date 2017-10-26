//-----------------------------------------------------------------------
// <copyright file="ChangeStatusEventArgs.cs" company="Ingeniería GD®">
//     Copyright (c) Ingeniería GD® 2017. All rights reserved.
// </copyright>
// <author>Gabriel Eduardo Duarte Vega</author>
// <date>10/26/2017 11:27:45 AM</date>
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
    public class ChangeStatusEventArgs : IChangeStatusEventArgs
    {
        private StatusOptions State;

        public ChangeStatusEventArgs(StatusOptions state)
        {
            this.State = state;
        }

        public StatusOptions Status
        {
            get => this.State;
            set => this.State = value;
        }
    }
}