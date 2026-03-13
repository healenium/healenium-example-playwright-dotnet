using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class XpathPageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;

    [SetUp]
    public void SetUpDialog()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();
    }

    [Test]
    public async Task XPath_with_special_characters()
    {
        var specialCharElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change:name\"]");
        Assert.That(specialCharElement, Is.Not.Null);
        await specialCharElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedSpecialCharElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change:name\"]");
        Assert.That(healedSpecialCharElement, Is.Not.Null);
        await healedSpecialCharElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Following()
    {
        var followingElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_className\"]/following::test_tag");
        Assert.That(followingElement, Is.Not.Null);
        await followingElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedFollowingElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_className\"]/following::test_tag");
        Assert.That(healedFollowingElement, Is.Not.Null);
        await healedFollowingElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Contains()
    {
        var containsElement = await Page.QuerySelectorAsync("xpath=//input[contains(@class, \"test\")]");
        Assert.That(containsElement, Is.Not.Null);
        await containsElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedContainsElement = await Page.QuerySelectorAsync("xpath=//input[contains(@class, \"test\")]");
        Assert.That(healedContainsElement, Is.Not.Null);
        await healedContainsElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Not_Contains()
    {
        var notContainsElement = await Page.QuerySelectorAsync("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        Assert.That(notContainsElement, Is.Not.Null);
        await notContainsElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedNotContainsElement = await Page.QuerySelectorAsync("xpath=//input[not(contains(@class, \"input1\")) and contains(@class, \"test_class\")]");
        Assert.That(healedNotContainsElement, Is.Not.Null);
        await healedNotContainsElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Following_Sibling()
    {
        var followingSiblingElement = await Page.QuerySelectorAsync("xpath=//*[starts-with(@class, \"test\")]/following-sibling::*");
        Assert.That(followingSiblingElement, Is.Not.Null);
        await followingSiblingElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedFollowingSiblingElement = await Page.QuerySelectorAsync("xpath=//*[starts-with(@class, \"test\")]/following-sibling::*");
        Assert.That(healedFollowingSiblingElement, Is.Not.Null);
        await healedFollowingSiblingElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Ancestor()
    {
        var ancestorElement = await Page.QuerySelectorAsync("xpath=(//*[starts-with(@class, \"test\")]/ancestor::div[@class=\"healenium-form validate-form\"]//input)[1]");
        Assert.That(ancestorElement, Is.Not.Null);
        await ancestorElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedAncestorElement = await Page.QuerySelectorAsync("xpath=(//*[starts-with(@class, \"test\")]/ancestor::div[@class=\"healenium-form validate-form\"]//input)[1]");
        Assert.That(healedAncestorElement, Is.Not.Null);
        await healedAncestorElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_OR()
    {
        var orElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_id\" or @id=\"omg\"]");
        Assert.That(orElement, Is.Not.Null);
        await orElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedOrElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_id\" or @id=\"omg\"]");
        Assert.That(healedOrElement, Is.Not.Null);
        await healedOrElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_And()
    {
        var andElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_id\" and @type=\"text\"]");
        Assert.That(andElement, Is.Not.Null);
        await andElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedAndElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_id\" and @type=\"text\"]");
        Assert.That(healedAndElement, Is.Not.Null);
        await healedAndElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Starts_with()
    {
        var startsWithElement = await Page.QuerySelectorAsync("xpath=//*[starts-with(@class, \"test\")]");
        Assert.That(startsWithElement, Is.Not.Null);
        await startsWithElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedStartsWithElement = await Page.QuerySelectorAsync("xpath=//*[starts-with(@class, \"test\")]");
        Assert.That(healedStartsWithElement, Is.Not.Null);
        await healedStartsWithElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Preceding()
    {
        var precedingElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_className\"]/preceding::*[@id=\"change_id\"]");
        Assert.That(precedingElement, Is.Not.Null);
        await precedingElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedPrecedingElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"change_className\"]/preceding::*[@id=\"change_id\"]");
        Assert.That(healedPrecedingElement, Is.Not.Null);
        await healedPrecedingElement!.PressAsync("Enter");
    }

    [Test]
    public async Task XPath_Descendant()
    {
        var descendantElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"descendant_change\"]/descendant::input");
        Assert.That(descendantElement, Is.Not.Null);
        await descendantElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedDescendantElement = await Page.QuerySelectorAsync("xpath=//*[@id=\"descendant_change\"]/descendant::input");
        Assert.That(healedDescendantElement, Is.Not.Null);
        await healedDescendantElement!.PressAsync("Enter");
    }
}
