
public interface IBug
{
    string BugReport { get; }
    bool IsBug { get; }

    void ActivateBug();
}
