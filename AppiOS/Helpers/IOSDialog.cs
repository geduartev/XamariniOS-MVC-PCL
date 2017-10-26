using System;
using System.Collections.Generic;
using System.Text;
using PCL.Interfaces;
using UIKit;

namespace AppiOS.Helpers
{
    public class IOSDialog : IDialog
    {
        private UIViewController Controller;

        public IOSDialog(UIViewController controller)
        {
            this.Controller = controller;
        }

        public void Show(string message)
        {
            var Alert = UIAlertController.Create("Resultado de la verificación ", message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            this.Controller.PresentViewController(Alert, true, null);
        }
    }
}
