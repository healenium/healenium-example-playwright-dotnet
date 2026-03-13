using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class SimplePageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;

    [Test]
    public async Task Update_locator_for_element_with_css_id()
    {
        var idElement = await Page.QuerySelectorAsync("#change_id");
        Assert.That(idElement, Is.Not.Null);
        Assert.That(await idElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var changeIdElement = await Page.QuerySelectorAsync("#change_id");
        Assert.That(changeIdElement, Is.Not.Null);
        Assert.That(await changeIdElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Update_locator_for_element_with_css_enabled()
    {
        var enabledElement = await Page.QuerySelectorAsync("textarea:enabled");
        Assert.That(enabledElement, Is.Not.Null);
        Assert.That(await enabledElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var changedEnabledElement = await Page.QuerySelectorAsync("textarea:enabled");
        Assert.That(changedEnabledElement, Is.Not.Null);
        Assert.That(await changedEnabledElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task XPath_not_contains()
    {
        var notContainsElement = await Page.QuerySelectorAsync("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        Assert.That(notContainsElement, Is.Not.Null);
        Assert.That(await notContainsElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var changedNotContainsElement = await Page.QuerySelectorAsync("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        Assert.That(changedNotContainsElement, Is.Not.Null);
        Assert.That(await changedNotContainsElement!.IsVisibleAsync(), Is.True);
    }
}
