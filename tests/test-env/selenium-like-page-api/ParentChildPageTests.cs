using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class ParentChildPageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;

    [Test]
    public async Task Select_and_verify_several_inputs_CSS_FirstChild()
    {
        var firstChildElement = await Page.QuerySelectorAsync("test_tag:first-child");
        Assert.That(firstChildElement, Is.Not.Null);
        Assert.That(await firstChildElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedFirstChildElement = await Page.QuerySelectorAsync("test_tag:first-child");
        Assert.That(healedFirstChildElement, Is.Not.Null);
        Assert.That(await healedFirstChildElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Select_and_verify_several_inputs_CSS_LastChild()
    {
        var lastChildElement = await Page.QuerySelectorAsync("child_tag:last-child");
        Assert.That(lastChildElement, Is.Not.Null);
        Assert.That(await lastChildElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedLastChildElement = await Page.QuerySelectorAsync("child_tag:last-child");
        Assert.That(healedLastChildElement, Is.Not.Null);
        Assert.That(await healedLastChildElement!.IsVisibleAsync(), Is.True);
    }
}
