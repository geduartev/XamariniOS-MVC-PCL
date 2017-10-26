using Foundation;
using System;
using UIKit;
using AppiOS.Helpers;

namespace AppiOS
{
    public partial class ValidateController : UIViewController
    {
        public ValidateController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ValidateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                /* Creamos la instancia del código compartido y le inyectamos la dependencia. */
                // var Validador = PCL.Validar( acá inyectamos la dependencia );
                // La dependencia es un objeto que hemos creado. new IOSDialog( contexto (this) );
                var Validator = new PCL.SAL.AppValidator(new IOSDialog(this))
                {
                    /* Aquí podríamos esteablecer los valroes de las propiedades: Email, Password y Device.*/
                    Email = EmailText.Text,
                    Password = PasswordText.Text,
                    Model = new PCL.SAL.NorthWindModel()
                };

                //Realizamos la validación.
                Validator.Validate();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}