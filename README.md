# healenium-example-playwright-dotnet

## Prerequisites

Connection to Healenium proxy is configured in `BaseHealeniumTest.cs`:

```csharp
var wsEndpoint = Environment.GetEnvironmentVariable("PLAYWRIGHT_SERVER_URL")
    ?? "ws://localhost:8095/hlm-playwright-proxy";
_browser = await _playwright.Chromium.ConnectAsync(wsEndpoint, new BrowserTypeConnectOptions
{
    Timeout = 60000
});
```

## Build

```bash
dotnet restore
dotnet build
```

Install Playwright browsers (if running without Healenium proxy):

```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

Or use the system-wide Playwright:

```bash
playwright install
```

## Run Playwright server separately (optional)

See healenium docker-compose. If the Playwright server is not running with the playwright-proxy, run it separately:

```bash
npx -y playwright run-server --port 5050
```

## Run Playwright proxy with Node server

[healenium-playwright-proxy](https://github.com/healenium/healenium-playwright-proxy)

Connection to the proxy is configured in `BaseHealeniumTest.cs`.

## Run tests

All tests:

```bash
dotnet test
```

Filter by test class (e.g. locator chain tests):

```bash
dotnet test --filter "FullyQualifiedName~LocatorChainTests"
```

Run a single test:

```bash
dotnet test --filter "FullyQualifiedName~Simple_chain_form_then_getByPlaceholder"
```

## Project structure

- `BaseHealeniumTest.cs` – base class that connects to the Healenium Playwright proxy and provides `Page` and common timeouts.
- `tests/test-env/playwright-specific/` – Playwright Locator API tests (chained locators, getBy, actions, expect, iframe, drag-drop, utility, pseudo-class).
- `tests/test-env/selenium-like-locator-api/` – Selenium-like locator tests (CSS, XPath, simple, general, parent-child).

## Docs

[Running and debugging Playwright tests](https://playwright.dev/docs/running-tests)

[Playwright for .NET](https://playwright.dev/dotnet/)
