# Unity - Design & Programming Guidelines

----

## Basic Rules

- No Scene should have any Console Errors
- No Commit should contain files from an unrelated branch
- Every new feature should be tested in the Unity Editor

----

## Unity PreFab Standards

- Everything in a scene must be composed of nothing except high-level PreFabs
- Every PreFab must be able to be dropped into a new Scene and "just work"
- No Prefab may have any overrides when used in a Scene or another PreFab
- PreFabs must have all of their required connections set in the Editor
- ScriptableObjects are safe connections, since the are Global Singletons
- Children elements are safe connections, since they exist within the current hierarchical 
- PreFabs must not have more than 8 immediate children
- When a generic PreFab is available for an element, use the generic PreFab instead of a custom one (buttons, for example)

----

## Code Style Conventions

- All editor fields should be private, camel-cased `[SerializeField] private Type name = default`
- All properties should be Pascal-cased `public string Name { get; }`
- All methods should be Pascal-cased `public void Execute()`
- Don't use code regions

----

## Game Performance Guidelines

- Avoid Lists. Only use Arrays and Dictionaries.
- Avoid Linq, since it results in boxing elements and impacts Garbage Collection
- Allocate arrays during Awake/Enable phase. Avoid creating arrays during the Game Loop

----

## Unity-isms

- Every PreFab and ScriptableObject should have sensible defaults wired in
- Don't include constructors in any `MonoBehavior` or `ScriptbleObject`
- If an object should be configurable from code, use a method `public void Init(...)` instead
- There should never be any unused methods in code (such as Start/Update)
- There should never be any Unity-generated comments in code
- All Scriptable Objects must be able to be created in the Editor
- Every script should be small and single purpose

----

## Event Guidelines

- Events must be subscribed to in the `OnEnable` phase
- Events must be unsubscribed in the `OnDisable` phase
- Events should never be published until the `Start` phase or later
