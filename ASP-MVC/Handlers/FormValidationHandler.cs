using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASP_MVC.Handlers
{
	public static class FormValidationHandler
	{
		public static void MinAge(this ModelStateDictionary modelState, DateOnly value, string name)
		{
			//if(value is null) throw new ArgumentNullException(nameof(value));

			DateTime birthDate = value.ToDateTime(TimeOnly.MinValue);//Conversion DateOnly en DateTime car comparaison avec DateTime

			int age = DateTime.Today.Year - birthDate.Year;
			if (birthDate > DateTime.Today.AddYears(-age)) age--; // Modifie si anniversaire pas encore passé
			if(age < 18)
			{
				modelState.AddModelError(name, $"L'étudiant doit être âgé d'au moins 18 ans.");
			}
		}
	}
}
