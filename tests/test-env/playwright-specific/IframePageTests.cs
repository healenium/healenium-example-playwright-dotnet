using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class IframePageTests : BaseHealeniumTest
{
    [Test]
    public async Task Iframe_change_frame_title_healing()
    {
        var iframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        var frame = await iframeElement!.ContentFrameAsync();
        var inputField = frame!.Locator("#iframe_input");
        await inputField.ClickAsync(new() { Timeout = Timeout });

        var submitBtn = await Page.Locator("#Submit").ElementHandleAsync(new() { Timeout = Timeout });
        await submitBtn!.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedIframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);
        var healedFrame = await healedIframeElement!.ContentFrameAsync();
        var healedInputField = healedFrame!.Locator("#iframe_input");
        await Page.WaitForTimeoutAsync(WaitTimeout);
        await healedInputField.ClickAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Iframe_change_input_field_healing()
    {
        var iframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        var frame = await iframeElement!.ContentFrameAsync();
        var inputField = frame!.Locator("#iframe_input");
        await inputField.ClickAsync(new() { Timeout = Timeout });

        var iframeSubmitBtn = frame!.Locator("#iframe_Submit");
        await iframeSubmitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedInputField = frame!.Locator("#iframe_input");
        await Page.WaitForTimeoutAsync(WaitTimeout);
        await healedInputField.ClickAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Iframe_change_frame_title_and_input_field_healing()
    {
        var iframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        var frame = await iframeElement!.ContentFrameAsync();
        var inputField = frame!.Locator("#iframe_input");
        await inputField.ClickAsync(new() { Timeout = Timeout });

        var iframeSubmitBtn = frame!.Locator("#iframe_Submit");
        await iframeSubmitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var submitBtn = await Page.Locator("#Submit").ElementHandleAsync(new() { Timeout = Timeout });
        await submitBtn!.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedIframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);
        var healedFrame = await healedIframeElement!.ContentFrameAsync();
        var healedInputField = healedFrame!.Locator("#iframe_input");
        await Page.WaitForTimeoutAsync(WaitTimeout);
        await healedInputField.ClickAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Iframe_change_nested_frame_healing()
    {
        var iframeElement = await Page.Locator("iframe[title=\"Iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        var frame = await iframeElement!.ContentFrameAsync();
        var nestedFrameElement = await frame!.Locator("iframe[title=\"Nested iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        var nestedFrame = await nestedFrameElement!.ContentFrameAsync();
        var inputField = nestedFrame!.Locator("#iframe_2_input");
        await inputField.ClickAsync(new() { Timeout = Timeout });

        var iframeSubmitBtn = frame!.Locator("#iframe_Submit");
        await iframeSubmitBtn.ClickAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);

        var healedNestedFrameElement = await frame!.Locator("iframe[title=\"Nested iframe Example\"]").ElementHandleAsync(new() { Timeout = Timeout });
        await Page.WaitForTimeoutAsync(WaitTimeout);
        var healedNestedFrame = await healedNestedFrameElement!.ContentFrameAsync();

        var healedInputField = healedNestedFrame!.Locator("#iframe_2_input");
        await Page.WaitForTimeoutAsync(WaitTimeout);
        await healedInputField.ClickAsync(new() { Timeout = Timeout });
    }
}
