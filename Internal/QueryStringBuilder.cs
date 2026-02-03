using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zipline.Client.Internal;

internal sealed class QueryStringBuilder
{
    private readonly List<string> _pairs = new();

    public void Add(string name, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        _pairs.Add($"{Uri.EscapeDataString(name)}={Uri.EscapeDataString(value)}");
    }

    public void Add(string name, int? value)
    {
        if (value is null)
        {
            return;
        }

        Add(name, value.Value.ToString(CultureInfo.InvariantCulture));
    }

    public void Add(string name, long? value)
    {
        if (value is null)
        {
            return;
        }

        Add(name, value.Value.ToString(CultureInfo.InvariantCulture));
    }

    public void Add(string name, bool? value)
    {
        if (value is null)
        {
            return;
        }

        Add(name, value.Value ? "true" : "false");
    }

    public void Add(string name, DateTimeOffset? value)
    {
        if (value is null)
        {
            return;
        }

        Add(name, value.Value.ToString("O", CultureInfo.InvariantCulture));
    }

    public void AddRange(string name, IEnumerable<string>? values)
    {
        if (values is null)
        {
            return;
        }

        foreach (var value in values.Where(static v => !string.IsNullOrWhiteSpace(v)))
        {
            Add(name, value);
        }
    }

    public string ToQueryString()
    {
        if (_pairs.Count == 0)
        {
            return string.Empty;
        }

        return "?" + string.Join("&", _pairs);
    }
}
