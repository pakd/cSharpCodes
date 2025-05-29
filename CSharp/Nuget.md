# Nuget Package
## What is a NuGet Package?
A NuGet package is a compiled reusable code library bundled with metadata that can be shared and used across .NET projects. It's the standard way to share and consume third-party or internal libraries in the .NET ecosystem.

## 🔍 What Does a NuGet Package Contain?
A NuGet package is essentially a .nupkg file (a ZIP archive) that includes:
- Compiled DLLs (libraries)
- Metadata (.nuspec file: name, version, authors, dependencies, etc.)
- Optional content files, such as configuration files, scripts, or documentation

🛠 Why Use NuGet?  
- 📦 Package Management: Easily install, update, or remove libraries with one command or click.
- 🔁 Dependency Handling: Automatically manages and installs dependent packages.
- ⏱ Speeds Development: Use proven, tested packages instead of reinventing the wheel.

📚 Example Use Cases
Installing Newtonsoft.Json for JSON parsing.