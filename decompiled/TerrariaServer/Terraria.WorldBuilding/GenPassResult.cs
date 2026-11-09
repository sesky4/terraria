namespace Terraria.WorldBuilding;

public class GenPassResult
{
	public string Name { get; set; }

	public int DurationMs { get; set; }

	public int RandNext { get; set; }

	public uint? Hash { get; set; }

	public bool Skipped { get; set; }

	public override string ToString()
	{
		if (Skipped)
		{
			return $"Pass - {Name}: Skipped";
		}
		return string.Format("Pass - {0}: {1}ms, rand: {2:X8}, hash: {3:X8}", new object[4] { Name, DurationMs, RandNext, Hash });
	}

	public bool Matches(GenPassResult other)
	{
		if (Name == other.Name && RandNext == other.RandNext && Skipped == other.Skipped)
		{
			if (Hash.HasValue && other.Hash.HasValue)
			{
				return Hash == other.Hash;
			}
			return true;
		}
		return false;
	}
}
