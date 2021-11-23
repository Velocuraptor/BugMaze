using UnityEngine;

public class Notebook
{
    private static Notebook _instance;

    private Notebook() { }

    public static Notebook GetInstance()
    {
        if (_instance == null)
            _instance = new Notebook();
        return _instance;
    }

    public void NoticeBug(string bugReport)
    {
        Debug.Log(bugReport);
    }
}
