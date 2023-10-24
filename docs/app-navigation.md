_Notes are derived from the information available on Microsoft Learn [here](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/)._ 

# Using pages, routing, and layouts to improve Blazor navigation

### Using the Blazor router component to control app navigation [#](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/2-use-router-component-control-apps-navigation)
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
4. To utilize `NavigationManager`, simply pass the name of our NavigationManager instance (`NavManager` in our case) and call a related function (i.e. `BaseUri`) using dot notation.

> The `Match` attribute in the **NavLink** component is used to manage when the link is highlighted.
There are two options:
- `NavLinkMatch.All` highlights the link as active only when the href matches the **entire current URL**.
- `NavLinkMatch.Prefix` highlights the link as active when the href matches the **first part of the current URL**.

In an example where we have the link `<NavLink href="pizzas" Match="NavLinkMatch.Prefix">`, the link would be highlighted as active for the `/pizzas` URL and any subdirectories under `/pizzas`, like `/pizzas/formaggio` for example.

---

### Changing navigation in Blazor app using the @page directive [#](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/3-exercise-change-navigation-blazor-using-page-directive)

`<a>` elements are used in HTML to represent and add hyperlinks to your webpages. Blazor offers the `NavLink` element that adds more capability to the navigation aspect of our web app.    
Using the `@page` directive, we can instruct Blazor to intercept the request and specify which razor files to route to.

---

### Explore how route parameters affect your Blazor app's routing [#](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/4-explore-route-parameters-effect-apps-routing)

In addition to determining what pages to route requests to, the `@page` directive is also helpful in specifying parts of the URI that can be passed to the component as route parameters.    
Null coalescing (??, ??=) operator is designed to assign the right hand value to the left hand if the left hand is null. It is helpful for defining variables that have not yet been initialized or defined as null. For more information, check this article [here](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator).
> Component parameters are values sent fom a parent component to a child component. In the parent, you specify the component parameter value as an attribute of the child component's tag.

```razor
@page "/FavoritePizzas/{favorite}"
...
@code {
	[Parameter]
	public string Favorite { get; set; }
	...
}
```
The route parameter in the example above (`favorite`) is required; but this parameter can be made optional, by adding a question mark at the end, like this: `favorite?`. The default value for the parameter can be set in the `OnInitialized` method that runs when the user requests the page for the first time. Null coalescing can be used to define the default value given that the parameter is null, as explained above.
> One note about the `OnInitialized` method; it only runs when the page itself is requested the first time - so any subsequent requests made, whether it is from different routing parameters or not, `OnInitialized` won't actually run. If you want a function that does run for these behaviors, use `OnParametersSet` instead.

We can additionally set a catch-all route parameter which will catch all paths under the root href given.

---

### Build reusable Blazor components using layouts

Blazor layouts are a specific kind of component that is designed to be able to be used and shared amongst various pages in the document   
Two requirements that are unique to layout components:
- You must inherit the `LayoutComponentBase` class
- You must include the `@Body` directive in the location where you want referencing components' content to be rendered.

To use a layout from another component, add the `@layout` directive with the name of the layout to be applied. Then, the instance of `@Body` will render the layout's internal HTML.

