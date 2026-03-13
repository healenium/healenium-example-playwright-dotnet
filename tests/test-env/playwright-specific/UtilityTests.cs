using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class UtilityTests : BaseHealeniumTest
{
    [Test]
    public async Task Describe_action()
    {
        var changeIdInput = Page.Locator("input#change_id");
        var changeClassInput = Page.Locator(".test_class");

        await changeIdInput.ClickAsync(new() { Timeout = Timeout });
        await changeClassInput.FillAsync("Test description", new() { Timeout = Timeout });

        await Expect(changeIdInput).ToBeVisibleAsync();
        await Expect(changeClassInput).ToHaveValueAsync("Test description");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedChangeIdInput = Page.Locator("input#change_id");
        var healedChangeClassInput = Page.Locator(".test_class");
        await healedChangeIdInput.ClickAsync(new() { Timeout = Timeout });
        await healedChangeClassInput.FillAsync("Test description", new() { Timeout = Timeout });

        await Expect(healedChangeIdInput).ToBeVisibleAsync();
        await Expect(healedChangeClassInput).ToHaveValueAsync("Test description");
    }

    [Test]
    public async Task AriaSnapshot_action()
    {
        var changeIdInput = Page.Locator("input#change_id");
        var inputAriaSnapshot = await changeIdInput.EvaluateAsync<string>("el => el.getAttribute('role') ?? el.tagName");
        Assert.That(inputAriaSnapshot, Is.Not.Null.And.Not.Empty);

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedChangeIdInput = Page.Locator("input#change_id");
        var healedInputAriaSnapshot = await healedChangeIdInput.EvaluateAsync<string>("el => el.getAttribute('role') ?? el.tagName");
        Assert.That(healedInputAriaSnapshot, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Dispatch_event_action()
    {
        var inputField = Page.Locator(".test_class");
        var childTag = Page.Locator("child_tag#change_element_last_child");
        var testTag = Page.Locator("test_tag#change_element");
        var changeNameInput = Page.Locator("input[name=\"change_name\"]");

        await inputField.DispatchEventAsync("keydown", new Dictionary<string, object> { ["key"] = "A" });
        await childTag.DispatchEventAsync("customEvent", new Dictionary<string, object> { ["detail"] = "custom data" });
        await testTag.DispatchEventAsync("click");
        await changeNameInput.DispatchEventAsync("input", new Dictionary<string, object> { ["data"] = "test" });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        var healedChildTag = Page.Locator("child_tag#change_element_last_child");
        var healedTestTag = Page.Locator("test_tag#change_element");
        var healedChangeNameInput = Page.Locator("input[name=\"change_name\"]");

        await healedInputField.DispatchEventAsync("keydown", new Dictionary<string, object> { ["key"] = "A" });
        await healedChildTag.DispatchEventAsync("customEvent", new Dictionary<string, object> { ["detail"] = "custom data" });
        await healedTestTag.DispatchEventAsync("click");
        await healedChangeNameInput.DispatchEventAsync("input", new Dictionary<string, object> { ["data"] = "test" });
    }

    [Test]
    public async Task WaitFor_action()
    {
        var testClassInput = Page.Locator(".test_class");

        await testClassInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = Timeout });

        await testClassInput.FillAsync("WaitFor test", new() { Timeout = Timeout });
        await Expect(testClassInput).ToHaveValueAsync("WaitFor test", new() { Timeout = Timeout });

        await testClassInput.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedTestClassInput = Page.Locator(".test_class");

        await healedTestClassInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = Timeout });

        await healedTestClassInput.FillAsync("WaitFor test", new() { Timeout = Timeout });
        await Expect(healedTestClassInput).ToHaveValueAsync("WaitFor test", new() { Timeout = Timeout });

        await healedTestClassInput.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = Timeout });
    }
}
