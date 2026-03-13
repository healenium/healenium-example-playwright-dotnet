using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class GeneralTests : BaseHealeniumTest
{
    private const int GeneralTimeout = 3000;

    [Test]
    public async Task Button_click_with_find_by_annotation()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();

        var submitAlertBtn = Page.Locator("#submit_alert");
        await Expect(submitAlertBtn).ToBeVisibleAsync();
        await submitAlertBtn.ClickAsync(new() { Timeout = GeneralTimeout });

        var changeIdElement = Page.Locator("#change_id");
        await changeIdElement.PressAsync("Enter", new() { Timeout = GeneralTimeout });

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = GeneralTimeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedChangeIdElement = Page.Locator("#change_id");
        await healedChangeIdElement.PressAsync("Enter", new() { Timeout = GeneralTimeout });
    }

    [Test]
    public async Task Input_fields_click_with_find_by_annotation()
    {
        var testClassElement = Page.Locator("input.test_class");
        await Expect(testClassElement).ToBeVisibleAsync();
        await testClassElement.PressAsync("Enter");

        var testTagElement = Page.Locator("test_tag#change_element");
        await Expect(testTagElement).ToBeVisibleAsync();
        var classAttr = await testTagElement.GetAttributeAsync("class");
        Assert.That(classAttr, Is.EqualTo("shadow-input1"));

        var changeNameElement = Page.Locator("input[name=\"change_name\"]");
        await Expect(changeNameElement).ToBeVisibleAsync();

        var linkElement = Page.Locator("a:has-text(\"Change: LinkText, PartialLinkText\")");
        await Expect(linkElement).ToBeVisibleAsync();
        var linkClassAttr = await linkElement.GetAttributeAsync("class");
        Assert.That(linkClassAttr, Is.EqualTo("input1"));

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = GeneralTimeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedTestClassElement = Page.Locator("input.test_class");
        await Expect(healedTestClassElement).ToBeVisibleAsync();
        await healedTestClassElement.PressAsync("Enter", new() { Timeout = GeneralTimeout });

        var healedTestTagElement = Page.Locator("test_tag#change_element");
        await Expect(healedTestTagElement).ToBeVisibleAsync();
        var healedClassAttr = await healedTestTagElement.GetAttributeAsync("class", new() { Timeout = GeneralTimeout });
        Assert.That(healedClassAttr, Is.EqualTo(classAttr));

        var healedChangeNameElement = Page.Locator("input[name=\"change_name\"]");
        await Expect(healedChangeNameElement).ToBeVisibleAsync();
    }
}
