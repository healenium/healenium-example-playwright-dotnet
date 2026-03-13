using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class ParentChildTests : BaseHealeniumTest
{
    [Test]
    public async Task Select_and_verify_several_inputs_css_first_child()
    {
        var firstChildElement = Page.Locator("test_tag:first-child");
        await Expect(firstChildElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedFirstChildElement = Page.Locator("test_tag:first-child");
        await Expect(healedFirstChildElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Select_and_verify_several_inputs_css_last_child()
    {
        var lastChildElement = Page.Locator("child_tag:last-child");
        await Expect(lastChildElement).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await Expect(submitBtn).ToBeVisibleAsync();
        await submitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedLastChildElement = Page.Locator("child_tag:last-child");
        await Expect(healedLastChildElement).ToBeVisibleAsync();
    }
}
