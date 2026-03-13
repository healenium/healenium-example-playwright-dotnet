using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class InfoChbxTests : BaseHealeniumTest
{
    private const int InfoTimeout = 3000;

    [Test]
    public async Task IsChecked()
    {
        var checkbox = Page.Locator("input.input1#form_checked1");

        await checkbox.CheckAsync(new() { Timeout = InfoTimeout });
        var isCheckboxChecked = await checkbox.IsCheckedAsync(new() { Timeout = InfoTimeout });
        Assert.That(isCheckboxChecked, Is.True);

        var submitBtn = Page.Locator("#Submit_checkbox");
        await submitBtn.ClickAsync();

        var healedCheckbox = Page.Locator("input.input1#form_checked1");
        await healedCheckbox.CheckAsync(new() { Timeout = InfoTimeout });
        var healedIsCheckboxChecked = await healedCheckbox.IsCheckedAsync(new() { Timeout = InfoTimeout });
        Assert.That(healedIsCheckboxChecked, Is.True);
    }
}
