using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class CollectionDeprTests : BaseHealeniumTest
{
    [Test]
    public async Task ElementHandle_method_get_single_ElementHandle_deprecated()
    {
        var inputHandle = await Page.Locator(".test_class").ElementHandleAsync(new() { Timeout = Timeout });
        Assert.That(inputHandle, Is.Not.Null);
        await inputHandle!.FillAsync("New text value");
        Assert.That(await inputHandle.InputValueAsync(), Is.EqualTo("New text value"));

        var submitBtn = Page.Locator("#Submit");
        await submitBtn.ClickAsync();

        var healedInputHandle = await Page.Locator(".test_class").ElementHandleAsync(new() { Timeout = Timeout });
        Assert.That(healedInputHandle, Is.Not.Null);
        Assert.That(await healedInputHandle!.InputValueAsync(), Is.EqualTo("New text value"));
    }
}
