using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class Css1PageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;
    private const string CallbackUrl = "https://mdn.github.io/web-components-examples/life-cycle-callbacks/";

    [SetUp]
    public async Task SetUpCss1PageAsync()
    {
        await Page.GotoAsync(CallbackUrl, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
    }

    [Test]
    public async Task Update_locator_for_element_with_css_attribute()
    {
        var addSquareBtn = await Page.QuerySelectorAsync("xpath=//button[contains(@class, \"add\")]");
        Assert.That(addSquareBtn, Is.Not.Null);
        await addSquareBtn!.ClickAsync(new() { Timeout = PageTimeout });

        var squareElement = await Page.QuerySelectorAsync("custom-square[color=\"red\"]");
        Assert.That(squareElement, Is.Not.Null);
        Assert.That(await squareElement!.IsVisibleAsync(), Is.True);

        for (var i = 0; i <= 1; i++)
        {
            var updateSquareBtn = await Page.QuerySelectorAsync("xpath=//button[contains(@class, \"update\")]");
            Assert.That(updateSquareBtn, Is.Not.Null);
            await updateSquareBtn!.ClickAsync(new() { Timeout = PageTimeout });
            await Page.WaitForTimeoutAsync(PageWaitTimeout);

            var healedSquareElement = await Page.QuerySelectorAsync("custom-square[color=\"red\"]");
            Assert.That(healedSquareElement, Is.Not.Null);
            Assert.That(await healedSquareElement!.IsVisibleAsync(), Is.True);
        }
    }
}
