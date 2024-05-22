using System.ComponentModel.DataAnnotations;
using System.Linq; // Make sure to include this using directive for LINQ methods

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class MinWordsAttribute : ValidationAttribute
    {
        public int MinimumWords { get; set; }

        // Constructor name corrected to match the class name
        public MinWordsAttribute(int minimumWords)
        {
            this.MinimumWords = minimumWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            var parole = fieldValue?.Split(' '); // Split the words, use ? to avoid nullException

            if (parole?.Where(s => s.Length > 0).Count() < MinimumWords) // ? again to avoid nullException if parole is null
            {
                return new ValidationResult($"Il campo deve contenere almeno {MinimumWords} parole");
            }
            return ValidationResult.Success;
        }
    }
}