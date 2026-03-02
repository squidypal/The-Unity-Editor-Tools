# Editor Tools For Unity

- **Sublists:** Collapsible foldout groups for inspector fields. Replaces `[Header]`.
- **ShowIf / ShowIfEnum:** Conditionally show fields based on other field values (bool or enum).

#### Why not use a full library?
Editor tools are generally made to be all-purpose and thus have a lot of functionality I will never use; For personal projects where I do not need nor want these advanced features, these are the 2 I keep using.

---

## Sublist Usage

1. Add `[SubList("Name")]` to the first field of each group in your serializable class.
2. Create a one-line drawer in an `Editor` folder:

```csharp
[CustomPropertyDrawer(typeof(YourClass))]
public class YourClassDrawer : SubListDrawer { }
```

Fields between `[SubList]` attributes are grouped under that foldout. Use `startClosed: true` to collapse by default.

<img alt="image" src="https://github.com/user-attachments/assets/459a0ec4-a7aa-42cc-9060-80c1e8f84950" />

---

## ShowIf Usage

Allows you to hide or show fields dynamically based on the state of other fields. This keeps the Inspector clean and prevents invalid data entry.

### 1. Boolean Toggle

Shows a field only when a specific bool field is `true`.

```csharp
public bool useLimit;

[ShowIf("useLimit")]
public int maxItems;
```

### 2. Enum Condition

Shows a field only when an enum matches a specific value.

```csharp
public State currentState;

[ShowIfEnum("currentState", State.Active)]
public float activeTimer;
```
