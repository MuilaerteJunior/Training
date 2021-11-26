global using System;
global using System.Collections.Generic;
global using System.Linq;
using Xunit;

namespace CasesVerification;

public class Case2Tests
{
    /*
    private int _number;
    private double _precisionNumber1Above;
    private double _precisionNumber2Below;

    public Case2Tests()
    {
        _number = 20;
        _precisionNumber1Above = 20.000000000012456;
        _precisionNumber2Below = 19.0000000001345;
    }
    */

    [Theory]
    [InlineData(20 , 20.000000000012456, 19.0000000001345)]
    public void ValidatingFloorAndCeiling(double number, double precisionNumber1Above, double precisionNumber2Below) 
    {
        var floorNumber= Math.Floor(precisionNumber1Above);//20
        var ceilingNumber = Math.Ceiling(precisionNumber2Below);//20

        Assert.Equal(number, floorNumber);//20 == 20
        Assert.Equal(number, ceilingNumber);//20 == 20
    }

    [Theory]
    [InlineData(20, 20.000000000012456)]
    public void ValidatingRound(double number, double precisionNumber1Above)
    {
        var roundedNumber = Math.Round(precisionNumber1Above, 2);//20.00
        Assert.Equal(number, roundedNumber);
    }


    [Theory]
    [InlineData(20.01, 20.000000000012456)]
    [InlineData(19.01, 19.0000000001345)]
    public void ValidateRoundToPositiveInfinity(double number, double precisionNumber1Above)
    {
        var roundTwoDecimalsUp = Math.Round(precisionNumber1Above, 2, MidpointRounding.ToPositiveInfinity);
        Assert.Equal(number, roundTwoDecimalsUp);
    }

    [Theory]
    [InlineData(20.00, 20.000000000012456)]
    [InlineData(19.00, 19.0000000001345)]
    public void ValidateToToNegativeInfinity(double number, double precisionNumber1Above)
    {
        var roundTwoDecimalsUp = Math.Round(precisionNumber1Above, 2, MidpointRounding.ToNegativeInfinity);
        Assert.Equal(number, roundTwoDecimalsUp);
    }


    [Theory(DisplayName = "Validating difference between two doubles, and rounding it")]
    [InlineData(20.00, 20.000000000012456)]
    [InlineData(15.00, 15.000000000000001)]
    [InlineData(0.00, 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001)]
    public void ValidateNumericalPrecisionsWithDiffOperation(double number, double precisionNumber1Above)
    {
        var difference = precisionNumber1Above - number;
        var roundedDifference = Math.Round(difference, 2, MidpointRounding.ToPositiveInfinity);
        Assert.Equal(0.01, roundedDifference);
    }

    [Theory]
    [InlineData(20.00, 20.000000000012456)]
    [InlineData(15.00, 15.000000000000001)]
    [InlineData(0.00, 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001)]
    [InlineData(0.00, 0.00000000000000000001234567891234567891234567891234567981324567891)]
    [InlineData(9000000, 9000000 + 0.01)]
    public void ValidateNumericalPrecisions(double number, double precisionNumber1Above)
    {
        var esq = Math.Round(precisionNumber1Above, 2, MidpointRounding.ToPositiveInfinity);
        var dir = Math.Round(number, 2, MidpointRounding.ToPositiveInfinity);
        var resultDifference = Math.Round(esq - dir, 2);
        Assert.Equal(0.01, resultDifference);
    }


    [Theory(DisplayName = "Validating difference between two decimals, and rounding it")]
    [InlineData(20.00, 20.000000000012456)]
    [InlineData(19.00, 19.0000000001345)]
    [InlineData(0.00, 0.00000000000000000001234567891234567891234567891234567981324567891)]
    [InlineData(9000000, 9000000 + 0.01)]
    public void ValidatePrecisionsDiffOperationDecimalPrecisions(decimal number, decimal precisionNumber1Above)
    {
        var difference = precisionNumber1Above - number;
        var roundedDifference = Math.Round(difference, 2, MidpointRounding.ToPositiveInfinity);
        Assert.Equal(0.01m, roundedDifference);
    }



    [Theory(DisplayName = "Validating difference between two decimals, and rounding it")]
    [InlineData(15.00, 15.0000000000000000000000000000001)]
    [InlineData(80.00, 80.0000000000000000000000004565411)]
    [InlineData(0.00, 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001)]
    [InlineData(5000000, 5000000.00000000000000000001234567891234567891234567891234567981324567891)]
    [InlineData(8000000, 8000000 + 0.000000000000000000000000000000000000000000001231)]
    public void FailTests_ValidatePrecisionsDiffOperationDecimalPrecisions(decimal number, decimal precisionNumber1Above)
    {
        var difference = precisionNumber1Above - number;
        var roundedDifference = Math.Round(difference, 2, MidpointRounding.ToPositiveInfinity);
        Assert.NotEqual(0.01m, roundedDifference);
    }

    [Theory(DisplayName = "Validating difference between two doubles, and rounding it")]
    [InlineData(15.00, 15.0000000000000000000000000000001)]
    [InlineData(16.00, 16.0000000000000001)]
    [InlineData(80.00, 80.0000000000000000000000004565411)]
    [InlineData(8000000, 8000000 + 0.000000000000000000000000000000000000000000001231)]
    [InlineData(5000000, 5000000.00000000000000000001234567891234567891234567891234567981324567891)]
    public void FailTests_ValidateNumericalPrecisionsWithDiffOperation(double number, double precisionNumber1Above)
    {
        var difference = precisionNumber1Above - number;
        var roundedDifference = Math.Round(difference, 2, MidpointRounding.ToPositiveInfinity);
        Assert.NotEqual(0.01, roundedDifference);
    }
}