using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class InfoTests : BaseHealeniumTest
{
    private const int InfoTimeout = 3000;

    [Test]
    public async Task TextContent_method()
    {
        var inputField = Page.Locator("#select_item option[value=\"1\"]");
        var textContent = await inputField.TextContentAsync(new() { Timeout = InfoTimeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("#select_item option[value=\"1\"]");
        var healedTextContent = await healedInputField.TextContentAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedTextContent, Is.EqualTo(textContent));
    }

    [Test]
    public async Task InnerText_method()
    {
        var element = Page.Locator("[name=\"dragRed\"]");
        var innerText = await element.InnerTextAsync(new() { Timeout = InfoTimeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedElement = Page.Locator("[name=\"dragRed\"]");
        var healedInnerText = await healedElement.InnerTextAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedInnerText, Is.EqualTo(innerText));
    }

    [Test]
    public async Task InnerHTML_method()
    {
        var element = Page.Locator("[name=\"dragRed\"]");
        var innerHTML = await element.InnerHTMLAsync(new() { Timeout = InfoTimeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedElement = Page.Locator("[name=\"dragRed\"]");
        var healedInnerHTML = await healedElement.InnerHTMLAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedInnerHTML, Is.EqualTo(innerHTML));
    }

    [Test]
    public async Task InputValue_method()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.FillAsync("Test value", new() { Timeout = InfoTimeout });
        var inputValue = await inputField.InputValueAsync(new() { Timeout = InfoTimeout });
        Assert.That(inputValue, Is.EqualTo("Test value"));

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.FillAsync("Test value", new() { Timeout = InfoTimeout });
        var healedInputValue = await healedInputField.InputValueAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedInputValue, Is.EqualTo("Test value"));
    }

    [Test]
    public async Task GetAttribute_method()
    {
        var inputField = Page.Locator(".test_class");
        var attribute = await inputField.GetAttributeAsync("name", new() { Timeout = InfoTimeout });
        Assert.That(attribute, Is.EqualTo("Field2"));

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        var healedAttribute = await healedInputField.GetAttributeAsync("name", new() { Timeout = InfoTimeout });
        Assert.That(healedAttribute, Is.EqualTo("Field2"));
    }

    [Test]
    public async Task BoundingBox_method()
    {
        var inputField = Page.Locator("#select_item");
        var boundingBox = await inputField.BoundingBoxAsync(new() { Timeout = InfoTimeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("#select_item");
        var healedBoundingBox = await healedInputField.BoundingBoxAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedBoundingBox, Is.Not.Null);
        Assert.That(boundingBox, Is.Not.Null);
        Assert.That(healedBoundingBox!.Width, Is.EqualTo(boundingBox!.Width));
        Assert.That(healedBoundingBox.Height, Is.EqualTo(boundingBox.Height));
    }

    [Test]
    public async Task IsEnabled_method()
    {
        var inputField = Page.Locator(".test_class");
        var isEnabled = await inputField.IsEnabledAsync(new() { Timeout = InfoTimeout });
        Assert.That(isEnabled, Is.True);

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        var healedIsEnabled = await healedInputField.IsEnabledAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedIsEnabled, Is.True);
    }

    [Test]
    public async Task IsDisabled_method()
    {
        var inputField = Page.Locator(".test_class");
        var isDisabled = await inputField.IsDisabledAsync(new() { Timeout = InfoTimeout });
        Assert.That(isDisabled, Is.False);

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        var healedIsDisabled = await healedInputField.IsDisabledAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedIsDisabled, Is.False);
    }

    [Test]
    public async Task IsEditable_method()
    {
        var inputField = Page.Locator(".test_class");
        var isInputEditable = await inputField.IsEditableAsync(new() { Timeout = InfoTimeout });
        Assert.That(isInputEditable, Is.True);

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        var healedIsInputEditable = await healedInputField.IsEditableAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedIsInputEditable, Is.True);
    }
}
