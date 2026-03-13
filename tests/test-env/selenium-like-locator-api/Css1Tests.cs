using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikeLocatorApi;

[TestFixture]
[Category("slow")]
public class Css1Tests : BaseHealeniumTest
{
    private const int CssTimeout = 9000;
    private const int CssWaitTimeout = 450;
    private const string CallbackUrl = "https://mdn.github.io/web-components-examples/life-cycle-callbacks/";

    [Test]
    public async Task Update_locator_for_element_with_css_attribute()
    {
        await Page.GotoAsync(CallbackUrl, new() { WaitUntil = WaitUntilState.DOMContentLoaded });

        var addSquareBtn = Page.Locator("//button[contains(@class, \"add\")]");
        await Expect(addSquareBtn).ToBeVisibleAsync();
        await addSquareBtn.ClickAsync(new() { Timeout = CssTimeout });

        var squareElement = Page.Locator("custom-square[color=\"red\"]");
        await Expect(squareElement).ToBeVisibleAsync();

        for (var i = 0; i <= 1; i++)
        {
            var updateSquareBtn = Page.Locator("//button[contains(@class, \"update\")]");
            await Expect(updateSquareBtn).ToBeVisibleAsync();
            await updateSquareBtn.ClickAsync(new() { Timeout = CssTimeout });
            await Page.WaitForTimeoutAsync(CssWaitTimeout);

            var healedSquareElement = Page.Locator("custom-square[color=\"red\"]");
            await Expect(healedSquareElement).ToBeVisibleAsync();
        }
    }
}
