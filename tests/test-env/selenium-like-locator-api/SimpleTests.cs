using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit.Framework;
namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class SimpleTests : BaseHealeniumTest
{
    [Test]
    public async Task Update_locator_for_element_with_css_id()
    {
        var idElement = Page.Locator("#change_id");
        await Expect(idElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var changeIdElement = Page.Locator("#change_id");
        await Expect(changeIdElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Update_locator_for_element_with_css_enabled()
    {
        var enabledElement = Page.Locator("textarea:enabled");
        await Expect(enabledElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var changedEnabledElement = Page.Locator("textarea:enabled");
        await Expect(changedEnabledElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task XPath_not_contains()
    {
        var notContainsElement = Page.Locator("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        await Expect(notContainsElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var changedNotContainsElement = Page.Locator("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        await Expect(changedNotContainsElement).ToBeVisibleAsync();
    }
}
