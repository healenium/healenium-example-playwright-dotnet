using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.SeleniumLikePageApi;

/// <summary>Uses deprecated Page.QuerySelectorAsync (analog of page.$).</summary>
[TestFixture]
[Category("slow")]
public class GeneralPageTests : BaseHealeniumTest
{
    private const int PageTimeout = 9000;
    private const int PageWaitTimeout = 450;

    [Test]
    public async Task Button_click_with_FindBy_annotation()
    {
        Page.Dialog += (_, dialog) => dialog.AcceptAsync();

        var submitAlertBtn = await Page.QuerySelectorAsync("#submit_alert");
        Assert.That(submitAlertBtn, Is.Not.Null);
        await submitAlertBtn!.ClickAsync(new() { Timeout = PageTimeout });

        var changeIdElement = await Page.QuerySelectorAsync("#change_id");
        Assert.That(changeIdElement, Is.Not.Null);
        await changeIdElement!.PressAsync("Enter");

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedChangeIdElement = await Page.QuerySelectorAsync("#change_id");
        Assert.That(healedChangeIdElement, Is.Not.Null);
        await healedChangeIdElement!.PressAsync("Enter");
    }

    [Test]
    public async Task Input_fields_click_with_FindBy_annotation()
    {
        var testClassElement = await Page.QuerySelectorAsync("input.test_class");
        Assert.That(testClassElement, Is.Not.Null);
        await testClassElement!.PressAsync("Enter");

        var testTagElement = await Page.QuerySelectorAsync("test_tag#change_element");
        Assert.That(testTagElement, Is.Not.Null);
        var classAttr = await testTagElement!.GetAttributeAsync("class");
        Assert.That(classAttr, Is.EqualTo("shadow-input1"));

        var changeNameElement = await Page.QuerySelectorAsync("input[name=\"change_name\"]");
        Assert.That(changeNameElement, Is.Not.Null);
        await changeNameElement!.PressAsync("Enter");

        var linkElement = await Page.QuerySelectorAsync("a:has-text(\"Change: LinkText, PartialLinkText\")");
        Assert.That(linkElement, Is.Not.Null);
        await linkElement!.IsVisibleAsync();
        var linkClassAttr = await linkElement.GetAttributeAsync("class");
        Assert.That(linkClassAttr, Is.EqualTo("input1"));

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedTestClassElement = await Page.QuerySelectorAsync("input.test_class");
        Assert.That(healedTestClassElement, Is.Not.Null);
        await healedTestClassElement!.PressAsync("Enter");

        var healedTestTagElement = await Page.QuerySelectorAsync("test_tag#change_element");
        Assert.That(healedTestTagElement, Is.Not.Null);
        var healedClassAttr = await healedTestTagElement!.GetAttributeAsync("class");
        Assert.That(healedClassAttr, Is.EqualTo(classAttr));

        var healedChangeNameElement = await Page.QuerySelectorAsync("input[name=\"change_name\"]");
        Assert.That(healedChangeNameElement, Is.Not.Null);
        await healedChangeNameElement!.PressAsync("Enter");

        var healedLinkElement = await Page.QuerySelectorAsync("a:has-text(\"Change: LinkText, PartialLinkText\")");
        Assert.That(healedLinkElement, Is.Not.Null);
        await healedLinkElement!.IsVisibleAsync();
        var healedLinkClassAttr = await healedLinkElement.GetAttributeAsync("class");
        Assert.That(healedLinkClassAttr, Is.EqualTo(linkClassAttr));
    }

    [Test]
    public async Task Checkbox_verify_with_FindBy_annotation()
    {
        var checkbox1 = await Page.QuerySelectorAsync("input.input1#form_checked1");
        Assert.That(checkbox1, Is.Not.Null);
        var checkbox2 = await Page.QuerySelectorAsync("input.input1#form_checked2");
        Assert.That(checkbox2, Is.Not.Null);
        var checkbox3 = await Page.QuerySelectorAsync("input.input1#form_checked3");
        Assert.That(checkbox3, Is.Not.Null);

        var submitCheckboxBtn = await Page.QuerySelectorAsync("#Submit_checkbox");
        Assert.That(submitCheckboxBtn, Is.Not.Null);
        await submitCheckboxBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var healedCheckbox1 = await Page.QuerySelectorAsync("input.input1#form_checked1");
        Assert.That(healedCheckbox1, Is.Not.Null);
        var healedCheckbox2 = await Page.QuerySelectorAsync("input.input1#form_checked2");
        Assert.That(healedCheckbox2, Is.Not.Null);
        var healedCheckbox3 = await Page.QuerySelectorAsync("input.input1#form_checked3");
        Assert.That(healedCheckbox3, Is.Not.Null);
    }

    [Test]
    public async Task Input_field_enable_to_disable_with_FindBy_annotation()
    {
        var enabledElement = await Page.QuerySelectorAsync("#change_enabled");
        Assert.That(enabledElement, Is.Not.Null);
        Assert.That(await enabledElement!.IsEnabledAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var disabledElement = await Page.QuerySelectorAsync("#change_enabled");
        Assert.That(disabledElement, Is.Not.Null);
        Assert.That(await disabledElement!.IsDisabledAsync(), Is.True);
    }

    [Test]
    public async Task Checkbox_checked_to_unchecked_with_FindBy_annotation()
    {
        var checkedElement = await Page.QuerySelectorAsync("#change_checked");
        Assert.That(checkedElement, Is.Not.Null);
        Assert.That(await checkedElement!.IsCheckedAsync(), Is.True);

        var submitBtn = await Page.QuerySelectorAsync("#Submit");
        Assert.That(submitBtn, Is.Not.Null);
        await submitBtn!.ClickAsync(new() { Timeout = PageTimeout });
        await Page.WaitForTimeoutAsync(PageWaitTimeout);

        var uncheckedElement = await Page.QuerySelectorAsync("#change_checked");
        Assert.That(uncheckedElement, Is.Not.Null);
        Assert.That(await uncheckedElement!.IsCheckedAsync(), Is.False);
    }
}
