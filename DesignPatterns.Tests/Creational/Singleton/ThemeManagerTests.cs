using Xunit;
using DesignPatterns.Creational.Singleton;
using System.IO;

namespace DesignPatterns.Tests;

public class ThemeManagerTests
{
    [Fact]
    public void ThemeManager_ShouldReturnSameInstance()
    {
        var instnace1 = ThemeManager.Instance;
        var instnace2 = ThemeManager.Instance;
        Assert.Same(instnace1, instnace2);
    }

    [Fact]
    public void ApplyDarkTheme_ShouldSetCorrectProperties()
    {
        var theme = ThemeManager.Instance;
        theme.ApplyDarkTheme();

        Assert.True(theme.IsDarkMode);
        Assert.Equal("DarkGray",theme.PrimaryColor);
        Assert.Equal(16, theme.FontSize);
    }
    [Fact]
    public void ApplyLightTheme_ShouldResetToDefault()
    {
        var theme = ThemeManager.Instance;
        theme.ApplyLightTheme();

        Assert.False(theme.IsDarkMode);
        Assert.Equal("LightBlue", theme.PrimaryColor);
        Assert.Equal(14, theme.FontSize);
    }
    [Fact]
    public void SetCustomTheme_ShouldUpdateProperties()
    {
        var theme = ThemeManager.Instance;
        theme.SetCustomTheme("Green", 18, true);

        Assert.True(theme.IsDarkMode);
        Assert.Equal("Green", theme.PrimaryColor);
        Assert.Equal(18, theme.FontSize);
    }
    [Fact]
    public void ThemeManager_ShouldPersistChangesAcrossCalls()
    {
        var theme1 = ThemeManager.Instance;
        theme1.SetCustomTheme("Purple", 20, false);

        var theme2 = ThemeManager.Instance;

        Assert.Equal("Purple", theme2.PrimaryColor);
        Assert.Equal(20, theme2.FontSize);
        Assert.False(theme2.IsDarkMode);
    }

}