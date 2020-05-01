using Xunit;
using System;

using System.Configuration;
using System.Text.RegularExpressions;

namespace WorkHoursTracker.Test
{
  /// <summary>
  /// EmployeeValidation class tests
  /// </summary> 
  public class EmployeeValidationTest
  {
    ///<summary>
    /// Validate function without db connection
    /// <seealso cref="WorkHoursTracker.EmployeeValidation.Validate(string, string)"/>
    ///</summary>
    public static bool Validate(string name, string surname)
    {
      StringValidator stringValidator = new StringValidator(2, 20);
      try
      {
        stringValidator.Validate(name);
        stringValidator.Validate(surname);
        if (Regex.IsMatch(name, @"^[a-zA-Z]+$") && Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
          return true;
        else
          return false;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e);
        return false;
      }
    }


    ///<summary>
    /// Validate new users function without db connection
    /// <seealso cref="WorkHoursTracker.EmployeeValidation.NewValidate(string, string, string)"/>
    ///</summary>
    public static bool NewValidate(string name, string surname, string jobTitle)
    {
      StringValidator stringValidator = new StringValidator(2, 20);
      try
      {
        if (Regex.IsMatch(name, @"^[a-zA-Z]+$") && Regex.IsMatch(surname, @"^[a-zA-Z]+$") && Regex.IsMatch(jobTitle, @"^[a-zA-Z]+$"))
        {
          stringValidator.Validate(name);
          stringValidator.Validate(surname);
          stringValidator.Validate(jobTitle);
          return true;
        }
        else
          return false;
      }
      catch
      {
        return false;
      }
    }


    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    public void ValidationTestShortStrings(string name, string surname)
    {
      Assert.False(Validate(name, surname));
    }

    [Theory]
    [InlineData("agdyafvsgdabkjhsgdjasbdgjagsjkhdgajksgdjkhagsdgsja", "Kowalski")]
    public void ValidationTestLongStrings(string name, string surname)
    {
      Assert.False(Validate(name, surname));
    }

    [Theory]
    [InlineData("anna", "kowalska")]
    [InlineData("Jan", "Bobrowik")]
    [InlineData("Krzysztof", "Krawczyk")]
    public void ValidationTestPassingStrings(string name, string surname)
    {
      Assert.True(Validate(name, surname));
    }

    [Theory]
    [InlineData("#$%#$%", "#$%#$%")]
    public void ValidationTestNotCharsStrings(string name, string surname)
    {
      Assert.False(Validate(name, surname));
    }

    [Theory]
    [InlineData("Jan", "Kowal$%ski")]
    public void ValidationTestSomeNotCharsStrings(string name, string surname)
    {
      Assert.False(Validate(name, surname));
    }

    [Theory]
    [InlineData("", "", "")]
    [InlineData("a", "a", "a")]
    public void NewValidationTestShortStrings(string name, string surname, string jobTitle)
    {
      Assert.False(NewValidate(name, surname, jobTitle));
    }

    [Theory]
    [InlineData("agdyafvsgdabkjhsgdjasbdgjagsjkhdgajksgdjkhagsdgsja", "Kowalski", "asdashjdajsjdajhsgjd")]
    public void NewValidationTestLongStrings(string name, string surname, string jobTitle)
    {
      Assert.False(NewValidate(name, surname, jobTitle));
    }

    [Theory]
    [InlineData("anna", "kowalska", "ITSpecialist")]
    [InlineData("Jan", "Bobrowik", "CEO")]
    [InlineData("Krzysztof", "Krawczyk", "Worker")]
    public void NewValidationTestPassingStrings(string name, string surname, string jobTitle)
    {
      Assert.True(NewValidate(name, surname, jobTitle));
    }

    [Theory]
    [InlineData("#$%#$%", "#$%#$%", "#@$@#$")]
    public void NewValidationTestNotCharsStrings(string name, string surname, string jobTitle)
    {
      Assert.False(NewValidate(name, surname, jobTitle));
    }

    [Theory]
    [InlineData("Jan", "Kowal$%ski", "SD$ds")]
    public void NewValidationTestSomeNotCharsStrings(string name, string surname, string jobTitle)
    {
      Assert.False(NewValidate(name, surname, jobTitle));
    }
  }
}