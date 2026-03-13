using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class PseudoClassTests : BaseHealeniumTest
{
    private const int PseudoTimeout = 3000;

    [Test]
    public async Task Text_selector()
    {
        await Expect(Page.Locator("text=Green Item")).ToBeVisibleAsync();
        await Page.Locator("#Submit").ClickAsync(new() { Timeout = PseudoTimeout });
        await Expect(Page.Locator("text=Green Item")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Data_testid_selector()
    {
        await Expect(Page.Locator("data-testid=change_testId")).ToBeVisibleAsync();
        await Page.Locator("#Submit").ClickAsync(new() { Timeout = PseudoTimeout });
        await Expect(Page.Locator("data-testid=change_testId")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Xpath_selector()
    {
        await Expect(Page.Locator("xpath=//input[@id=\"change_id\"]")).ToBeVisibleAsync();
        await Page.Locator("#Submit").ClickAsync(new() { Timeout = PseudoTimeout });
        await Expect(Page.Locator("xpath=//input[@id=\"change_id\"]")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Css_selector()
    {
        await Expect(Page.Locator("css=.test_class")).ToBeVisibleAsync();
        await Page.Locator("#Submit").ClickAsync(new() { Timeout = PseudoTimeout });
        await Expect(Page.Locator("css=.test_class")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Id_selector()
    {
        await Expect(Page.Locator("id=change_id")).ToBeVisibleAsync();
        await Page.Locator("#Submit").ClickAsync(new() { Timeout = PseudoTimeout });
        await Expect(Page.Locator("id=change_id")).ToBeVisibleAsync();
    }
}
