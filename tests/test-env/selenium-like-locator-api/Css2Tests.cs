using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class Css2Tests : BaseHealeniumTest
{
    [Test]
    public async Task Update_locator_for_element_with_css_id_with_special_character()
    {
        var changeNameElement = Page.Locator("input#change\\:name");
        await Expect(changeNameElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedChangeNameElement = Page.Locator("input#change\\:name");
        await Expect(healedChangeNameElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Update_locator_for_element_with_css_element()
    {
        var testTagElement = Page.Locator("test_tag");
        await Expect(testTagElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedTestTagElement = Page.Locator("test_tag");
        await Expect(healedTestTagElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Update_locator_for_element_with_css_disabled()
    {
        var disabledElement = Page.Locator("input:disabled");
        await Expect(disabledElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedDisabledElement = Page.Locator("input:disabled");
        await Expect(healedDisabledElement).ToBeVisibleAsync();
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

        var healedEnabledElement = Page.Locator("textarea:enabled");
        await Expect(healedEnabledElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Update_locator_for_element_with_css_class_name()
    {
        var testClassElement = Page.Locator(".test_class");
        await Expect(testClassElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedTestClassElement = Page.Locator(".test_class");
        await Expect(healedTestClassElement).ToBeVisibleAsync();
    }
}
