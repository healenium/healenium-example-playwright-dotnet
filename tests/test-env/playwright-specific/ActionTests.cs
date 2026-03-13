using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class ActionTests : BaseHealeniumTest
{
    [Test]
    public async Task Click_action()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.ClickAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.ClickAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Double_click_action()
    {
        var inputField = Page.Locator("input#change_id");
        await inputField.DblClickAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("input#change_id");
        await healedInputField.DblClickAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Blur_action()
    {
        var inputField = Page.Locator("input#change_id");
        await inputField.BlurAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("input#change_id");
        await healedInputField.BlurAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Fill_and_clear_actions()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.FillAsync("Hello World", new() { Timeout = Timeout });
        await Expect(inputField).ToHaveValueAsync("Hello World");

        await inputField.ClearAsync(new() { Timeout = Timeout });
        await Expect(inputField).ToHaveValueAsync("");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.FillAsync("Hello World", new() { Timeout = Timeout });
        await Expect(healedInputField).ToHaveValueAsync("Hello World");

        await healedInputField.ClearAsync(new() { Timeout = Timeout });
        await Expect(healedInputField).ToHaveValueAsync("");
    }

    [Test]
    public async Task Type_action()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.PressSequentiallyAsync("Typing text slowly", new() { Timeout = Timeout });
        await Expect(inputField).ToHaveValueAsync("Typing text slowly");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.PressSequentiallyAsync("Typing text slowly", new() { Timeout = Timeout });
        await Expect(healedInputField).ToHaveValueAsync("Typing text slowlyTyping text slowly");
    }

    [Test]
    public async Task Press_sequentially_action()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.PressSequentiallyAsync("Sequential typing", new() { Delay = 100, Timeout = Timeout });
        await Expect(inputField).ToHaveValueAsync("Sequential typing");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.PressSequentiallyAsync("Sequential typing", new() { Delay = 100, Timeout = Timeout });
        await Expect(healedInputField).ToHaveValueAsync("Sequential typingSequential typing");
    }

    [Test]
    public async Task Press_action()
    {
        var inputField = Page.Locator("input#change_id");
        await inputField.FillAsync("Test text", new() { Timeout = Timeout });
        await inputField.PressAsync("Enter", new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("input#change_id");
        await healedInputField.FillAsync("Test text", new() { Timeout = Timeout });
        await healedInputField.PressAsync("Enter", new() { Timeout = Timeout });
    }

    [Test]
    public async Task Hover_action()
    {
        var inputField = Page.Locator("input#change_id");
        await inputField.HoverAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator("input#change_id");
        await healedInputField.HoverAsync(new() { Timeout = Timeout });
    }

    [Test]
    public async Task Focus_and_blur_actions()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.FocusAsync(new() { Timeout = Timeout });
        await Expect(inputField).ToBeFocusedAsync();
        await inputField.BlurAsync(new() { Timeout = Timeout });
        await Expect(inputField).Not.ToBeFocusedAsync();

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.FocusAsync(new() { Timeout = Timeout });
        await Expect(healedInputField).ToBeFocusedAsync();
        await healedInputField.BlurAsync(new() { Timeout = Timeout });
        await Expect(healedInputField).Not.ToBeFocusedAsync();
    }

    [Test]
    public async Task Scroll_into_view_if_needed_action()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.ScrollIntoViewIfNeededAsync(new() { Timeout = Timeout });
        await Expect(inputField).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.ScrollIntoViewIfNeededAsync(new() { Timeout = Timeout });
        await Expect(healedInputField).ToBeVisibleAsync();
    }

    [Test]
    public async Task Select_text_action()
    {
        var inputField = Page.Locator(".test_class");
        await inputField.FillAsync("Text to select", new() { Timeout = Timeout });
        await inputField.SelectTextAsync(new() { Timeout = Timeout });
        await Expect(inputField).ToBeFocusedAsync();

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputField = Page.Locator(".test_class");
        await healedInputField.FillAsync("Text to select", new() { Timeout = Timeout });
        await healedInputField.SelectTextAsync(new() { Timeout = Timeout });
        await Expect(healedInputField).ToBeFocusedAsync();
    }

    [Test]
    public async Task Select_option_action()
    {
        var selectElement = Page.Locator("#select_item");
        await selectElement.SelectOptionAsync(new SelectOptionValue { Label = "Item 1" }, new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedSelectElement = Page.Locator("#select_item");
        await healedSelectElement.SelectOptionAsync(new SelectOptionValue { Label = "Item 1" }, new() { Timeout = Timeout });
        await Expect(healedSelectElement).ToHaveValueAsync("1");
    }

    [Test]
    public async Task Set_input_files_action()
    {
        var testFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "test-data", "test-file.txt"));
        if (!File.Exists(testFilePath))
            testFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "test-data", "test-file.txt"));
        Assert.That(File.Exists(testFilePath), Is.True, "test-data/test-file.txt not found. Ensure test-data is copied to output.");

        var inputFile = Page.Locator("#file_input");
        await inputFile.SetInputFilesAsync(testFilePath, new() { Timeout = Timeout });

        var value = await inputFile.InputValueAsync(new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputFile = Page.Locator("#file_input");
        await healedInputFile.SetInputFilesAsync(testFilePath, new() { Timeout = Timeout });

        var healedValue = await healedInputFile.InputValueAsync(new() { Timeout = Timeout });

        Assert.That(healedValue, Is.EqualTo(value));
    }
}
