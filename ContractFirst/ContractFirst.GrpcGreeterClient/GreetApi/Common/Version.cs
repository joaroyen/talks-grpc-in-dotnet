namespace GreetApi.Common;

partial class Version
{
    public static implicit operator System.Version(Version version)
        => new(version.Major, version.Minor, version.Build, version.Revision);

    public static implicit operator Version(System.Version version)
        => new()
        {
            Major = version.Major,
            Minor = version.Minor,
            Build = version.Build,
            Revision = version.Revision
        };
}
