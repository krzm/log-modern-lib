using Xunit;

namespace Log.Modern.Lib.Tests;

public class TaskFilterTests
{
    [Theory]
    [InlineData(null, null)]
    public void TestNullFilter(
        int? filterId
        , string? filterName)
    {
        var filter = new TaskFilter().GetFilter(
            new TaskArgFilter{ 
                CategoryId = filterId
                , Name = filterName });

        Assert.Null(filter);
    }

    [Theory]
    [InlineData(2, 1, false)]
    [InlineData(1, 1, true)]
    public void TestIdFilter(
        int id
        , int? filterId
        , bool expected)
    {
        var data = new Data.Task{ 
            CategoryId = id };
        var filter = new TaskFilter().GetFilter(
            new TaskArgFilter{ 
                CategoryId = filterId }).Compile();

        Assert.Equal(expected, filter(data));
    }

    [Theory]
    [InlineData("you shall not pass", "you my go", false)]
    [InlineData("you my go", "you my go", true)]
    public void TestNameFilter(
        string name
        , string filterName
        , bool expected)
    {
        var data = new Data.Task{ 
            Name = name };
        var filter = new TaskFilter().GetFilter(
            new TaskArgFilter{ 
                Name = filterName }).Compile();

        Assert.Equal(expected, filter(data));
    }

    [Theory]
    [InlineData(1, 1, "you my go", "you my go", true)]
    [InlineData(2, 1, "you shall not pass", "you my go", false)]
    [InlineData(1, 1, "you shall not pass", "you my go", false)]
    [InlineData(2, 1, "you my go", "you my go", false)]
    public void TestIdAndNameFilter(
        int id
        , int? filterId
        , string name
        , string filterName
        , bool expected)
    {
        var data = new Data.Task { 
            CategoryId = id
            , Name = name };
        var filter = new TaskFilter().GetFilter(
            new TaskArgFilter{ 
                CategoryId = filterId
                , Name = filterName }).Compile();

        Assert.Equal(expected, filter(data));
    }
}