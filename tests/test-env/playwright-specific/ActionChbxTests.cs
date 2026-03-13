using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class ActionChbxTests : BaseHealeniumTest
{
    [Test]
    public async Task Check_action()
    {
        var checkbox = Page.Locator("input.input1#form_checked1");
        await checkbox.CheckAsync(new() { Timeout = Timeout });
        await Expect(checkbox).ToBeCheckedAsync();

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox = Page.Locator("input.input1#form_checked1");
        await healedCheckbox.CheckAsync(new() { Timeout = Timeout });
        await Expect(healedCheckbox).ToBeCheckedAsync();
    }

    [Test]
    public async Task Uncheck_action()
    {
        var checkbox2 = Page.Locator("input.input1#form_checked2");
        await checkbox2.UncheckAsync(new() { Timeout = Timeout });
        await Expect(checkbox2).Not.ToBeCheckedAsync();

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox2 = Page.Locator("input.input1#form_checked2");
        await healedCheckbox2.UncheckAsync(new() { Timeout = Timeout });
        await Expect(healedCheckbox2).Not.ToBeCheckedAsync();
    }

    [Test]
    public async Task Set_checked_true_action()
    {
        var checkbox = Page.Locator("input.input1#form_checked1");
        await checkbox.SetCheckedAsync(true, new() { Timeout = Timeout });
        await Expect(checkbox).ToBeCheckedAsync();

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox = Page.Locator("input.input1#form_checked1");
        await healedCheckbox.SetCheckedAsync(true, new() { Timeout = Timeout });
        await Expect(healedCheckbox).ToBeCheckedAsync();
    }

    [Test]
    public async Task Set_checked_false_action()
    {
        var checkbox2 = Page.Locator("input.input1#form_checked2");
        await checkbox2.SetCheckedAsync(false, new() { Timeout = Timeout });
        await Expect(checkbox2).Not.ToBeCheckedAsync();

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox2 = Page.Locator("input.input1#form_checked2");
        await healedCheckbox2.SetCheckedAsync(false, new() { Timeout = Timeout });
        await Expect(healedCheckbox2).Not.ToBeCheckedAsync();
    }

    [Test]
    public async Task Set_checked_with_force_action()
    {
        var checkbox = Page.Locator("input.input1#form_checked1");
        await checkbox.SetCheckedAsync(true, new() { Force = true, Timeout = Timeout });
        await Expect(checkbox).ToBeCheckedAsync();

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox = Page.Locator("input.input1#form_checked1");
        await healedCheckbox.SetCheckedAsync(true, new() { Force = true, Timeout = Timeout });
        await Expect(healedCheckbox).ToBeCheckedAsync();
    }
}
