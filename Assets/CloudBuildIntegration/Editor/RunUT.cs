using System;
using System.Collections;
using UnityEngine;

public class RunUT
{
    public static void RunPlan()
    {
        Debug.LogWarning("About to run a plan.");
        UTPreferences.DebugMode = true;
        UTAutomationPlan thePlan = UTomate.UTAutomationPlanByName("Prepare");
        if (thePlan == null)
        {
            throw new ArgumentException("There is no plan.");
        }
        var start = Time.realtimeSinceStartup;
        Debug.LogWarning("Running the plan now.");
        UTomate.Run(thePlan);
        var took = Time.realtimeSinceStartup - start;
        while (UTomateRunner.Instance.IsRunning)
        {
            Debug.LogWarning("Waiting for utomate.");
        }

        Debug.LogWarning("Plan ran. Took " + took + "ms");
    }
}
