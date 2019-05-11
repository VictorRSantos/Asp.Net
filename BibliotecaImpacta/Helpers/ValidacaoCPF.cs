using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Helpers
{
    public class ValidacaoCPF : ValidationAttribute, IClientValidatable
    {

        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;

            }
            bool valido = Valida.CPF(value.ToString());
            return valido;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule{
                ErrorMessage = FormatErrorMessage(null),
                ValidationType = "Validacao CPF"
            };
        }
    }
}