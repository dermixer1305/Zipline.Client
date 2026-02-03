# Zipline.Client

A .NET client for the Zipline API. See Zipline: https://zipline.diced.sh

## Features
- Typed interfaces for auth, user, server, uploads, and misc endpoints
- XML documentation comments
- Configurable base URL and auth token
- Async-first API with CancellationToken support

## Installation

```bash
# after you publish a NuGet package
# dotnet add package Zipline.Client
```

## Quick start

```csharp
using System;
using System.Threading.Tasks;
using Zipline.Client;
using Zipline.Client.Requests;

var options = new ZiplineOptions
{
    BaseUri = new Uri("https://zipline.example.com"),
    AuthToken = "YOUR_TOKEN",
    UserAgent = "Zipline.Client.Sample/1.0"
};

using var client = new ZiplineClient(options);

var files = await client.User.GetFilesAsync(new FileListQuery
{
    Page = 1,
    PerPage = 20,
    Sort = "createdAt",
    Order = "DESC"
});

foreach (var file in files.Page)
{
    Console.WriteLine($"{file.Id} - {file.Name}");
}
```

## Upload example

```csharp
using var stream = File.OpenRead("path/to/file.png");

var result = await client.Upload.UploadAsync(new[]
{
    new UploadFile
    {
        FileName = "file.png",
        Content = stream,
        ContentType = "image/png"
    }
});
```

## Upload Base64 example

```csharp
var result = await client.Upload.UploadBase64Async(
    fileName: "image.png",
    base64: base64String,
    contentType: "image/png"
);
```

## Configuration

```csharp
var options = new ZiplineOptions
{
    BaseUri = new Uri("https://zipline.example.com"),
    AuthToken = "YOUR_TOKEN",
    SessionCookie = null,
    UserAgent = "Zipline.Client/1.0",
    Timeout = TimeSpan.FromSeconds(30)
};
```

## Notes
- This client targets .NET 9 (`net9.0`).
- Some endpoints return raw `JsonElement` payloads to stay forward‑compatible.

## License
MIT (can be changed if you prefer a different license).
