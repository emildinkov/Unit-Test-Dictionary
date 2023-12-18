using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new()
        {
            ["Bob"] = 5,
            ["Alice"] = 2,
            ["Nicole"] = 6,
            ["Asparuh"] = 3,
            ["Debora"] = 7
        };

        string expected = $"Debora with average grade 7.00" +
            $"{Environment.NewLine}Nicole with average grade 6.00" +
            $"{Environment.NewLine}Bob with average grade 5.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> grades = new();

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new()
        {
            ["Bob"] = 5,
            ["Alice"] = 4
        };

        string expected = $"Bob with average grade 5.00" +
            $"{Environment.NewLine}Alice with average grade 4.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> grades = new()
        {
            ["Bob"] = 5,
            ["Alice"] = 5,
            ["Cole"] = 5,
            ["Yana"] = 5,
            ["Debora"] = 5
        };

        string expected = $"Alice with average grade 5.00" +
            $"{Environment.NewLine}Bob with average grade 5.00" +
            $"{Environment.NewLine}Cole with average grade 5.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
