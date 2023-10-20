_Notes are derived from the information available on Microsoft Learn [here](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/)._ 

# Using pages, routing, and layouts to improve Blazor navigation

### Using the Blazor router component to control app navigation
Routing is how we ensure that each request is sent to the appropriate component and that it displays what exactly the client may want.

```html
<Router AppAssembly="@typeof(Program).Assembly">
	<Found Context="routeData">
		<RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
	</Found>
	<NotFound>
		<p>Sorry, we haven't found any pizzas here.</p>
	</NotFound>
</Router>
```
Blazor routes requests using a specialized component called **Router**. The above code snippet shows how it is usually configured in App.razor.   

What happens:   
1. Blazor checks the `AppAssembly` attribute to check out which assembly to scan.
2. Blazor scans the assembly defined by `AppAssembly` to look for components that have the `RouteAttribute` present.
3. With this, Blazor then compiles a `RouteData` object that specifies how the requests are routed to components
4. _On our side, when we code the app, the @page directive usually put at the top of a Razor page instructs Blazor about the `RouteAttribute`._
5. If matching components are found with the appropriate request, then the code in the `<Found>` tag block is run.
6. On the other side, if there isn't a matching route, you can specify what you want to show in that case, using the `<NotFound>` tag.

In the case you want to write components to handle URIs (Uniform Resource Identifiers, superset of URLs) that the user requests, you would want to have relevant information like:
- current full URI
- base URI
- base relative path
- query string
a `NavigationManager` object is an useful tool to get these values.

To use `NavigationManager`, you need to do:
1. At the top of the document, write the line `@inject NavigationManager NavManager`. You can name the `NavigationManager` however you like. This adds a NavigationManager object into your component for convenient use.
2. Use `QueryHelpers` from `Microsoft.AspNetCore.WebUtilities` to help parse the full URI and access the query string.
3. `NavigationManager` also provides a method to send the user to another component with `NavigationManager.NavigateTo()`.
