using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class Css2PageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;

    [Test]
    public async Task Update_locator_for_element_with_css_id_with_special_character()
    {
        var changeNameElement = await Page.QuerySelectorAsync("input#change\\:name");
        Assert.That(changeNameElement, Is.Not.Null);
        Assert.That(await changeNameElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedChangeNameElement = await Page.QuerySelectorAsync("input#change\\:name");
        Assert.That(healedChangeNameElement, Is.Not.Null);
        Assert.That(await healedChangeNameElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Update_locator_for_element_with_css_Element()
    {
        var testTagElement = await Page.QuerySelectorAsync("test_tag");
        Assert.That(testTagElement, Is.Not.Null);
        Assert.That(await testTagElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedTestTagElement = await Page.QuerySelectorAsync("test_tag");
        Assert.That(healedTestTagElement, Is.Not.Null);
        Assert.That(await healedTestTagElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Update_locator_for_element_with_css_Disabled()
    {
        var disabledElement = await Page.QuerySelectorAsync("input:disabled");
        Assert.That(disabledElement, Is.Not.Null);
        Assert.That(await disabledElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedDisabledElement = await Page.QuerySelectorAsync("input:disabled");
        Assert.That(healedDisabledElement, Is.Not.Null);
        Assert.That(await healedDisabledElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Update_locator_for_element_with_css_Enabled()
    {
        var enabledElement = await Page.QuerySelectorAsync("textarea:enabled");
        Assert.That(enabledElement, Is.Not.Null);
        Assert.That(await enabledElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedEnabledElement = await Page.QuerySelectorAsync("textarea:enabled");
        Assert.That(healedEnabledElement, Is.Not.Null);
        Assert.That(await healedEnabledElement!.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Update_locator_for_element_with_css_ClassName()
    {
        var testClassElement = await Page.QuerySelectorAsync(".test_class");
        Assert.That(testClassElement, Is.Not.Null);
        Assert.That(await testClassElement!.IsVisibleAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedTestClassElement = await Page.QuerySelectorAsync(".test_class");
        Assert.That(healedTestClassElement, Is.Not.Null);
        Assert.That(await healedTestClassElement!.IsVisibleAsync(), Is.True);
    }
}
