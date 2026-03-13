using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class GetByTests : BaseHealeniumTest
{
    [Test]
    public async Task GetByRole_img_alt()
    {
        await Expect(Page.GetByRole(AriaRole.Img, new() { Name = "Healenium Logo" })).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Img, new() { Name = "Healenium Logo" })).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByRole_textbox_aria_label()
    {
        await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "change_tag_aria_label" })).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "change_tag_aria_label" })).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByRole_textbox_aria_labelledby()
    {
        await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "Field labeled by" })).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "Field labeled by" })).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByText()
    {
        await Expect(Page.GetByText("Green Item")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByText("Green Item")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByLabel()
    {
        await Expect(Page.GetByLabel("Field with hover")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByLabel("Field with hover")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByPlaceholder()
    {
        await Expect(Page.GetByPlaceholder("Change: TestId")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByPlaceholder("Change: TestId")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByAltText()
    {
        await Expect(Page.GetByAltText("Healenium Logo")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByAltText("Healenium Logo")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByTitle()
    {
        await Expect(Page.GetByTitle("Validate change test id")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByTitle("Validate change test id")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task GetByTestId()
    {
        await Expect(Page.GetByTestId("change_testId")).ToBeVisibleAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        await Expect(Page.GetByTestId("change_testId")).ToBeVisibleAsync(new() { Timeout = Timeout });
    }
}
