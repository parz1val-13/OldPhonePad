# 📄 Technical Report: Old Phone Pad Application

## 📌 Overview

The Old Phone Pad application decodes string inputs based on multi-tap T9 keypress logic, simulating how old mobile keypads translated number sequences into text.

### 🌎 Input Format and Functionality

* **Numeric Keypresses** (e.g., `2`, `22`, `222`) represent letters.
* **`*`**: Acts as backspace.
* **`#`**: Indicates end of input.
* **`0`**: Space character.
* **`1`**: Special character (&).

## 🛠️ Tech Stack

### 1. .NET 6 Console App

* Lightweight, cross-platform.
* Uses C# with modern syntax and features.

### 2. xUnit Testing

* Efficient unit testing via `[Theory]`, `[InlineData]`, and `[Trait]`.

### 3. Tools

* Visual Studio 2022+
* Git (optional)
* Terminal CLI

## 🔍 Architecture

```
OldPhonePad/
├── OldPhonePad/
│   ├── OldPhonePad.csproj
│   └── PhonePad.cs        <-- Main decoding logic
│
├── OldPhonePad.Tests/
│   ├── OldPhonePad.Tests.csproj
│   └── OldPhonePadTests.cs  <-- xUnit test cases
│
└── OldPhonePad.sln         <-- Solution file
```

## 📝 Core Logic: Decode Function

```csharp
public static string Decode(string input)
{
    if (string.IsNullOrEmpty(input)) return "";

    var result = new StringBuilder();
    var buffer = new StringBuilder();

    foreach (char ch in input)
    {
        if (ch == '#') break;
        if (ch == '*')
        {
            if (result.Length > 0) result.Length--;
            continue;
        }
        if (ch == ' ') {
            AppendBufferedKey(result, buffer);
            buffer.Clear();
        } else if (char.IsDigit(ch)) {
            if (buffer.Length > 0 && buffer[0] != ch)
            {
                AppendBufferedKey(result, buffer);
                buffer.Clear();
            }
            buffer.Append(ch);
        }
    }

    AppendBufferedKey(result, buffer);
    return result.ToString();
}
```

## 🎨 Visual: T9 Key Mapping

```
Key | Characters
----|------------
 1  | & @
 2  | A B C
 3  | D E F
 4  | G H I
 5  | J K L
 6  | M N O
 7  | P Q R S
 8  | T U V
 9  | W X Y Z
 0  | (space)
```

## 📊 Test Organization

### Grouping via \[Trait]

```csharp
[Trait("Category", "Basic Decoding")]
[Trait("Category", "Backspace Handling")]
[Trait("Category", "Edge and Wraparound")]
```

### Example Test

```csharp
[Theory]
[InlineData("4433555 555666#", "HELLO")]
public void Decode_ShouldReturnExpectedOutput(string input, string expected)
{
    var result = OldPhonePad.PhonePad.Decode(input);
    Assert.Equal(expected, result);
}
```

## 🔢 Practices

* **Pure functions**: No side effects, consistent outputs.
* **Defensive programming**: Handles null/empty input.
* **Extensibility**: Supports adding new keys easily.

## 📊 Summary Table

| Feature                | Implemented |
| ---------------------- | ----------- |
| Multi-tap logic        | ✅           |
| Special key handling   | ✅           |
| Edge cases tested      | ✅           |
| Null-safe decoding     | ✅           |
| Separation of concerns | ✅           |
| CI-ready unit tests    | ✅           |

## 📆 Next Steps

* Add logging/debug mode.
* Wrap in a Web API or GUI.
* International language support.

---


