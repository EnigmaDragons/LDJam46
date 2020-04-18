using Assets.Scripts.Demons;

public class ReportGameOver
{
    public DemonName DemonWhoGotYou { get; }

    public ReportGameOver(DemonName demon) => DemonWhoGotYou = demon;
}
