using Microsoft.AspNetCore.Mvc.ModelBinding;
using Villa.Domain.Entities;

namespace Villa.Web.Helpers
{
    public static class VillaValidator
    {
        public static void Validate(string name,string description, ModelStateDictionary modelState)
        {
           if(name==description)
            {
                modelState.AddModelError("Name", "Name and Dictionary can't be same");
            }
        }
    }
}
