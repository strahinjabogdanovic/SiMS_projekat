using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Sekretar.ViewModel;

namespace ProjekatSIMS
{
    public abstract class ValidationBase : ViewModels
    {
        public ValidationErrors ValidationErrors { get; set; }
        public bool IsValid { get; private set; }

        protected ValidationBase()
        {
            this.ValidationErrors = new ValidationErrors();
        }

        protected abstract void ValidateSelf();

        public void Validate()
        {
            Console.WriteLine("Validate");
            this.ValidationErrors.Clear();
            this.ValidateSelf();
            this.IsValid = this.ValidationErrors.IsValid;
            Console.WriteLine(this.ValidationErrors.IsValid);
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }
    }
}
