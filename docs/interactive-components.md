_Notes are derived from the information available on Microsoft Learn [here](https://learn.microsoft.com/en-us/training/modules/blazor-build-rich-interactive-components/)._ 

# Improve how forms and validation work in Blazor web apps

### JavaScript interoperability with Blazor [#](https://learn.microsoft.com/en-us/training/modules/blazor-build-rich-interactive-components/2-create-user-interfaces-blazor-components)

Blazor uses C# as opposed to JS to create dynamic pages, but you can still use Blazor JavaScript interoperability (JS interop) to call JS libraries in Blazor apps and call JavaScript functions from .NET C# code.   
You can normally create documents and components using C# and Blazor's capabilities, but for various reasons it may be more effective to utilize JavaScript interoperability. These reasons are:
- open source JS libraries that render components and UI elements in a specific way
- previously written JS code that you want to reuse and not go through the process of converting it into C#.

To add JS code to a Blazor app, you add it the same way as an HTML web app would, using the `<script>` tag in the *Pages/_Host.cshtml* or *wwwroot/index.html* file.
> A disclaimer: do not scripts in the `<head>` element of the page, as Blazor only controls content in the `<body>` element so JS interop may not function correctly.

