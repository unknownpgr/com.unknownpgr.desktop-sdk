# Simple Desktop SDK for Unity Application

This project implements an Unity SDK that implements following requirements.

- The host application should be able to initiate the SDK
- If initiated, the SDK will display simple message on screen
- Upon triggered by the application, the SDK will show simple UI
- (Plus) SDK is initialized and communicated with server via HTTPS protocol

## Considerations

There are two implicit requiremetns.

1. Because this is an SDK, it should be globally accessable.
1. `Initialization` means that this SDK should be stateful.

The most intuitive way of satisfiying these requirements is using singleton pattern.
However, nowdays, singleton pattern is considered bad design pattern and alternative patterns including proxy, or service locator are considered better.

Nevertheless, because

- the size of project is small
- the functionality of SDK is simple
- using other pattern would increase the complexity too much for the scale of the project
- team members are not used to such patterns
  I decided to use singleton pattern.

### References

- https://erdiizgi.com/avoiding-singletons-in-unity/
- https://stackoverflow.com/questions/56437867/best-way-to-use-singletons-in-unity
- https://www.reddit.com/r/Unity3D/comments/5srn5p/avoiding_the_singleton_does_this_follow_good/
- https://www.reddit.com/r/Unity3D/comments/7wrzez/are_singletons_a_bad_idea_to_use/
- https://forum.unity.com/threads/avoiding-singleton-how-to-design-a-class-containing-data-that-is-used-across-the-system.269676/
- https://stackoverflow.com/questions/137975/what-are-drawbacks-or-disadvantages-of-singleton-pattern
