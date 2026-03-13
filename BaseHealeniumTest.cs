using Microsoft.Playwright;
using NUnit.Framework;

namespace HealeniumExamplePlaywrightDotnet;

/// <summary>
/// Base class for Healenium Playwright tests. Connects to a remote Playwright server via WebSocket
/// (e.g. Healenium playwright proxy), following the same pattern as connecting from a local client:
/// <code>
/// using var playwright = await Playwright.CreateAsync();
/// await using var browser = await playwright.Chromium.ConnectAsync(remoteWsEndpoint);
/// var context = await browser.NewContextAsync();
/// var page = await context.NewPageAsync();
/// </code>
/// </summary>
public abstract class BaseHealeniumTest
{
    /// <summary>Default WebSocket endpoint for Healenium playwright proxy (server must be running).</summary>
    private const string DefaultWsEndpoint = "ws://localhost:8095/hlm-playwright-proxy";

    protected const int Timeout = 5000;
    protected const int WaitTimeout = 250;
    protected const string BaseUrl = "https://healenium.github.io/healenium-test-env/index.html";

    private static IPlaywright? _playwright;
    private static IBrowser? _browser;
    private static IBrowserContext? _context;

    protected IPage Page { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        // Connect to the remote Playwright server (same pattern as LocalClient example)
        _playwright = await Playwright.CreateAsync();

        var remoteWsEndpoint = Environment.GetEnvironmentVariable("PLAYWRIGHT_SERVER_URL")?.Trim();
        if (string.IsNullOrEmpty(remoteWsEndpoint))
            remoteWsEndpoint = DefaultWsEndpoint;

        _browser = await _playwright.Chromium.ConnectAsync(DefaultWsEndpoint);
        _context = await _browser.NewContextAsync();
    }

    [SetUp]
    public async Task SetUpAsync()
    {
        Page = await _context!.NewPageAsync();
        await Page.GotoAsync(BaseUrl, new PageGotoOptions { WaitUntil = WaitUntilState.Load });
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        if (Page != null)
            await Page.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync()
    {
        if (_context != null) await _context.CloseAsync();
        if (_browser != null) await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}
