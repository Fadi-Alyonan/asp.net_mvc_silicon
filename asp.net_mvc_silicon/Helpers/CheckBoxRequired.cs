using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.Helpers;

public class CheckBoxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}