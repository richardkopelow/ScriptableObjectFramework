# ScriptableObjectFramework
This library is based on a [talk](https://www.schellgames.com/blog/insights/game-architecture-with-scriptable-objects) given by Ryan Hipple.
In the talk Ryan goes over creative ways to use Scriptable Objects(SOs) to pass data and fire events between self contained systems.
The advantage of using SOs is that they for the most part live in *Project* space rather than scene space so prefabs are able to reference them.



## Event System
* Define events in the project _i.e. PlayerDeath_  
* Place Handler scripts on object that listen to events  
* Trigger events with a button click

## Variable System
* Define variables in project space that can be referenced and shared by prefabs  
* Easily switch between SO value storage and hardcoded values  
* Set whether SO variables should save in play mode or not  

## Installation
### Download
1. Go to the [release tab](https://github.com/richardkopelow/ScriptableObjectFramework/releases).
2. Download the version you want.
3. Unzip it into your `Assets` folder.

### Git Submodules
1. Add this repo as a submodule.
`git submodule add https://github.com/richardkopelow/ScriptableObjectFramework.git ./Assets/`
2. Init the submodules.
`git submodule init`
3. Update the submodules.
`git submodule update`

### NuGet
1. Make a `nuget.config` file in the Unity Project root
```XML
<configuration>
    <config>
        <add key="repositoryPath" value="./Assets/Packages" />
    </config>
</configuration>
```
2. Using your favorite NuGet Client, install ScriptableObjectFramework.
3. Add the `Assets/Packages` folder to your git ignore.
