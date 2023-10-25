_Notes are derived from the information available on Microsoft Learn [here](https://learn.microsoft.com/en-us/training/modules/blazor-improve-how-forms-work/)._ 

# Improve how forms and validation work in Blazor web apps

### Attach C# code to DOM events with Blazor event handlers [#](https://learn.microsoft.com/en-us/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers)

To capture an event with Blazor, you first write a C# method that handles the event, and then bind the event to the method with a Blazor directive.
> "**DOM Events** allow JavaScript to add **event listener** or **event handlers** to HTML elements" [w3schools](https://www.w3schools.com/jsref/dom_obj_event.asp)

Event handler methods essentially take a parameter with extra contextual information in the form of an `EventArgs` parameter. If
