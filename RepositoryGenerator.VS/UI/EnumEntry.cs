using Microsoft.VisualStudio.RepositoryGenerator.Abstractions;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.RepositoryGenerator.UI
{
    public class EnumEntry
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public object Value { get; set; }
    }

    public static class EnumEntries
    {
        public static IList<EnumEntry> GetTargetFrameworks() => new List<EnumEntry>
        {
            new EnumEntry{ Name = "Net_472", DisplayName="net472", Value = TargetFramework.Net_472},
            new EnumEntry{ Name = "NetStandard_2_0", DisplayName="netstandard2.0", Value = TargetFramework.NetStandard_2_0},
            new EnumEntry{ Name = "NetCoreApp_2_0", DisplayName="netcoreapp2.0", Value = TargetFramework.NetCoreApp_2_0},
            new EnumEntry{ Name = "NetCoreApp_2_1", DisplayName="netcoreapp2.1", Value = TargetFramework.NetCoreApp_2_1},
            new EnumEntry{ Name = "NetCoreApp_2_2", DisplayName="netcoreapp2.2", Value = TargetFramework.NetCoreApp_2_2},
            new EnumEntry{ Name = "NetCoreApp_3_0", DisplayName="netcoreapp3.0", Value = TargetFramework.NetCoreApp_3_0},
        };
    }
}
