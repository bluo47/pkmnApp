### 10/20/23 (Fri)
- [CRUD Operations with Blazor](https://www.c-sharpcorner.com/article/crud-operations-using-blazor-net-6-0-entity-framework-core/)
- [Blazor workshop series](https://github.com/dotnet-presentations/blazor-workshop/blob/main/docs/00-get-started.md)

Blazor workshop notes:   
**Todo app**    
TodoItem creates as a C# class, with two variables represnting the title of the todo item as well as the status of the todo item.    
To bind the TodoItems to HTML in Blazor, we enter our Razor page, Todo.razor and create a c# function in the @code block to update our list of todoitems. To add this, we track the input value using the @bind attribute to a private variable in our code block (newTodo), and we update the application by binding our add function to the button @onclick event, which will run the function when the button is clicked.

### 10/18/23 (Wed)
- Worked on the communication between API and Blazor, and finding way to put that into UI design from MudBlazor
- work on PokeCard? figure if there's a way to use the pkmn variable in  a separate component

### 10/12/23 (Thurs)
- [Reusing HttpClient with Dependency Injection](https://nodogmablog.bryanhogan.net/2017/10/reusing-httpclient-with-dependency-injection/) - it is recommended to only have one HttpClient/similar for as many requests as possible. This article helps to outline how to do this.
- [binding with component params](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-7.0#binding-with-component-parameters)\
- [attaching c# code to DOM events with blazor event handlers](https://learn.microsoft.com/en-us/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers)
- [aspnetcore blazor forms and input components](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-and-input-components?view=aspnetcore-7.0)
