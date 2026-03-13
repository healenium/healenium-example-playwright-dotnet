using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class ExpectStateAssertionsTests : BaseHealeniumTest
{
    [Test]
    public async Task ToBeAttached()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToBeAttachedAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToBeAttachedAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeVisible()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToBeVisibleAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeHidden()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).Not.ToBeHiddenAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).Not.ToBeHiddenAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeChecked()
    {
        var checkbox = Page.Locator("input.input1#form_checked1");
        await checkbox.CheckAsync(new() { Timeout = Timeout });
        await Expect(checkbox).ToBeCheckedAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit_checkbox").ClickAsync();

        var healed = Page.Locator("input.input1#form_checked1");
        await healed.CheckAsync(new() { Timeout = Timeout });
        await Expect(healed).ToBeCheckedAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).Not.ToBeDisabledAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).Not.ToBeDisabledAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToBeEnabledAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToBeEnabledAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeEditable()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToBeEditableAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToBeEditableAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var loc = Page.Locator(".test_class");
        await Expect(loc).ToBeEmptyAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await Expect(healed).ToBeEmptyAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task ToBeFocused()
    {
        var loc = Page.Locator(".test_class");
        await loc.FocusAsync(new() { Timeout = Timeout });
        await Expect(loc).ToBeFocusedAsync(new() { Timeout = Timeout });

        await Page.Locator("#Submit").ClickAsync();

        var healed = Page.Locator(".test_class");
        await healed.FocusAsync(new() { Timeout = Timeout });
        await Expect(healed).ToBeFocusedAsync(new() { Timeout = Timeout });
    }

}
