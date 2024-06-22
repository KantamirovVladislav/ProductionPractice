using System.Globalization;
using System.Windows.Controls;

namespace AdmissionCommitteeWPF.ValidationRules;

public class MinLenghtValidationRule: ValidationRule
{
    public int MinLength { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var str = value as string;
        if (str != null && str.Length < MinLength)
        {
            return new ValidationResult(false, $"Поле не может быть меньше {MinLength} символов.");
        }
        return ValidationResult.ValidResult;
    }
}