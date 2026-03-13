using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class XpathTests : BaseHealeniumTest
{
    [Test]
    public async Task XPath_with_special_characters()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();

        var specialCharElement = Page.Locator("xpath=//*[@id=\"change:name\"]");
        await Expect(specialCharElement).ToBeVisibleAsync();
        await specialCharElement.PressAsync("Enter");

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedSpecialCharElement = Page.Locator("xpath=//*[@id=\"change:name\"]");
        await Expect(healedSpecialCharElement).ToBeVisibleAsync();
        await healedSpecialCharElement.PressAsync("Enter", new() { Timeout = Timeout });
    }

    [Test]
    public async Task XPath_following()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();

        var followingElement = Page.Locator("xpath=//*[@id=\"change_className\"]/following::test_tag");
        await Expect(followingElement).ToBeVisibleAsync();
        await followingElement.PressAsync("Enter");

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedFollowingElement = Page.Locator("xpath=//*[@id=\"change_className\"]/following::test_tag");
        await Expect(healedFollowingElement).ToBeVisibleAsync();
        await healedFollowingElement.PressAsync("Enter", new() { Timeout = Timeout });
    }

    [Test]
    public async Task XPath_contains()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();

        var containsElement = Page.Locator("xpath=//input[contains(@class, \"test\")]");
        await Expect(containsElement).ToBeVisibleAsync();
        await containsElement.PressAsync("Enter");

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedContainsElement = Page.Locator("xpath=//input[contains(@class, \"test\")]");
        await Expect(healedContainsElement).ToBeVisibleAsync();
        await healedContainsElement.PressAsync("Enter", new() { Timeout = Timeout });
    }
}
