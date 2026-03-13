using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class IframeTests : BaseHealeniumTest
{
    [Test]
    public async Task Iframe_change_frame_title_input_field_expect()
    {
        var iframe = Page.FrameLocator("iframe[title=\"Iframe Example\"]");

        var inputField = iframe.Locator("#iframe_input");
        await Expect(inputField).ToBeVisibleAsync();

        var submitBtn = iframe.Locator("#iframe_Submit");
        await submitBtn.ClickAsync();

        var healedInputField = iframe.Locator("#iframe_input");
        await Expect(healedInputField).ToBeVisibleAsync();
    }

    [Test]
    public async Task Iframe_change_frame_title_select_option_action()
    {
        var iframe = Page.FrameLocator("iframe[title=\"Iframe Example\"]");

        var selectElement = iframe.Locator("#iframe_select_item");
        await selectElement.SelectOptionAsync(new SelectOptionValue { Label = "iframe Item 1" }, new() { Timeout = Timeout });
        await Expect(selectElement).ToHaveValueAsync("11");

        var submitBtn = iframe.Locator("#iframe_Submit");
        await submitBtn.ClickAsync();

        var healedSelectElement = iframe.Locator("#iframe_select_item");
        await healedSelectElement.SelectOptionAsync(new SelectOptionValue { Label = "iframe Item 2" }, new() { Timeout = Timeout });
        await Expect(healedSelectElement).ToHaveValueAsync("22");
    }

    [Test]
    public async Task Iframe_change_all_nested_path()
    {
        var inputField = Page.FrameLocator("iframe[title=\"Iframe Example\"]")
            .FrameLocator("iframe[title=\"Nested iframe Example\"]")
            .Locator("#iframe_2_input");
        await Expect(inputField).ToBeVisibleAsync();

        var submitBtn = Page.FrameLocator("iframe[title=\"Iframe Example\"]").Locator("#iframe_Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.FrameLocator("iframe[title=\"Iframe Example\"]")
            .FrameLocator("iframe[title=\"Nested iframe Example\"]")
            .Locator("#iframe_2_input");
        await Expect(healedInputField).ToBeVisibleAsync();
    }

}
