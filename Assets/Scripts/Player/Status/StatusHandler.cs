using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    List<Status> statuses = new List<Status>();

    public void AddStatus(StatusTemplate status)
    {
        AddStatus(new Status(status));
    }

    public void AddStatus(Status status)
    {
        statuses.Add(status);
        status.Apply(this);
    }

    public void RemoveStatus(Status status)
    {
        statuses.Remove(status);
        status.End(this);
    }

    void Update()
    {
        for (int i = statuses.Count - 1; i >= 0; i--)
        {
            if (statuses[i].completed)
            {
                RemoveStatus(statuses[i]);
            }
        }
    }
}


