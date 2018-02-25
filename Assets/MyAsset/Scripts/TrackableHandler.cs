using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackableHandler : DefaultTrackableEventHandler
{
    public TargetTag myTag;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Main.instance.setTargetStatus(myTag, true);
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Main.instance.setTargetStatus(myTag, false);
    }
}
