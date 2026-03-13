using HealeniumExamplePlaywrightDotnet;
using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace HealeniumExamplePlaywrightDotnet.Tests.TestEnv.PlaywrightSpecific;

[TestFixture]
[Category("slow")]
public class ExpectSpecialAssertionsTests : BaseHealeniumTest
{
    [Test]
    public async Task ToMatchAriaSnapshot()
    {
        const string snapshot = "- text: Drop Zone";
        var loc = Page.Locator("#drop1");
        await Expect(loc).ToMatchAriaSnapshotAsync(snapshot, new() { Timeout = Timeout });

        await Page.Locator("#Submit_checkbox").ClickAsync();

        var healed = Page.Locator("#drop1");
        await Expect(healed).ToMatchAriaSnapshotAsync(snapshot, new() { Timeout = Timeout });
    }
}
