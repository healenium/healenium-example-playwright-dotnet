
using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class LocatorChainTests : BaseHealeniumTest
{
    [Test]
    public async Task Simple_chain_form_then_getByPlaceholder()
    {
        var input = Page.Locator("input#validate_testId");
        await input.FillAsync("chained", new LocatorFillOptions { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInput = Page.Locator("input#validate_testId");
        await healedInput.FillAsync("chained healed", new LocatorFillOptions { Timeout = Timeout });
        await Expect(healedInput).ToHaveValueAsync("chained healed");
    }

    [Test]
    public async Task Simple_chain_form_then_getByRole_textbox()
    {
        var input = Page.Locator("input#change_className");
        await input.FillAsync("role and label", new LocatorFillOptions { Timeout = Timeout });
        await Expect(input).ToHaveValueAsync("role and label");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInput = Page.Locator("input#change_className");
        await healedInput.FillAsync("role and label after heal", new LocatorFillOptions { Timeout = Timeout });
        await Expect(healedInput).ToHaveValueAsync("role and label after heal");
    }

    [Test]
    public async Task Chain_with_and_getByPlaceholder_and_getByTitle()
    {
        var input = Page.Locator("input#validate_testId");
        await input.FillAsync("and chain", new LocatorFillOptions { Timeout = Timeout });
        await Expect(input).ToHaveValueAsync("and chain");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInput = Page.Locator("input#validate_testId");
        await healedInput.FillAsync("and chain healed", new LocatorFillOptions { Timeout = Timeout });
        await Expect(healedInput).ToHaveValueAsync("and chain healed");
    }

    [Test]
    public async Task Chain_with_filter_drag_container_then_hasText()
    {
        var greenItem = Page.Locator(".drag-container").Filter(new() { HasText = "Green Item" });
        await Expect(greenItem).ToBeVisibleAsync(new() { Timeout = Timeout });
        await Expect(greenItem).ToHaveCountAsync(1);

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedGreenItem = Page.Locator(".drag-container").Filter(new() { HasText = "Green Item" });
        await Expect(healedGreenItem).ToBeVisibleAsync(new() { Timeout = Timeout });
        await Expect(healedGreenItem).ToHaveCountAsync(1);
    }

    [Test]
    public async Task Chain_with_or_getByTestId_or_getByPlaceholder()
    {
        var input = Page.GetByTestId("change_testId").Or(Page.GetByPlaceholder("Change: TestId"));
        await input.FillAsync("or chain", new LocatorFillOptions { Timeout = Timeout });
        await Expect(input).ToHaveValueAsync("or chain");

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInput = Page.GetByTestId("change_testId").Or(Page.GetByPlaceholder("Change: TestId"));
        await healedInput.FillAsync("or chain healed", new LocatorFillOptions { Timeout = Timeout });
        await Expect(healedInput).ToHaveValueAsync("or chain healed");
    }

    [Test]
    public async Task Chain_with_or_getByTitle_or_getByTestId()
    {
        var input = Page.GetByTitle("Validate change test id").Or(Page.GetByTestId("change_testId"));
        await Expect(input).ToBeVisibleAsync(new() { Timeout = Timeout });
        await input.FillAsync("or title testid", new LocatorFillOptions { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInput = Page.GetByTitle("Validate change test id").Or(Page.GetByTestId("change_testId"));
        await Expect(healedInput).ToHaveValueAsync("or title testid", new() { Timeout = Timeout });
    }

    [Test]
    public async Task Chain_with_first_test_tag_then_first()
    {
        var element = Page.Locator("test_tag").First;
        await Expect(element).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedElement = Page.Locator("test_tag").First;
        await Expect(healedElement).ToBeVisibleAsync();
    }

    [Test]
    public async Task Chain_with_last_child_tag_then_last()
    {
        var element = Page.Locator("child_tag").Last;
        await Expect(element).ToBeVisibleAsync();

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedElement = Page.Locator("child_tag").Last;
        await Expect(healedElement).ToBeVisibleAsync();
    }
}
