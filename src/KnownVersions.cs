using TaleWorlds.Library;

namespace ButterAchievements;

internal static class KnownVersions
{
    public static ApplicationVersion CurrentVersion => TaleWorlds.Library.ApplicationVersion.FromParametersFile();
    public static ApplicationVersion v1_1_0 => new(ApplicationVersionType.Release, 1, 1, 0, 0);
    public static ApplicationVersion v1_2_7 => new(ApplicationVersionType.Release, 1, 2, 7, 0);
}