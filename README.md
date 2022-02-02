# Simple Desktop SDK for Unity Application

This project implements an Unity SDK that implements following requirements.

1. The host application should be able to initiate the SDK
2. If initiated, the SDK will display simple message on screen
3. Upon triggered by the application, the SDK will show simple UI
4. (Plus) SDK is initialized and communicated with server via HTTPS protocol

## User Instruction

1. Import package into an existing unity project.
   - You can clone the git project and import package from disk.
     - Before import pacakge, you should change the name of root directory to `com.unknownpgr.desktop-sdk` that it would follow Unity package name rule.
   - Also, you can import package from Git URL directly. **However**, because the package name is not a valid Unity package name, I created a new GitHub repository with valid package name. (https://github.com/unknownpgr/com.unknownpgr.desktop-sdk.git).
2. Add a pre-built prefab `/Runtime/DesktopSDK` to scene. The prefab is `DontDestroyOnLoad` object, so the object only needs to be added to the first scene. However, adding objects in multiple scenes will not cause problems.
3. Then, in C# script, call `DesktopSDK.Instance.Initialize()` to initailize SDK. You can also directly call `Initialize()` method of `DesktopSDK` script attached to the prefab object. (requirement 1) Then a initialization message box will appear (requirement 2). After few seconds, it will retrive its host IP address from server and show it with a message box. (requirement 4)

## APIs

- `public void Initialize()` : Initialize SDK. It will connect to server, currently, as an example, `checkip.amazonaws.com`, get `public` IP address of host machine.
- `public void ShowMessage(string message)` : Disply simple message. (requirement 3)

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
