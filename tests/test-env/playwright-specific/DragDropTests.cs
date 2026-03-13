using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class DragDropTests : BaseHealeniumTest
{
    [Test]
    public async Task Source_playwright_specific()
    {
        var draggableElement = Page.Locator(".drag-container").GetByText("Green Item");
        var droppableElement = Page.Locator("#drop1");
        await draggableElement.DragToAsync(droppableElement, new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedDraggableElement = Page.Locator(".drag-container").GetByText("Green Item");
        var healedDroppableElement = Page.Locator("#drop1");
        await healedDraggableElement.DragToAsync(healedDroppableElement, new() { Timeout = Timeout });
    }

    [Test]
    public async Task Source_xpath()
    {
        var draggableElement = Page.Locator("//div[@class=\"drag-container\"]/div[@name=\"dragRed\"]");
        var droppableElement = Page.Locator("#drop1");
        await draggableElement.DragToAsync(droppableElement, new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedDraggableElement = Page.Locator("//div[@class=\"drag-container\"]/div[@name=\"dragRed\"]");
        var healedDroppableElement = Page.Locator("#drop1");
        await healedDraggableElement.DragToAsync(healedDroppableElement, new() { Timeout = Timeout });
    }

    [Test]
    public async Task Target_playwright_specific()
    {
        var draggableElement = Page.Locator(".drag-container").GetByText("Green Item");
        var droppableElement = Page.GetByTestId("testid_drop1");
        await draggableElement.DragToAsync(droppableElement, new() { Timeout = Timeout });

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedDraggableElement = Page.Locator(".drag-container").GetByText("Green Item");
        var healedDroppableElement = Page.GetByTestId("testid_drop1");
        await healedDraggableElement.DragToAsync(healedDroppableElement, new() { Timeout = Timeout });
    }
}
