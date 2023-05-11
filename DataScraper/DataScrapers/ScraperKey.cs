using System;

namespace DataScraper.DataScrapers;

public abstract class ScraperKey<T> : IScraperKey where T : IScraperKey, new()
{
    public abstract string Name { get; }

    public override bool Equals(object obj) => obj is IScraperKey category && Name == category.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;

    public T Clone() => new ();
}
