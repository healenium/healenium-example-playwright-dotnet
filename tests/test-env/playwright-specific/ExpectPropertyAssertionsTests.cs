using System.Text.RegularExpressions;
using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class ExpectPropertyAssertionsTests : BaseHealeniumTest
{
    [Test]
    public async Task ToHaveAttribute()
    {
        var loc = Page.Locator("#change_id");
        await Expect(loc).ToHaveAttributeAsync("type", "text", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#change_id");
        await Expect(healed).ToHaveAttributeAsync("type", "text", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveJSProperty()
    {
        var loc = Page.Locator("#change_id");
        await Expect(loc).ToHaveJSPropertyAsync("type", "text", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#change_id");
        await Expect(healed).ToHaveJSPropertyAsync("type", "text", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveClass()
    {
        var loc = Page.Locator("#change_id");
        await Expect(loc).ToHaveClassAsync(new Regex("input1"), new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#change_id");
        await Expect(healed).ToHaveClassAsync(new Regex("input1"), new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToContainClass()
    {
        var loc = Page.Locator("#change_id");
        await Expect(loc).ToContainClassAsync("input1", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#change_id");
        await Expect(healed).ToContainClassAsync("input1", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveCSS()
    {
        var loc = Page.Locator("#change_id");
        await Expect(loc).ToHaveCSSAsync("display", new Regex("block|inline-block|inline"), new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#change_id");
        await Expect(healed).ToHaveCSSAsync("display", new Regex("block|inline-block|inline"), new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveId()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToHaveIdAsync("change_className", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToHaveIdAsync("change_className", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveRole()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToHaveRoleAsync(AriaRole.Textbox, new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToHaveRoleAsync(AriaRole.Textbox, new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToContainText()
    {
        var loc = Page.Locator("#select_item");
        await Expect(loc).ToContainTextAsync("Select an item", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#select_item");
        await Expect(healed).ToContainTextAsync("Select an item", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveText()
    {
        var loc = Page.Locator("#drop1");
        await Expect(loc).ToHaveTextAsync("Drop Zone", new() { Timeout = Timeout });

        await Page.Locator("#Submit_checkbox").ClickAsync();

        var healed = Page.Locator("#drop1");
        await Expect(healed).ToHaveTextAsync("Drop Zone", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveText_multiline()
    {
        var loc = Page.Locator("#select_item");
        await Expect(loc).ToHaveTextAsync(new Regex("Select an item\\s+Item 1\\s+Item 2\\s+Item 3\\s+Item 4"), new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#select_item");
        await Expect(healed).ToHaveTextAsync(new Regex("Select an item\\s+Item 1\\s+Item 2\\s+Item 3\\s+Item 4"), new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveValue()
    {
        var loc = Page.Locator(".test_class");
        await loc.FillAsync("hello", new() { Timeout = Timeout });
        await Expect(loc).ToHaveValueAsync("hello", new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToHaveValueAsync("hello", new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveValues()
    {
        var loc = Page.Locator("#select_item");
        await loc.SelectOptionAsync(new[] { "1", "2" }, new() { Timeout = Timeout });
        await Expect(loc).ToHaveValuesAsync(new[] { "1", "2" }, new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator("#select_item");
        await Expect(healed).ToHaveValuesAsync(new[] { "1", "2" }, new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToHaveCount()
    {
        var loc = Page.GetByText("Green Item");
        await Expect(loc).ToHaveCountAsync(1);

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.GetByText("Green Item");
        await Expect(healed).ToHaveCountAsync(1);
    }
}
